Feature: Private and public steps

Scenario: Private steps
	When I have a private step
	Then it is not accessible for other projects

Scenario: Public steps
	When I have a public step
	Then it is accessible for other projects
	