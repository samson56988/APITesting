using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Demo;
using AventStack.ExtentReports;

namespace APITests
{
    [TestClass]
    public class RegressionTest
    {

        public TestContext TestContext { get; set; }    

        [ClassInitialize]
        public static void Setup(TestContext testContext)
        {
            var dir = testContext.TestRunDirectory;
            Reporter.SetupExtentReport("API Regression Test", "API Regression Test Report", dir);
        }

        [TestInitialize]
        public void SetupTest()
        {
            Reporter.CreateTest(TestContext.TestName);
        }

        [TestCleanup]
        public void CleanupTest()
        {
            var testStatus = TestContext.CurrentTestOutcome;
            Status logStatus;

            switch(testStatus)
            {
                case UnitTestOutcome.Failed:
                    logStatus = Status.Fail;
                    Reporter.TestStatus(logStatus.ToString());
                    break;
                case UnitTestOutcome.Inconclusive:
                    break;
                case UnitTestOutcome.Passed:
                    logStatus = Status.Pass;
                    Reporter.TestStatus(logStatus.ToString());
                    break;
                case UnitTestOutcome.Error:
                    break;
                case UnitTestOutcome.Timeout:
                    break;
                case UnitTestOutcome.Aborted:
                    break;
                case UnitTestOutcome.Unknown:
                    break;
                case UnitTestOutcome.NotRunnable:
                    break;
                default:
                    break;
            }
        }

        [ClassCleanup]
        public static void CleanUp()
        {
            Reporter.FlushReport();
        }

        [TestMethod]
        public void VerifyListOfUsers()
        {
            var demo = new APIDemo<ListOfUserDTO>();
            var response = demo.GetUsers("api/users?page=2");
            Assert.AreEqual(2, response.Page);
            Reporter.LogReport(Status.Pass, "Page number match");
            Assert.AreEqual("Michael", response.Data[0].first_name);
            Reporter.LogReport(Status.Pass, "User Firstname  match");
        }
        [TestMethod]
        public void CreateNewUser()
        {
            string payload = @"{
                                 ""name"":""Samson"",
                                 ""job"":""leader""
                                 }";
            var demo = new APIDemo<CreatUserDTO>();
            var user = demo.CreateUsers("api/users", payload);
            Assert.AreEqual("Samson",user.Name);
            Assert.AreEqual("leader", user.Job);

            var demoOne = new APIDemo<ListOfUserDTO>();
            var response = demoOne.GetUsers("api/users?page=2");
            Assert.AreEqual(2, response.Page);
            Assert.AreEqual("Michael", response.Data[0].first_name);
        }




    }
}
