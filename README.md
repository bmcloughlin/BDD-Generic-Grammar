BDD-Generic-Grammar
===================

A generic set of Specflow steps to automate acceptance criteria testing.

What is this Project?
=====================

The purpose of this project is to build a generic set of steps i.e. a grammar which development teams can use to build their acceptances tests.  The acceptance tests are written using Gherkin and executed using Specflow.  UI automation is handled using Selenium Web Drivers.  Autofac is used for Dependency Injection.

The following is an example of using the grammar to perform a simple search on Bing.

```
Feature: Bing Search
 As an end user,
 I would like to visit the bing search page
 And then I would like to search an item so that
 I can view the search results

Scenario: Bing Search
	Given I go to the http://www.bing.com screen
	And I type BDD into sb_form_q
	When I click the button with id sb_form_go
	Then the title of the page should start with BDD
```

Useful Links
=====================
- http://www.seleniumhq.org/
- http://docs.seleniumhq.org/projects/webdriver/
- http://www.specflow.org/
- http://cukes.info/gherkin.html
- http://autofac.org/
