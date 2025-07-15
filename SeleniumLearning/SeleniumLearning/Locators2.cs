using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumLearning
{
    public class Locators2
    {
        private IWebDriver _driver;

        [SetUp]
        public void StartBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            _driver = new ChromeDriver();
            
            _driver.Manage().Window.Maximize();
            
            _driver.Url = "https://www.geeksforgeeks.org/dsa/singly-linked-list-tutorial/";
        }

        [Test]
        public void LocatorsIdentification2()
        {
            IWebElement mainSignInButton = _driver.FindElement(By.Id("userProfileId"));
            mainSignInButton.Click();
            
            IWebElement usernameSpace = _driver.FindElement(By.Id("luser"));
            usernameSpace.SendKeys("mikayel123");
            
            IWebElement passwordSpace = _driver.FindElement(By.Id("password"));
            passwordSpace.SendKeys("123456");
            
            // driver.FindElement(By.CssSelector("input[value='Sign In']")).Click();
            IWebElement signInButton = _driver.FindElement(By.CssSelector("input[class='btn-green']"));
            signInButton.Click();
            
            Thread.Sleep(7000);

        }

        [TearDown]
        public void CloseBrowser()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}
