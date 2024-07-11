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
        public AuthService(IRepository<User> userRepository, UserConverter userConverter)
        {
            _userRepository = userRepository;
            _userConverter = userConverter;
        }
        public async Task<ResponseObject<DataResponseUser>> Register(Request_RegisterUser request)
        {
            try
            {
                var checkUserName = await _userRepository.GetAsync(item => item.UserName.Equals(request.UserName));
                if(checkUserName != null)
                {
                    return new ResponseObject<DataResponseUser>
                    {
                        Data = null,
                        Message = "Tên tài khoản đã tồn tại trên hệ thống! Vui lòng thử lại",
                        Status = StatusCodes.Status400BadRequest
                    };
                }
                var checkEmail = await _userRepository.GetAsync(item => item.Email.Equals(request.Email));
                if(checkEmail != null)
                {
                    return new ResponseObject<DataResponseUser>
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Data = null,
                        Message = "Email đã tồn tại trên hệ thống! Vui lòng thử lại"
                    };
                }
                var checkPhoneNumber = await _userRepository.GetAsync(item => item.PhoneNumber.Equals(request.PhoneNumber));
                if(checkPhoneNumber != null)
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
                    UserStatusId = (long) ((int) ConstantEnumerates.UserStatus.Activated),
                    UserName = request.UserName
                };
                user = await _userRepository.CreateAsync(user);
                return new ResponseObject<DataResponseUser>
                {
                    Data = _userConverter.EntityToDTO(user),
                    Message = "Đăng ký tài khoản thành công",
                    Status = StatusCodes.Status200OK
                };
            }catch (Exception ex)
            {
                return new ResponseObject<DataResponseUser>
                {
                    Data = null,
                    Message= ex.Message,
                    Status = StatusCodes.Status500InternalServerError
                };
            }
        }
    }
}
