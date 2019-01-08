using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace APICallDemo.StepDefinitions
{
    /// <summary>
    /// This binding class defines the implementation to each of the gherkin style statements used in the feature file
    /// </summary>
    [Binding]
    public class APIResponseStepDefinitions
    {
        RootObject deserializedProduct;

        /// <summary>
        /// Method which calls the API URL and read the response
        /// </summary>
        /// <param name="pApiurl">API URL to be called</param>
        [When(@"I make call to Product API using the URL ""(.*)""")]
        public void WhenIMakeCallToProductAPIUsingTheURL(string pApiurl)
        {
            string output = "";
            output = APIClient.ReturnResponse(pApiurl).Result;

            //Serializing the Json output of the API call to a RootObject class instance
            deserializedProduct = JsonConvert.DeserializeObject<RootObject>(output);
        }

        /// <summary>
        /// Verify if the element\parameter in the response has the expected value 
        /// </summary>
        /// <param name="parameterToBeChecked">Element\Parameter in the response to be verified</param>
        /// <param name="compareCondition">Compare condition (equals  or contains)</param>
        /// <param name="expectedParameterValue">Expected value of the parameter</param>
        [When(@"I verify response has parameter ""(.*)"" with the value ""(.*)"" to ""(.*)""")]
        public void ThenIVerifyResponseHasParameterWithTheValueTo(string parameterToBeChecked, string compareCondition, string expectedParameterValue)
        {
            //Get the actual parameter value in the response from the deserialzed response object
            //Used GetType and GetProperty method to make implementation generic irrespective of the parameter passed for verification.
            string actualElementValue = deserializedProduct.GetType().GetProperty(parameterToBeChecked).GetValue(deserializedProduct).ToString();

            //Comparing actual value of the response with expected value
            Assert.IsTrue(VerifyAPIResponse.VerifyParameterValue(expectedParameterValue, compareCondition, actualElementValue));
        }

        /// <summary>
        /// Verify if the given list object in the response has the elements with expected values
        /// </summary>
        /// <param name="listObject">List Object to be verified</param>
        /// <param name="parameterList">Parameters in the list object to be verified</param>
        /// <param name="compareConditions">Compare condition (equals  or contains)</param>
        /// <param name="expectedParameterValues">Expected parameter values</param>
        [When(@"I verify response has '(.*)' listitem with one item having '(.*)' with '(.*)' and values '(.*)'")]
        public void WhenIVerifyResponseHasListitemWithOneItemHavingWithAndValues(string listObject, string parameterList, string compareConditions, string expectedParameterValues)
        {
            //Get the list object in the response from the deserialzed response object
            object elementListObj = deserializedProduct.GetType().GetProperty(listObject).GetValue(deserializedProduct);

            //Converting list object into a generic object
            List<object> result = ((IEnumerable)elementListObj).Cast<object>().ToList();

            //Comparing actual value of the required parameters in the response with their expected values
            Assert.IsTrue(VerifyAPIResponse.VerifyParameterListValue(listObject, result.ToArray(), parameterList, compareConditions, expectedParameterValues));
        }

    }

}
