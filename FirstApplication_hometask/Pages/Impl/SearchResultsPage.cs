using OpenQA.Selenium;

namespace FirstApplication_hometask.Pages.Impl
{
    public class SearchResultsPage(IWebDriver driver) : WebPage(driver)
    {
        private static readonly By SearchResultsItemsCss =
            By.CssSelector("[data-component-type='s-search-result'] h2 .a-link-normal");

        private IList<IWebElement> SearchResultsItems =>
            FindElements(SearchResultsItemsCss);

        public IList<string> SearchResultsItemsText()
        {
            WaitForElementVisibility(SearchResultsItemsCss);

            return SearchResultsItems
                .Select(item => item.Text.ToLower())
                .ToList();
        }
    }
}
