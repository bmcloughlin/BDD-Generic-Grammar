Feature: RegisterUser
	In order to use the sample app
	As an authenticated user
	I want to register with the sample app

Background: 
	Given I go to the Register User screen
	Then the title of the page should start with Register

Scenario: Mandatory validation of Email fails
	When I click the Register button
	Then a validation message is displayed with the message The Email field is required.

Scenario: Format validation of Email fails
	Given I type badlyformattedemail into Email
	When I click the Register button
	Then a validation message is displayed with the message The Email field is not a valid e-mail address.

Scenario: Mandatory validation of Password fails
	Given I type bmcloughlin@gmail.com into Email
	When I click the Register button
	Then a validation message is displayed with the message The Password field is required.

Scenario: Length validation of Password fails
	Given I type bmcloughlin@gmail.com into Email
		And I type Pass into Password
	When I click the Register button
	Then a validation message is displayed with the message The Password must be at least 6 characters long.

Scenario: Confirmation validation of Password fails
	Given I type bmcloughlin@gmail.com into Email
		And I type Password123 into Password
		And I type Password456 into ConfirmPassword
	When I click the Register button
	Then a validation message is displayed with the message The password and confirmation password do not match.

Scenario: Strength validation of Password fails
	Given I type bmcloughlin@gmail.com into Email
		And I type Password123 into Password
		And I type Password123 into ConfirmPassword
	When I click the Register button
	Then a validation message is displayed with the message Passwords must have at least one non letter or digit character.


Scenario: Successful Registration
	Given I type autotest.uniquevalue@gmail.com into Email
		And I type Password123_ into Password
		And I type Password123_ into ConfirmPassword
	When I click the Register button
	Then the title of the page should start with Home Page
	

Scenario: Already taken validation of Email fails
	Given I add autotest.uniquevalue@gmail.com to the cache as email for reuse
		And I type cache.email into Email
		And I type Password123_ into Password
		And I type Password123_ into ConfirmPassword
	When I click the Register button
		And  I click the Log off link
		And  I click the Register link
		And I type cache.email into Email
		And I type Password123_ into Password
		And I type Password123_ into ConfirmPassword
		And I click the Register button
	Then a validation message is displayed where the message ends with is already taken.

