using LinkBuzz.Application.Payloads.RequestModels.AuthModels;
using LinkBuzz.Application.Payloads.ResponseModels.DataUser;
using LinkBuzz.Application.Payloads.Responses;
using LinkBuzz.Domain.Entities.UserEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkBuzz.Application.InterfaceService
{
    public interface IAuthService
    {
        Task<ResponseObject<DataResponseUser>> Register(Request_RegisterUser request);
        Task AddRoleToUser(long userId, List<string> roles);
        Task<ResponseObject<DataResponseLogin>> GetJwtTokenAsync(User user);
        Task<ResponseObject<DataResponseLogin>> Login(Request_Login request);
    }
}
