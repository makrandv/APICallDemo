Software Requirements : 

OS : Windows 7 or later
.Net Framework : 4.6.1 or later

Application as IDE : Visual Studio 2017 - Community Edition

Nuget Packages Installed
1. "Newtonsoft.Json" version="12.0.1" 
2. "NUnit" version="3.11.0"
3. "NUnit3TestAdapter" version="3.12.0"
4. "SpecFlow" version="2.4.1"
5. "System.ValueTuple" version="4.3.0"

Scripting Language : C#

Test Strategy : 
The test case is written in Business Driver Development(BDD) format with the acceptance criteria written test in gherkin format.

Project Folder Structure :

- APIClientFiles 
			|
			+--> APIClient.cs : This files contains implementation of the methods used to call requested API and read the response from the API.
			|
			+--> RootObject.cs : This file contains class definition for the serialized object created after converting the JSON response of the API to C# object.
			
- FeatureFiles
			|
			+--> APIResponse.Feature : This file contains test scenario in the gherkin syntax.

- StepDefinitions
			|
			+--> APIResponseStepDefinitions.cs : This file implements the gherkin statements added to the feature file to call the verification methods

- ValidationLogic
			|
			+--> VerifyAPIResponse.cs :  This file implements verification methods which compares the 
									     expected values of the parameters with actual values of the parameters in the response.

- packages.config : This file lists are the nuget packages added to project

- App.Config : This file defines configuration added to the project (e.g. reference to Specflow configuration)


Test Exeuction : 

1. From Visual Studio :
	a. Open the solution file "APICallDemo.sln" in Visual Studio.
	b. Build the solution from Visual Studio
	c. Click "Test >> Windows" menu and select "Test Explorer" menu item
	d. On the Test Explorer windows , Select "APICallDemo" test 
	e. Right click on the "APICallDemo" test and select "Run Selected Tests" option
	f. Test should run successfully and show the result
	
	Alternatively, open the "APIResponse.Feature" and Right click on editor window select "Run SpecFlow Scenarios" option to run the test. 