using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace FirstApplication_hometask.Pages
{
    public class WebPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public WebPage(IWebDriver driver)
        {
            this._driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
        }

        protected IWebElement FindElement(By selector) =>
            _driver.FindElement(selector);

        protected IList<IWebElement> FindElements(By selector) =>
            _driver.FindElements(selector);

        protected void WaitForElementVisibility(By selector)
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
            _wait.Until(d => _driver.FindElements(selector));
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }
    }
}
