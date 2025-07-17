using RestSharp;

namespace RestSharpAutomation.HelperClass.Request
{
    public class RestClientHelper
    {
        private IRestClient GetRestClient()
        {
            IRestClient client = new RestClient();

            return client;
        }

        private IRestRequest GetRestRequest(string url, Dictionary<string, string> headers, Method method)
        {
            IRestRequest request = new RestRequest()
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

        private IRestResponse SendRequest(IRestRequest request)
        {
            IRestClient client = GetRestClient();
            IRestResponse response = client.Execute(request);
            
            return response;
        }

        private IRestResponse<T> SendRequest<T>(IRestRequest request) where T : new()
        {
            IRestClient client = GetRestClient();
            IRestResponse<T> response = client.Execute<T>(request);

            if (response.ContentType == "application/xml")
            {
                var deserializer = new RestSharp.Deserializers.DotNetXmlDeserializer();
                response.Data = deserializer.Deserialize<T>(response);
            }
            
            return response;
        }

        public IRestResponse PerformGetRequest(string url, Dictionary<string, string> headers)
        {
            IRestRequest request = GetRestRequest(url, headers, Method.GET);
            IRestResponse response = SendRequest(request);

            return response;
        }
        
        public IRestResponse<T> PerformGetRequest<T>(string url, Dictionary<string, string> headers)  where T : new()
        {
            IRestRequest request = GetRestRequest(url, headers, Method.GET);
            IRestResponse<T> response = SendRequest<T>(request);

            return response;
        }
    }
}
