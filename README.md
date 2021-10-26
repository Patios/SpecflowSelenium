## *Resources**
- [Selenium](http://www.seleniumhq.org/)
- [SpecFlow](http://specflow.org/)
- [FluentAssertions](https://fluentassertions.com/)


## Visual Studio 2019

Visual Studio needs a little extra configuration. Install these extensions;

- SpecFlow
- Cucumber
- Resharper optionally

## Run tests from this repo

Run 
```  
dotnet test
```  
(in your console in path with .csproj) you need to have .NET Core on your computer

## appsettings.json - possible to change default values

## Supported browsers
- Chrome
- Firefox

## Generating with test results

Note : You must have the LivingDoc Plugin Setup to generate LivingDoc with test results.

Here are the list of commands to use to quickly generate LivingDoc with test results from different sources which you have stored your feature file data:

Generate the Living Documentation from SpecFlow test assembly:

livingdoc test-assembly C:\Work\MyProject.Specs\bin\Debug\netcoreapp3.1\MyProject.Specs.dll -t C:\Work\MyProject.Specs\bin\debug\netcoreapp3.1\TestExecution.json


λ livingdoc test-assembly .\AutomationTestFramework.Tests.Confluence.dll -t .\TestExecution.json