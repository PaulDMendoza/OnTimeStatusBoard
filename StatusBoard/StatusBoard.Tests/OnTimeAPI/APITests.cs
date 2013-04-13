using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnTimeApi;
using StatusBoard.Models;

namespace StatusBoard.Tests.OnTimeAPI
{
    [TestClass]
    public class APITests
    {
        [TestMethod]
        public void Features()
        {
            var api = new OnTime(new Settings(TestConfig.OnTimeBaseUrl, TestConfig.OnTimeClientID, TestConfig.OnTimeClientSecret), TestConfig.OnTimeTestingUserToken);
            var features = api.Get<StatusBoard.Models.OnTimeApiModels.Features>("v1/features");
            Assert.AreNotEqual(0, features.data.Length);
        }

        [TestMethod]
        public void Defects()
        {
            var api = new OnTime(new Settings(TestConfig.OnTimeBaseUrl, TestConfig.OnTimeClientID, TestConfig.OnTimeClientSecret), TestConfig.OnTimeTestingUserToken);
            var defects = api.Get<StatusBoard.Models.OnTimeApiModels.Defects>("v1/defects");
            Assert.AreNotEqual(0, defects.data.Length);
        }

        [TestMethod]
        public void Projects()
        {
            var api = new OnTime(new Settings(TestConfig.OnTimeBaseUrl, TestConfig.OnTimeClientID, TestConfig.OnTimeClientSecret), TestConfig.OnTimeTestingUserToken);
            var projects = api.Get<StatusBoard.Models.OnTimeApiModels.Defects>("v1/projects");
            Assert.AreNotEqual(0, projects.data.Length);
        }

        [TestMethod]
        public void Releases()
        {
            var api = new OnTime(new Settings(TestConfig.OnTimeBaseUrl, TestConfig.OnTimeClientID, TestConfig.OnTimeClientSecret), TestConfig.OnTimeTestingUserToken);
            var projects = api.Get<StatusBoard.Models.OnTimeApiModels.Releases>("v1/releases");
            Assert.AreNotEqual(0, projects.data.Length);
        }

        [TestMethod]
        public void Users()
        {
            var api = new OnTime(new Settings(TestConfig.OnTimeBaseUrl, TestConfig.OnTimeClientID, TestConfig.OnTimeClientSecret), TestConfig.OnTimeTestingUserToken);
            var users = api.Get<StatusBoard.Models.OnTimeApiModels.Users>("v1/users");
            Assert.AreNotEqual(0, users.data.Length);
        }

        [TestMethod]
        public void Severity()
        {
            var api = new OnTime(new Settings(TestConfig.OnTimeBaseUrl, TestConfig.OnTimeClientID, TestConfig.OnTimeClientSecret), TestConfig.OnTimeTestingUserToken);
            var severities = api.Get<StatusBoard.Models.OnTimeApiModels.Severities>("v1/picklists/severity");
            Assert.AreNotEqual(0, severities.data.Length);
        }

        [TestMethod]
        public void Priorities()
        {
            var api = new OnTime(new Settings(TestConfig.OnTimeBaseUrl, TestConfig.OnTimeClientID, TestConfig.OnTimeClientSecret), TestConfig.OnTimeTestingUserToken);
            var priorities = api.Get<StatusBoard.Models.OnTimeApiModels.Severities>("v1/picklists/priority");
            Assert.AreNotEqual(0, priorities.data.Length);
        }
    }
}
