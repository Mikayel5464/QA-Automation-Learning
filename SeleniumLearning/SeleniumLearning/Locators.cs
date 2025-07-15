using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
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

            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            
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

            IWebElement agreeButton = _driver.FindElement(By.XPath("//div[@class='form-group'][5]/label/span/input"));
            agreeButton.Click();

            IWebElement signInButton = _driver.FindElement(By.Id("signInBtn"));
            signInButton.Click();

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                .TextToBePresentInElementValue(signInButton, "Sign In"));

            string errorMessage = _driver.FindElement(By.ClassName("alert-danger")).Text;
            TestContext.Progress.WriteLine(errorMessage);

            IWebElement link = _driver.FindElement(By.LinkText("Free Access to InterviewQues/ResumeAssistance/Material"));
            var hrefAttr = link.GetAttribute("href");
            var expectedUrl = "https://rahulshettyacademy.com/documents-request";

            Assert.That(hrefAttr, Is.EqualTo(expectedUrl));
        }

        [TearDown]
        public void CloseBrowser()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}
