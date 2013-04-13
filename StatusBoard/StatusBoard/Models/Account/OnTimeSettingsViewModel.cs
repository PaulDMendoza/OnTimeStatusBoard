using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StatusBoard.Models.Account
{
    public class OnTimeSettingsViewModel
    {
        public string OnTimeBaseUrl { get; set; }

        public string OnTimeClientID { get; set; }

        public string OnTimeAuthToken { get; set; }
    }
}