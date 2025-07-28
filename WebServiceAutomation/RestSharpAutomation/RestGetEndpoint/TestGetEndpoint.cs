using RestSharp;
using RestSharpAutomation.HelperClass.Request;

namespace RestSharpAutomation.RestGetEndpoint
{
    [TestClass]
    public class TestGetEndpoint
    {
        private string _getUrl = "https://reqres.in/api/users?page=2";
        
        [TestMethod]
        public void TestGetUsingRestSharp()
        {
            RestClient client = new RestClient();
            RestRequest request = new RestRequest(_getUrl);
            
            // request.AddHeader("Accept", "application/json");
            
            RestResponse response = client.Get(request);
            
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
    }
}

/*
 [TestMethod]
        public void TestGetInXml()
        {
            RestClient client = new RestClient();
            RestRequest request = new RestRequest(_getUrl);
            
            request.AddHeader("Accept", "application/xml");
            
            RestResponse response = client.Get(request);

            if (response.IsSuccessful)
            {
                Console.WriteLine($"Status Code: {(int)response.StatusCode}");
                Console.WriteLine($"Response Content: {response.Content}");
            }
        }
        
        [TestMethod]
        public void TestGetInJson()
        {
            RestClient client = new RestClient();
            RestRequest request = new RestRequest(_getUrl);
            
            request.AddHeader("Accept", "application/json");
            
            RestResponse response = client.Get(request);

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
            RestResponse response = helper.PerformGetRequest(_getUrl, headers );

            Assert.AreEqual(200, (int)response.StatusCode);
            Assert.IsNotNull(response.Content, "Content is Null/Empty");
        }
 */
