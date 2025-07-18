using RestSharp;
using RestSharpAutomation.HelperClass.Request;

namespace RestSharpAutomation.RestGetEndpoint
{
    [TestClass]
    public class TestGetEndpoint
    {
        private string _url = "https://petstore.swagger.io/v2/pet/findByStatus?status=available&status=pending&status=sold";
        
        [TestMethod]
        public void TestGetUsingRestSharp()
        {
            IRestClient client = new RestClient();
            IRestRequest request = new RestRequest(_url);
            
            // request.AddHeader("Accept", "application/json");
            
            IRestResponse response = client.Get(request);
            
            /*
            Console.WriteLine(response.IsSuccessful);
            Console.WriteLine(response.StatusCode);
            Console.WriteLine((int)response.StatusCode);
            Console.WriteLine(response.ErrorMessage);
            Console.WriteLine(response.ErrorException);
            */

            if (response.IsSuccessful)
            {
                Console.WriteLine($"Status Code: {(int)response.StatusCode}");
                Console.WriteLine($"Response Content: {response.Content}");
            }
        }

        [TestMethod]
        public void TestGetInXml()
        {
            IRestClient client = new RestClient();
            IRestRequest request = new RestRequest(_url);
            
            request.AddHeader("Accept", "application/xml");
            
            IRestResponse response = client.Get(request);

            if (response.IsSuccessful)
            {
                Console.WriteLine($"Status Code: {(int)response.StatusCode}");
                Console.WriteLine($"Response Content: {response.Content}");
            }
        }
        
        [TestMethod]
        public void TestGetInJson()
        {
            IRestClient client = new RestClient();
            IRestRequest request = new RestRequest(_url);
            
            request.AddHeader("Accept", "application/json");
            
            IRestResponse response = client.Get(request);

            if (response.IsSuccessful)
            {
                Console.WriteLine($"Status Code: {(int)response.StatusCode}");
                Console.WriteLine($"Response Content: {response.Content}");
            }
        }

        [TestMethod]
        public void TestGetWithXMLUsingHelperClass()
        {
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                {"Accept", "application/xml" }
            };

            RestClientHelper helper = new RestClientHelper();
            IRestResponse response = helper.PerformGetRequest( _url, headers );

            Assert.AreEqual(200, (int)response.StatusCode);
            Assert.IsNotNull(response.Content, "Content is Null/Empty");

            
        }
    }
}