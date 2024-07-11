using LinkBuzz.Application.Payloads.ResponseModels.DataUser;
using LinkBuzz.Domain.Entities.UserEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkBuzz.Application.Payloads.Converters
{
    public class UserConverter
    {
        public DataResponseUser EntityToDTO(User user)
        {
            return new DataResponseUser
            {
                Address = user.Address,
                Avatar = user.Avatar,
                CurrentLocation = user.CurrentLocation,
                CurrentResident = user.CurrentResident,
                DateOfBirth = user.DateOfBirth,
                Email = user.Email,
                FirstName = user.FirstName,
                Gender = user.Gender.ToString(),
                Id = user.Id,
                LastName = user.LastName,
                NumberOfFollowers = user.NumberOfFollowers,
                NumberOfFriends = user.NumberOfFriends,
                NumberOfPagesLiked = user.NumberOfPagesLiked,
                PhoneNumber = user.PhoneNumber,
                RegistrationDate = user.RegistrationDate,
                RelationshipStatus = user.RelationshipStatus.ToString(),
                Story =user.Story,
                ThumbNail = user.ThumbNail,
                UserName = user.UserName,
            };
        }
    }
}
