using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkBuzz.Application.Payloads.RequestModels.AuthModels
{
    public class Request_Login
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
