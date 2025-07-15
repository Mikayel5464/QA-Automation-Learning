using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumLearning
{
    public class Locators
    {
        private IWebDriver _driver;

        [SetUp]
        public void StartBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            _driver = new ChromeDriver();
            
            _driver.Manage().Window.Maximize();
            
            _driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
        }

        [Test]
        public void LocatorsIdentification()
        {
            IWebElement usernameSpace = _driver.FindElement(By.Id("username"));
            usernameSpace.SendKeys("admin");
            
            IWebElement passwordSpace = _driver.FindElement(By.Name("password"));
            passwordSpace.SendKeys("123456");
            
            IWebElement signInButton = _driver.FindElement(By.CssSelector("input[value='Sign In']"));
            signInButton.Click();
            
            // _driver.FindElement(By.XPath("//input[@value='Sign In']")).Click();
            
            Thread.Sleep(5000);

            string errorMessage = _driver.FindElement(By.ClassName("alert-danger")).Text;
            TestContext.Progress.WriteLine(errorMessage);

            IWebElement link = _driver.FindElement(By.LinkText("Free Access to InterviewQues/ResumeAssistance/Material"));
            var hrefAttr = link.GetAttribute("href");
            var expectedUrl = "https://rahulshettyacademy.com/#/documents-request";
        }

        [TearDown]
        public void CloseBrowser()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}
