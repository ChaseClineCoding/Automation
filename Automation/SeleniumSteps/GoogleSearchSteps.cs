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

        public GoogleSearchSteps(IWebDriver driver)
        {
            _driver = driver;
        }

        [Given(@"a user who is on the google homepage")]
        public void GivenAUserWhoIsOnTheGoogleHomepage()
        {
            _driver.Navigate().GoToUrl("https://google.com");
        }
        
        [When(@"the user searches for (.*)")]
        public void WhenTheUserSearchesFor(string input)
        {
            var searchbar = _driver.FindElement(By.Name("q"));
            searchbar.SendKeys(input);
            searchbar.Submit();
        }
        
        [Then(@"the user should be redirected to a page of search results for (.*)")]
        public void ThenTheUserShouldBeRedirectedToAPageOfSearchResults(string input)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.Title.StartsWith(input, StringComparison.OrdinalIgnoreCase));
        }
    }
}
