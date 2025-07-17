using System.Net;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using WebServiceAutomation.Model;

namespace WebServiceAutomation.GetEndpoint
{
    [TestClass]
    public class TestGetEndpoint
    {
        private string _getUrl = "https://petstore.swagger.io/v2/store/inventory";
            // "https://petstore.swagger.io/v2/pet/findByStatus?status=available&status=pending&status=sold";
        // "http://localhost:8080/laptop-bag/webapi/api/all"; 

        [TestMethod]
        public void TestGetAllEndpoint()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.GetAsync(_getUrl);
            httpClient.Dispose();
        }

        [TestMethod]
        public void TestGetAllEndpointWithUri()
        {
            // Creating the HTTP client
            HttpClient httpClient = new HttpClient();

            // Creating the request
            Uri getUri = new Uri(_getUrl);
            Task<HttpResponseMessage> httpResponse = httpClient.GetAsync(getUri);
            HttpResponseMessage responseMessage = httpResponse.Result;

            // Status Code
            // HttpStatusCode statusCode = responseMessage.StatusCode;
            // Console.WriteLine($"Status Code as text: {statusCode}");
            // Console.WriteLine($"Status Code as number: {(int)statusCode}");

            // 1st checkpoint(assertion) for Status Code
            Assert.AreEqual(200, (int)responseMessage.StatusCode);

            // 2nd checkpoint(assertion) for response data
            Assert.IsNotNull(responseMessage.Content);

            // Console.WriteLine(responseMessage.ToString());

            // Response Data
            HttpContent responseContent = responseMessage.Content;
            Task<string> responseData = responseContent.ReadAsStringAsync();
            string data = responseData.Result;
            // Console.WriteLine(data);

            httpClient.Dispose();
        }

        [TestMethod]
        public void TestGetAllEndpointInJsonFormat()
        {
            HttpClient httpClient = new HttpClient();
            HttpRequestHeaders requestHeaders = httpClient.DefaultRequestHeaders;

            requestHeaders.Add("Accept", "application/json");

            Task<HttpResponseMessage> httpResponse = httpClient.GetAsync(_getUrl);
            HttpResponseMessage responseMessage = httpResponse.Result;

            HttpContent responseContent = responseMessage.Content;
            Task<string> responseData = responseContent.ReadAsStringAsync();
            string data = responseData.Result;
            Console.WriteLine(data);

            httpClient.Dispose();
        }

        [TestMethod]
        public void TestGetAllEndpointInXmlFormat()
        {
            HttpClient httpClient = new HttpClient();
            HttpRequestHeaders requestHeaders = httpClient.DefaultRequestHeaders;

            requestHeaders.Add("Accept", "application/xml");

            Task<HttpResponseMessage> httpResponse = httpClient.GetAsync(_getUrl);
            HttpResponseMessage responseMessage = httpResponse.Result;

            HttpContent responseContent = responseMessage.Content;
            Task<string> responseData = responseContent.ReadAsStringAsync();
            string data = responseData.Result;
            Console.WriteLine(data);

            httpClient.Dispose();
        }

        [TestMethod]
        public void TestGetAllEndpointInJsonFormatUsingAcceptHeader()
        {
            MediaTypeWithQualityHeaderValue jsonHeader = new MediaTypeWithQualityHeaderValue("application/json");

            HttpClient httpClient = new HttpClient();
            HttpRequestHeaders requestHeaders = httpClient.DefaultRequestHeaders;
            requestHeaders.Accept.Add(jsonHeader);

            Task<HttpResponseMessage> httpResponse = httpClient.GetAsync(_getUrl);
            HttpResponseMessage responseMessage = httpResponse.Result;

            HttpContent responseContent = responseMessage.Content;
            Task<string> responseData = responseContent.ReadAsStringAsync();
            string data = responseData.Result;
            Console.WriteLine(data);

            httpClient.Dispose();
        }

        [TestMethod]
        public void TestGetEndpointUsingSendAsync()
        {
            HttpRequestMessage requestMessage = new HttpRequestMessage();
            requestMessage.RequestUri = new Uri(_getUrl);
            requestMessage.Method = HttpMethod.Get;
            requestMessage.Headers.Add("Accept", "application/json");
            
            HttpClient client = new HttpClient();
            Task<HttpResponseMessage> response = client.SendAsync(requestMessage);
            
            HttpResponseMessage responseMessage = response.Result;
            Console.WriteLine(responseMessage.ToString());
            
            HttpStatusCode statusCode = responseMessage.StatusCode;
            Console.WriteLine($"Status Code: {(int)statusCode}");

            HttpContent responseContent = responseMessage.Content;
            Task<string> responseData = responseContent.ReadAsStringAsync();
            string data = responseData.Result;
            Console.WriteLine(data);

            client.Dispose();
        }

        [TestMethod]
        public void TestUsingStatement()
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpRequestMessage requestMessage = new HttpRequestMessage())
                {
                    requestMessage.RequestUri = new Uri(_getUrl);
                    requestMessage.Method = HttpMethod.Get;
                    requestMessage.Headers.Add("Accept", "application/json");
                    
                    Task<HttpResponseMessage> response = client.SendAsync(requestMessage);

                    using (HttpResponseMessage responseMessage = response.Result)
                    {
                        Console.WriteLine(responseMessage.ToString());
            
                        HttpStatusCode statusCode = responseMessage.StatusCode;
                        Console.WriteLine($"Status Code: {(int)statusCode}");

                        HttpContent responseContent = responseMessage.Content;
                        Task<string> responseData = responseContent.ReadAsStringAsync();
                        string data = responseData.Result;
                        Console.WriteLine(data);

                        RestResponse restResponse = new RestResponse((int)statusCode, data);
                        Console.WriteLine(restResponse.ToString());

                        // List<JsonRootObject> jsonRootObject = JsonConvert.DeserializeObject<List<JsonRootObject>>(restResponse.ResponseContent);
                        // Console.WriteLine(jsonRootObject[0].ToString());
                    }
                }
            }
        }

        [TestMethod]
        public void TestDeserializationOfJsonResponse()
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpRequestMessage requestMessage = new HttpRequestMessage())
                {
                    requestMessage.RequestUri = new Uri(_getUrl);
                    requestMessage.Method = HttpMethod.Get;
                    requestMessage.Headers.Add("Accept", "application/json");
                    
                    Task<HttpResponseMessage> response = client.SendAsync(requestMessage);

                    using (HttpResponseMessage responseMessage = response.Result)
                    {
                        Console.WriteLine(responseMessage.ToString());
            
                        HttpStatusCode statusCode = responseMessage.StatusCode;
                        Console.WriteLine($"Status Code: {(int)statusCode}");

                        HttpContent responseContent = responseMessage.Content;
                        Task<string> responseData = responseContent.ReadAsStringAsync();
                        string data = responseData.Result;

                        RestResponse restResponse = new RestResponse((int)statusCode, data);

                        JsonRootObject jsonRootObject = JsonConvert.DeserializeObject<JsonRootObject>(restResponse.ResponseContent);
                        Console.WriteLine(jsonRootObject.ToString());
                    }
                }
            }
        }
    }
}
