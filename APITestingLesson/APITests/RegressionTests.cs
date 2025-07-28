using Microsoft.VisualStudio.TestTools.UnitTesting;
using APIDemo;
using UsersList;

namespace APITests
{
    [TestClass]
    public class RegressionTests
    {
        [TestMethod]
        public void VerifyListOfUsers()
        {
            var demo = new Demo<ListOfUsersDTO>();
            var user = demo.GetUsers("api/users?page=2");

            Assert.AreEqual(2, user.Page);
            Assert.AreEqual("Michael", user.Data[0].first_name);
        }

        
    }
}

/*
[TestMethod]
public void CreateNewUser()
{
    string payload = @"{
                                ""name"": ""Mike"",
                                ""job"": ""Team leader""
                               }";

    var demo = new Demo<CreateUserDTO>();
    var user = demo.CreateUser("api/users", payload);

    Assert.AreEqual("Mike", user.name);
    Assert.AreEqual("Team leader", user.job);
}
*/