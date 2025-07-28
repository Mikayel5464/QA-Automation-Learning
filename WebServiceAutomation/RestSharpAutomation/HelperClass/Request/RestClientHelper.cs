using Newtonsoft.Json;
using RestSharp;

namespace RestSharpAutomation.HelperClass.Request
{
    public class RestClientHelper
    {
        private RestClient GetRestClient()
        {
            RestClient client = new RestClient();

            return client;
        }

        private RestRequest GetRestRequest(string url, Dictionary<string, string> headers, Method method)
        {
            RestRequest request = new RestRequest()
            {
                Method = method,
                Resource = url
            };

            foreach (string key in headers.Keys)
            {
                request.AddHeader(key, headers[key]);
            }
            
            return request;
        }

        private RestResponse SendRequest(RestRequest request)
        {
            IRestClient client = GetRestClient();
            RestResponse response = client.Execute(request);
            
            return response;
        }

        private RestResponse<T> SendRequest<T>(RestRequest request) where T : new()
        {
            RestClient client = GetRestClient();
            RestResponse<T> response = client.Execute<T>(request);

            if (response.ContentType == "application/xml")
            {
                var content = response.Content;
                return (RestResponse<T>)JsonConvert.DeserializeObject(content);

                // var deserializer = new RestSharp.Deserializers.DotNetXmlDeserializer();
                // response.Data = deserializer.Deserialize<T>(response);
            }
            
            return response;
        }

        public RestResponse PerformGetRequest(string url, Dictionary<string, string> headers)
        {
            RestRequest request = GetRestRequest(url, headers, Method.Get);
            RestResponse response = SendRequest(request);

            return response;
        }
        
        public RestResponse<T> PerformGetRequest<T>(string url, Dictionary<string, string> headers)  where T : new()
        {
            RestRequest request = GetRestRequest(url, headers, Method.Get);
            RestResponse<T> response = SendRequest<T>(request);

            return response;
        }
    }
}
