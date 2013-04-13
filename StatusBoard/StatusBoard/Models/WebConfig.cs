using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace StatusBoard.Models
{
    public class WebConfig
    {
        public static string OnTimeClientID
        {
            get { return ConfigurationManager.AppSettings["OnTimeClientID"]; }
        }

        public static string OnTimeClientSecret
        {
            get { return Environment.GetEnvironmentVariable("OnTimeClientSecret", EnvironmentVariableTarget.Machine); }

        }

    }
}