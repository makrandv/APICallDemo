Feature: API Response Check
#This feature is used check values of different parameters in the response of the API call

@APIResponseCheck
Scenario Outline: Verify parameter values in the response of a API Call 
	When I make call to Product API using the URL "https://api.tmsandbox.co.nz/v1/Categories/6327/Details.json?catalogue=false"
	And I verify response has parameter "Name" with the value "equals" to "Carbon credits"
	And I verify response has parameter "CanRelist" with the value "equals" to "True"
	And I verify response has '<List>' listitem with one item having '<parameters>' with '<conditions>' and values '<parametervalue>'

	Examples: 
	|List      | parameters      | conditions     | parametervalue          |
	|Promotions| Name,Description| equals,contains| Gallery, 2x larger image|
