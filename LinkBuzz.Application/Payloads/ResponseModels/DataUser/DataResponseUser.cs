using LinkBuzz.Domain.Entities.UserEntities;
using LinkBuzz.Domain.Enumerates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkBuzz.Application.Payloads.ResponseModels.DataUser
{
    public class DataResponseUser
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Address { get; set; }
        public string? CurrentResident { get; set; }
        public string? Story { get; set; }
        public int NumberOfFollowers { get; set; }
        public int NumberOfFriends { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Gender { get; set; }
        public string? CurrentLocation { get; set; }
        public string? ThumbNail { get; set; }
        public int NumberOfPagesLiked { get; set; }
        public string RelationshipStatus { get; set; }
        public string Avatar { get; set; }
    }
}
