using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatusBoard.Tests
{
    public class TestConfig
    {
        public static string OnTimeClientID
        {
            get { return ConfigurationManager.AppSettings["OnTimeClientID"]; }
        }

        public static string OnTimeClientSecret
        {
            get { return Environment.GetEnvironmentVariable("OnTimeClientSecret", EnvironmentVariableTarget.Machine); }
        }

        public static string OnTimeTestingUserToken
        {
            get { return Environment.GetEnvironmentVariable("OnTimeTestingUserToken", EnvironmentVariableTarget.Machine); }
        }

        public static string OnTimeBaseUrl
        {
            get { return ConfigurationManager.AppSettings["OnTimeTestUserUrl"]; }
            
        }
    }
}
