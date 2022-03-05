@Authentication 
Feature: Authenticate User
    As a guest user
    I would like to register myself to the application

Scenario: guest user enters the application
	Given guest user
	When they attmept to use the application 
	Then they presented with a register now panel
