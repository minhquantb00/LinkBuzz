using LinkBuzz.Application.InterfaceService;
using LinkBuzz.Application.Payloads.Converters;
using LinkBuzz.Application.Payloads.RequestModels.AuthModels;
using LinkBuzz.Application.Payloads.ResponseModels.DataUser;
using LinkBuzz.Application.Payloads.Responses;
using LinkBuzz.Domain.Entities.UserEntities;
using LinkBuzz.Domain.Enumerates;
using LinkBuzz.Domain.Helpers;
using LinkBuzz.Domain.InterfaceRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Org.BouncyCastle.Asn1.Ocsp;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Role = LinkBuzz.Domain.Entities.UserEntities.Role;
using BcryptNet = BCrypt.Net.BCrypt;

namespace LinkBuzz.Application.ImplementService
{
    public class AuthService : IAuthService
    {
        #region Khởi tạo chỉ đọc không ghi
        private readonly IRepository<User> _userRepository;
        private readonly UserConverter _userConverter;
        private readonly IDatabase _redisDb;
        private readonly IRepository<Permission> _permissionRepository;
        private readonly IRepository<Role> _roleRepository;
        private readonly IConfiguration _configuration;
        private readonly IRepository<RefreshToken> _refreshTokenRepository;
        private readonly TimeSpan _cacheExpiry = TimeSpan.FromMinutes(10);
        #endregion
        #region Biến dùng trong class
        private User checkUserName;
        private User checkEmail;
        private User checkPhoneNumber;
        private IQueryable<Permission> permissions;
        private IQueryable<Role> roles;
        private IQueryable<string> userRoles;
        #endregion
        #region Hàm khởi tạo truyền tham số
        public AuthService(IRepository<User> userRepository, UserConverter userConverter, IConnectionMultiplexer redis, IRepository<Permission> permissionRepository, IRepository<Role> roleRepository, IConfiguration configuration, IRepository<RefreshToken> refreshTokenRepository)
        {
            _userRepository = userRepository;
            _userConverter = userConverter;
            _redisDb = redis.GetDatabase();
            _permissionRepository = permissionRepository;
            _roleRepository = roleRepository;
            _configuration = configuration;
            _refreshTokenRepository = refreshTokenRepository;
        }
        #endregion
        #region Init data
        public async Task<AuthService> InitData(string? userName, string? email, string? phoneNumber, User? user)
        {
            if (!string.IsNullOrEmpty(userName))
            {
                checkUserName = await GetFromRedisOrDb(userName, "username");
            }
            if (!string.IsNullOrEmpty(email))
            {
                checkEmail = await GetFromRedisOrDb(email, "email");
            }
            if (!string.IsNullOrEmpty(phoneNumber))
            {
                checkPhoneNumber = await GetFromRedisOrDb(phoneNumber, "phoneNumber");
            }
            if (user != null)
            {
                var permissions = await _permissionRepository.GetAllAsync(x => x.UserId == user.Id);
            }
            var roles = await _roleRepository.GetAllAsync();
            return this;
        }
        #endregion
        #region Private Methods
        private async Task<User?> GetFromRedisOrDb(string key, string type)
        {
            string userName = await _redisDb.StringGetAsync(key);
            if (!string.IsNullOrEmpty(userName))
            {
                return new User { UserName = userName };
            }

            User? user = type switch
            {
                "username" => await _userRepository.GetAsync(item => item.UserName.Equals(key)),
                "email" => await _userRepository.GetAsync(item => item.Email.Equals(key)),
                "phoneNumber" => await _userRepository.GetAsync(item => item.PhoneNumber.Equals(key)),
                "password" => await _userRepository.GetAsync(item => item.Password.Equals(key)),
                _ => null
            };

            if (user != null)
            {
                await _redisDb.StringSetAsync(key, user.UserName, _cacheExpiry);
            }

            return user;
        }

        private async Task AddUserToRedis(User user)
        {
            await _redisDb.StringSetAsync(user.UserName, user.UserName, _cacheExpiry);
            await _redisDb.StringSetAsync(user.Email, user.UserName, _cacheExpiry);
            await _redisDb.StringSetAsync(user.PhoneNumber, user.UserName, _cacheExpiry);
            await _redisDb.StringSetAsync(user.Password, user.UserName, _cacheExpiry);
            await _redisDb.StringSetAsync(user.AccountType?.ToString(), user.UserName, _cacheExpiry);

        }
        #endregion
        #region Service
        #region Đăng ký
        public async Task<ResponseObject<DataResponseUser>> Register(Request_RegisterUser request)
        {
            await this.InitData(request.UserName, request.Email, request.PhoneNumber, null);
            try
            {
                if (checkUserName != null)
                {
                    return new ResponseObject<DataResponseUser>
                    {
                        Data = null,
                        Message = "Tên tài khoản đã tồn tại trên hệ thống! Vui lòng thử lại",
                        Status = StatusCodes.Status400BadRequest
                    };
                }
                if (checkEmail != null)
                {
                    return new ResponseObject<DataResponseUser>
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Data = null,
                        Message = "Email đã tồn tại trên hệ thống! Vui lòng thử lại"
                    };
                }
                if (checkPhoneNumber != null)
                {
                    return new ResponseObject<DataResponseUser>
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Data = null,
                        Message = "Số điện thoại đã tồn tại trên hệ thống! Vui lòng thử lại"
                    };
                }

                User user = new User
                {
                    Avatar = "https://cdnphoto.dantri.com.vn/epjkD8Rb1CAms9R8YFaZguFADDo=/thumb_w/1020/2024/03/06/chuong-nhuoc-nam-3-1709695278893.jpg",
                    DateOfBirth = request.DateOfBirth,
                    Email = request.Email,
                    FirstName = request.FirstName,
                    Gender = request.Gender,
                    LastName = request.LastName,
                    Password = request.Password,
                    PhoneNumber = request.PhoneNumber,
                    RegistrationDate = DateTime.Now,
                    UserStatusId = (long)((int)ConstantEnumerates.UserStatus.Activated),
                    UserName = request.UserName
                };
                user = await _userRepository.CreateAsync(user);
                if (user != null)
                {
                    await AddRoleToUser(user.Id, new List<string> { "User" });
                    await AddUserToRedis(user);

                    return new ResponseObject<DataResponseUser>
                    {
                        Data = _userConverter.EntityToDTO(user),
                        Message = "Đăng ký tài khoản thành công",
                        Status = StatusCodes.Status200OK
                    };
                }
                return new ResponseObject<DataResponseUser>
                {
                    Data = null,
                    Message = "Đăng ký tài khoản thất bại",
                    Status = StatusCodes.Status400BadRequest
                };
            }
            catch (Exception ex)
            {
                return new ResponseObject<DataResponseUser>
                {
                    Data = null,
                    Message = ex.Message,
                    Status = StatusCodes.Status500InternalServerError
                };
            }
        }
        public async Task AddRoleToUser(long userId, List<string> roles)
        {
            try
            {
                var user = await _userRepository.GetByIdAsync(userId);
                if (user == null)
                {
                    throw new ArgumentNullException(nameof(user), "User không tồn tại");
                }
                await _userRepository.AddUserToRoleAsync(user, roles);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        #endregion
        #region Đăng nhập
        #region Chức năng đăng nhập

        public async Task<ResponseObject<DataResponseLogin>> Login(Request_Login request)
        {
            await this.InitData(request.UserName, null, null, null);
            try
            {
                if (checkUserName == null)
                {
                    return new ResponseObject<DataResponseLogin>
                    {
                        Status = StatusCodes.Status404NotFound,
                        Message = "Tài khoản không chính xác",
                        Data = null
                    };
                }
                var checkPassword = BcryptNet.Verify(request.Password, checkUserName.Password);
                if (!checkPassword)
                {
                    return new ResponseObject<DataResponseLogin>
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Message = "Mật khẩu không chính xác",
                        Data = null
                    };
                }
                return new ResponseObject<DataResponseLogin>
                {
                    Status = StatusCodes.Status200OK,
                    Message = "Đăng nhập thành công",
                    Data = new DataResponseLogin
                    {
                        AccessToken = GetJwtTokenAsync(checkUserName).Result.Data.AccessToken,
                        RefreshToken = GetJwtTokenAsync(checkUserName).Result.Data.RefreshToken,
                    }
                };
            }
            catch (Exception ex)
            {
                return new ResponseObject<DataResponseLogin>
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Message = ex.Message,
                    Data = null
                };
            }
        }
        #endregion

        #region Xử lý token
        private async Task<List<Claim>> HandleClaim(User user)
        {
            await this.InitData(user.UserName, user.Email, user.PhoneNumber, user);
            var authClaims = new List<Claim>
            {
                new Claim("Id", user.Id.ToString()),
                new Claim("UserName", user.UserName),
                new Claim("Email", user.Email),
            };

            foreach (var permission in permissions)
            {
                foreach (var role in roles)
                {
                    if (role.Id == permission.RoleId)
                    {
                        authClaims.Add(new Claim("Permission", role.Name));
                    }
                }
            }

            foreach (var role in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, role));
            }
            return authClaims;
        }
        public async Task<ResponseObject<DataResponseLogin>> GetJwtTokenAsync(User user)
        {
            await this.InitData(user.UserName, user.Email, user.PhoneNumber, user);
            var listClaim = await HandleClaim(user);
            var jwtToken = GetToken(listClaim);
            var refreshToken = GenerateRefreshToken();
            _ = int.TryParse(_configuration["JWT:RefreshTokenValidity"], out int refreshTokenValidity);

            RefreshToken rf = new RefreshToken
            {
                UserId = user.Id,
                ExpiryTime = DateTime.UtcNow.AddHours(refreshTokenValidity),
                Token = refreshToken
            };

            rf = await _refreshTokenRepository.CreateAsync(rf);

            return new ResponseObject<DataResponseLogin>
            {
                Status = StatusCodes.Status200OK,
                Message = "Token created successfully",
                Data = new DataResponseLogin
                {
                    AccessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken),
                    RefreshToken = refreshToken,
                }
            };
        }

        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]));
            _ = int.TryParse(_configuration["JWT:TokenValidityInMinutes"], out int tokenValidityInMinutes);
            var expirationTimeUtc = DateTime.UtcNow.AddHours(tokenValidityInMinutes);
            var localTimeZone = TimeZoneInfo.Local;
            var expirationTimeInLocalTimeZone = TimeZoneInfo.ConvertTimeFromUtc(expirationTimeUtc, localTimeZone);

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: expirationTimeInLocalTimeZone,
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }
        private string GenerateRefreshToken()
        {
            var randomNumber = new Byte[64];
            var range = RandomNumberGenerator.Create();
            range.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }
        #endregion

        #endregion
        #endregion
    }
}
