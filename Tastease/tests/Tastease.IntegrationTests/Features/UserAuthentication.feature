Feature: User Authentication

@Authentication
Scenario: guest user creates an account
	Given unique unregistered email and password
	When user clicks the submit button
	Then the user is registered 
    And the user can see that they are verified

@Authentication
Scenario: guest user enters already existing email when creating a new account
	When user enters existing credentials
	Then the user is notified that the email is registered 

@Authentication
Scenario: guest user logs into an account
	Given guest user
	When the guest user provides preexisting email and password
	Then the user is authenticated 
    And has access to view user information