using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIDemo
{
    public class APIHelper
    {
        private readonly string _url = "https://reqres.in";
        public RestClient client;
        public RestRequest request;

        public RestClient SetUrl(string endpoint)
        {
            var url = Path.Combine(_url, endpoint);
            var client = new RestClient(url);

            return client;
        }

        public RestRequest CreatePostRequest(string payload)
        {
            var request = new RestRequest(Method.Post);
            request.AddHeader("Accept", "application/json");

            request.AddParameter("application/json", payload, ParameterType.RequestBody);

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
