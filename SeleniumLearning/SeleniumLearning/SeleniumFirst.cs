using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumLearning
{
    public class SeleniumFirst
    {
        private IWebDriver _driver;
        
        [SetUp]
        public void StartBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            _driver = new ChromeDriver();

            _driver.Manage().Window.Maximize();
        }

        [Test]
        public void Test1()
        {
            _driver.Url = "https://rahulshettyacademy.com/#/index";
            
            TestContext.Progress.WriteLine(_driver.Title);
            TestContext.Progress.WriteLine(_driver.Url);

            Thread.Sleep(3000);
        }

        [TearDown]
        public void CloseBrowser()
        {
            if (_driver != null)
            {
                _driver.Quit();
                _driver.Dispose();
            }
        }
    }
}