using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace Automation
{
    [Binding]
    public class GoogleSearchSteps
    {
        private readonly IWebDriver _driver;
        private string _searchCriteria;

        public GoogleSearchSteps(IWebDriver driver, FieldData fieldData)
        {
            _driver = driver;
            _searchCriteria = fieldData.SearchCriteria;
        }

        [Given(@"a user who is on the google homepage")]
        public void GivenAUserWhoIsOnTheGoogleHomepage()
        {
            _driver.Navigate().GoToUrl("https://google.com");
        }
        
        [When(@"the user searches for (.*)")]
        public void WhenTheUserSearchesFor(string input)
        {
            _searchCriteria = input;
            var searchbar = _driver.FindElement(By.Name("q"));
            searchbar.SendKeys(_searchCriteria);
            searchbar.Submit();
        }
        
        [Then(@"the user should be redirected to a page of relevant search results")]
        public void ThenTheUserShouldBeRedirectedToAPageOfRelevantSearchResults()
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.Title.StartsWith(_searchCriteria, StringComparison.OrdinalIgnoreCase));
        }
    }
}
