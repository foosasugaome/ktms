using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ktms
{
    public class UserAuthenticationInfo
    {
        public string UserName { get; set; }
        public DateTime Expiration { get; set; }
        public string UserData { get; set; }
        public string[] UserDataArray { get; set; }
    }

}