using Microsoft.VisualStudio.TestTools.UnitTesting;
using APIDemo;

namespace APITests
{
    [TestClass]
    public class RegressionTests
    {
        [TestMethod]
        public void VerifyListOfUsers()
        {
            var demo = new Demo();
            var response = demo.GetUsers();

            Assert.AreEqual(2, response.Page);
            Assert.AreEqual("Michael", response.Data[0].first_name);
        }

        [TestMethod]
        public void CreateNewUser()
        {
            string payload = @"{
                                ""name"": ""morpheus"",
                                ""job"": ""leader""
                               }";


        }
    }
}
