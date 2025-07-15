using OpenQA.Selenium;

namespace FirstApplication_hometask.Pages.Impl
{
    public class HomePage(IWebDriver driver) : WebPage(driver)
    {
        private IWebElement SearchBox =>
            FindElement(By.XPath("//*[@id=\"twotabsearchtextbox\"]"));

        public void PerformSearch(string searchPhrase)
        {
            SearchBox.Click();
            SearchBox.SendKeys(searchPhrase);
            SearchBox.SendKeys(Keys.Enter);
        }
    }
}
