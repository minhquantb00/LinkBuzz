using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkBuzz.Domain.Helpers
{
    public class Constants
    {
        public class AppSettingKeys
        {
            public const string DEFAULT_CONNECTION = "DefaultConnection";
            public const string AUTH_SECRET = "JWT:SecretKey";
            public const string DEFAULT_CONTROLLER_ROUTE = "api/[controller]";

        }
        public class DefaultValue
        {
            public const int DEFAULT_PAGE_SIZE = 10;
            public const int DEFAULT_PAGE_NO = 1;
            public const string DEFAULT_CONTROLLER_ROUTE = "api/[controller]/[action]";
            public const string DEFAULT_CONTROLLER_ROUTE_WITHOUT_ACTION = "api/[controller]";
            public const string DEFAULT_ACTION_ROUTE = "[action]";
        }
        public class ContextItem
        {
            public const string USER = "User";
            public const string PERMISSIONS = "Permissions";
        }
    }
}
