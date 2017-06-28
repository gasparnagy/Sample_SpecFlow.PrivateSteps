Feature: Consuming Steps

Scenario: Consuming public steps
	When I have a public step
	Then I should be able to use it here

Scenario: Consuming private steps (this should be undefined)
	When I have a private step
	Then I should not be able to use it here
