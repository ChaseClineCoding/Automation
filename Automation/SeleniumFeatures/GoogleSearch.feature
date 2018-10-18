Feature: GoogleSearch
	As a google user
	I want to be able to search the web for relevant information

@searchbar
Scenario: Use the search bar
	Given a user who is on the google homepage
	When the user searches for SpecFlow
	Then the user should be redirected to a page of search results for SpecFlow

	@searchbar
Scenario: Use the search bar 1
	Given a user who is on the google homepage
	When the user searches for something
	Then the user should be redirected to a page of search results for something