using FirstApplication_hometask.Pages.Impl;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace FirstApplication_hometask
{
    public class AmazonWebpageHometask
    {
        private static IWebDriver _driver;
        private readonly string _searchPhrase = "iphone";

        [OneTimeSetUp]
        public static void SetUpWebDriver()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            _driver = new ChromeDriver();

            _driver.Manage().Window.Maximize();
        }

        [Test]
        public void AmazonSearch()
        {
            _driver.Navigate().GoToUrl("https://www.amazon.com/");

            var homePage = new HomePage(_driver);
            homePage.PerformSearch(_searchPhrase);

            var searchResultsPage = new SearchResultsPage(_driver);
            IList<string> actualItems = searchResultsPage.SearchResultsItemsText();

            IList<string> expectedItems = actualItems
                .Where(item => item.Contains(_searchPhrase))
                .ToList();

            Assert.That(expectedItems, Is.EqualTo(actualItems));
        }

        [OneTimeTearDown]
        public static void CloseBrowser()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}
