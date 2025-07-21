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
                                ""name"": ""Mike"",
                                ""job"": ""Team leader""
                               }";

            var user = new APIHelper<CreateUserDTO>();
            var url = user.SetUrl("api/users");
            var request = user.CreatePostRequest(payload);
            var response = user.GetResponse(url, request);

            CreateUserDTO content = user.GetContent<CreateUserDTO>(response);

            Assert.AreEqual("Mike", content.name);
            Assert.AreEqual("Team leader", content.job);
        }
    }
}
