using Newtonsoft.Json;
using RestSharp;
using System.IO;

namespace APIDemo
{
    public class APIHelper<T>
    {
        private readonly string _baseUrl = "https://reqres.in/";
        public RestClient client;
        public RestRequest request;

        public RestClient SetUrl(string endpoint)
        {
            string url = _baseUrl + endpoint;
            var client = new RestClient(url);

            client.AddDefaultHeader("x-api-key", "reqres-free-v1");

            return client;
        }

        public RestRequest CreateGetRequest()
        {
            var request = new RestRequest("api/users?page=2", Method.Get);
            request.AddHeader("Accept", "application/json");

            return request;
        }

        public RestRequest CreatePostRequest(string payload)
        {
            var request = new RestRequest("api/users", Method.Post);

            request.AddHeader("Accept", "application/json");

            request.AddParameter("application/json", payload, ParameterType.RequestBody);

            return request;
        }

        public RestRequest CreatePutRequest(string payload)
        {
            var request = new RestRequest("api/users/2", Method.Put);

            request.AddHeader("Accept", "application/json");

            request.AddParameter("application/json", payload, ParameterType.RequestBody);

            return request;
        }

        public RestRequest CreateDeleteRequest()
        {
            var request = new RestRequest("api/users/2", Method.Delete);
            request.AddHeader("Accept", "application/json");

            return request;
        }

        public RestResponse GetResponse(RestClient client, RestRequest request)
        {
            return client.Execute(request);
        }

        public DTO GetContent<DTO>(RestResponse response)
        {
            var content = response.Content;

            return JsonConvert.DeserializeObject<DTO>(content);
        }
    }
}
