using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Common
{
    public class LoginResponse
    {
        public bool success { get; set; }
        public string token { get; set; }
    }
}
