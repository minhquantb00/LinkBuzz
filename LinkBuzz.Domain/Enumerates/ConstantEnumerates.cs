using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LinkBuzz.Domain.Enumerates
{
    public class ConstantEnumerates
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public enum Gender
        {
            UnKnown = 0,
            Male = 1,
            Female = 2
        }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public enum AccountType
        {
            Personal = 0,
            Company = 1
        }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public enum PrivacySettings
        {
            OnlyMe = 0,
            Friend = 1,
            Public = 2
        }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public enum RelationshipStatus
        {
            DocThan = 0,
            HenHo = 1,
            DangTimHieu = 2,
            DaKetHon = 3
        }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public enum ActivityType
        {
            LOGIN = 0,
            LOGOUT = 1
        }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public enum ReactType
        {
            Thich = 0,
            YeuThich = 1,
            Haha = 2,
            Wow = 3,
            PhanNo = 4,
            Buon = 5
        }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public enum NotificationType
        {
            ThongBaoKetBan = 0,
            ThongBaoBaiVietBanBe = 1,
            ThongBaoBaiVietCuaBanThan = 2,
            ThongBaoBaiVietCuaPage = 3
        }
    }
}
