using RestSharp;
using Newtonsoft.Json;
using UsersList;

namespace APIDemo
{
    public class Demo
    {
        private readonly string _url = "https://reqres.in";
        private readonly string _endpoint = "/api/users?page=2";

        public ListOfUsersDTO GetUsers()
        {
            var client = new RestClient(_url);
            var request = new RestRequest(_endpoint, Method.Get);

            request.AddHeader("Accept", "application/json");
            request.RequestFormat = DataFormat.Json;

            RestResponse response = client.Execute(request);
            var content = response.Content;

            var users = JsonConvert.DeserializeObject<ListOfUsersDTO>(content);

            return users;
        }
    }
}
