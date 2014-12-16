Feature: Bing Search
 As an end user,
 I would like to visit the bing search page
 And then I would like to search an item so that
 I can view the search results

Scenario: Bing Search
	Given I go to the 'http://www.bing.com' screen
	And I type 'BDD' into 'sb_form_q'
	When I click the button with 'id' 'sb_form_go'
	Then the title of the page should start with 'BDD'