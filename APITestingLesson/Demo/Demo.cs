using RestSharp;
using Newtonsoft.Json;
using UsersList;
using APIDemo;

namespace APIDemo
{
    public class Demo<T>
    {
        //private readonly string _url = "https://reqres.in";
        //private readonly string _endpoint = "/api/users?page=2";

        public ListOfUsersDTO GetUsers(string endpoint)
        {
            var user = new APIHelper<ListOfUsersDTO>();
            var url = user.SetUrl(endpoint);
            var request = user.CreateGetRequest();
            var response = user.GetResponse(url, request);

            ListOfUsersDTO content = user.GetContent<ListOfUsersDTO>(response);

            return content;
        }

        public CreateUserDTO CreateUser(string endpoint, dynamic payload)
        {
            var user = new APIHelper<CreateUserDTO>();
            var url = user.SetUrl(endpoint);
            var request = user.CreatePostRequest(payload);
            var response = user.GetResponse(url, request);

            CreateUserDTO content = user.GetContent<CreateUserDTO>(response);

            return content;
        }
    }
}
