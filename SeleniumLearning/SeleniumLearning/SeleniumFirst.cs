using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumLearning
{
    public class SeleniumFirst
    {
        #pragma warning disable NUnit1032
        private IWebDriver driver;
        #pragma warning restore NUnit1032
        
        [SetUp]
        public void StartBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void Test1()
        {
            driver.Url = "https://rahulshettyacademy.com/#/index";
            
            TestContext.Progress.WriteLine(driver.Title);
            TestContext.Progress.WriteLine(driver.Url);
        }

        [TearDown]
        public void CloseBrowser()
        {
            /*
            if (driver != null)
            {
                driver.Quit();
                driver.Dispose();
            }
            */
        }
    }
}