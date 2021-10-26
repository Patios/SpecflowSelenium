Feature: LoginToConfluenceRestrictedValidationTest
	

@confluence
Scenario: Login to confluance page and verify restricted page for user scenario
	Given Navigate to Login Page to Put Credentials
	And Fill Login Form as username 'patios18@gmail.com' with password 'Test1234!' successfully
	And User Logged To Confluence Dashboard
	And Go to restricted pages and check Page name: "QA Workshop - Restricted for Tester2" has enabled restrictions
	And Close Restrictions Menu
	Then Logout
	Given Navigate to Login Page to Put Credentials
	And Fill Login Form as username 'patiosmac@gmail.com' with password 'Test1234!' successfully
	And User Logged To Confluence Dashboard
	And Go to pages and check list of available user pages
	And Page name : "QA Workshop - Restricted for Tester2" is not displayed.
	Then Logout