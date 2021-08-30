using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbastacaAPI.Helper
{
    public class AppConfig
    {
        public int PortSMTP { get; set; }
        public string TokenSecret { get; set; }
        public string Email { get; set; }
        public string ServerSMTP { get; set; }  
    }
}
