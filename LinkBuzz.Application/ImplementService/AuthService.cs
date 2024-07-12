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
using Org.BouncyCastle.Asn1.Ocsp;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkBuzz.Application.ImplementService
{
    public class AuthService : IAuthService
    {
        private readonly IRepository<User> _userRepository;
        private readonly UserConverter _userConverter;
        private readonly IDatabase _redisDb;
        private readonly TimeSpan _cacheExpiry = TimeSpan.FromMinutes(10);

        private User checkUserName;
        private User checkEmail;
        private User checkPhoneNumber;

        public AuthService(IRepository<User> userRepository, UserConverter userConverter, IConnectionMultiplexer redis)
        {
            _userRepository = userRepository;
            _userConverter = userConverter;
            _redisDb = redis.GetDatabase();
        }

        public async Task<AuthService> InitData(string userName, string email, string phoneNumber)
        {
            checkUserName = await GetFromRedisOrDb(userName, "username");
            checkEmail = await GetFromRedisOrDb(email, "email");
            checkPhoneNumber = await GetFromRedisOrDb(phoneNumber, "phoneNumber");
            return this;
        }

        private async Task<User> GetFromRedisOrDb(string key, string type)
        {
            string userName = await _redisDb.StringGetAsync(key);
            if (!string.IsNullOrEmpty(userName))
            {
                return new User { UserName = userName }; 
            }

            User user = type switch
            {
                "username" => await _userRepository.GetAsync(item => item.UserName.Equals(key)),
                "email" => await _userRepository.GetAsync(item => item.Email.Equals(key)),
                "phoneNumber" => await _userRepository.GetAsync(item => item.PhoneNumber.Equals(key)),
                _ => null
            };

            if (user != null)
            {
                await _redisDb.StringSetAsync(key, user.UserName, _cacheExpiry);
            }

            return user;
        }

        public async Task<ResponseObject<DataResponseUser>> Register(Request_RegisterUser request)
        {
            await this.InitData(request.UserName, request.Email, request.PhoneNumber);
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

                await _redisDb.StringSetAsync(user.UserName, user.UserName, _cacheExpiry);
                await _redisDb.StringSetAsync(user.Email, user.UserName, _cacheExpiry);
                await _redisDb.StringSetAsync(user.PhoneNumber, user.UserName, _cacheExpiry);

                return new ResponseObject<DataResponseUser>
                {
                    Data = _userConverter.EntityToDTO(user),
                    Message = "Đăng ký tài khoản thành công",
                    Status = StatusCodes.Status200OK
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




        //public AuthService(IRepository<User> userRepository, UserConverter userConverter)
        //{
        //    _userRepository = userRepository;
        //    _userConverter = userConverter;
        //}

        //public async Task<AuthService> InitData(string userName, string email, string phoneNumber)
        //{
        //    checkUserName = await _userRepository.GetAsync(item => item.UserName.Equals(userName));
        //    checkEmail = await _userRepository.GetAsync(item => item.Email.Equals(email));
        //    checkPhoneNumber = await _userRepository.GetAsync(item => item.PhoneNumber.Equals(phoneNumber));
        //    return this;
        //}
        //public async Task<ResponseObject<DataResponseUser>> Register(Request_RegisterUser request)
        //{
        //    await this.InitData(request.UserName, request.Email, request.PhoneNumber);
        //    try
        //    {
        //        if (checkUserName != null)
        //        {
        //            return new ResponseObject<DataResponseUser>
        //            {
        //                Data = null,
        //                Message = "Tên tài khoản đã tồn tại trên hệ thống! Vui lòng thử lại",
        //                Status = StatusCodes.Status400BadRequest
        //            };
        //        }
        //        if (checkEmail != null)
        //        {
        //            return new ResponseObject<DataResponseUser>
        //            {
        //                Status = StatusCodes.Status400BadRequest,
        //                Data = null,
        //                Message = "Email đã tồn tại trên hệ thống! Vui lòng thử lại"
        //            };
        //        }
        //        if (checkPhoneNumber != null)
        //        {
        //            return new ResponseObject<DataResponseUser>
        //            {
        //                Status = StatusCodes.Status400BadRequest,
        //                Data = null,
        //                Message = "Số điện thoại đã tồn tại trên hệ thống! Vui lòng thử lại"
        //            };
        //        }
        //        User user = new User
        //        {
        //            Avatar = "https://cdnphoto.dantri.com.vn/epjkD8Rb1CAms9R8YFaZguFADDo=/thumb_w/1020/2024/03/06/chuong-nhuoc-nam-3-1709695278893.jpg",
        //            DateOfBirth = request.DateOfBirth,
        //            Email = request.Email,
        //            FirstName = request.FirstName,
        //            Gender = request.Gender,
        //            LastName = request.LastName,
        //            Password = request.Password,
        //            PhoneNumber = request.PhoneNumber,
        //            RegistrationDate = DateTime.Now,
        //            UserStatusId = (long)((int)ConstantEnumerates.UserStatus.Activated),
        //            UserName = request.UserName
        //        };
        //        user = await _userRepository.CreateAsync(user);
        //        return new ResponseObject<DataResponseUser>
        //        {
        //            Data = _userConverter.EntityToDTO(user),
        //            Message = "Đăng ký tài khoản thành công",
        //            Status = StatusCodes.Status200OK
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        return new ResponseObject<DataResponseUser>
        //        {
        //            Data = null,
        //            Message = ex.Message,
        //            Status = StatusCodes.Status500InternalServerError
        //        };
        //    }
        //}
    }
}
