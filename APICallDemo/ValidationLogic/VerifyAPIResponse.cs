namespace APICallDemo
{
    /// <summary>
    /// Class with methods which compares required parameter values in API Response with expected values
    /// </summary>
    public class VerifyAPIResponse
    {
        /// <summary>
        /// Verification method which compares given required parameters value in the given list object of the response with
        /// expected parameter value
        /// </summary>
        /// <param name="parameterListObject">Name of list Object with parameter in the API Response</param>
        /// <param name="parameterValuePairsList">List of Objects with parameter</param>
        /// <param name="parameters">Parameters with values to be compared</param>
        /// <param name="compareCondition">Compare Condition (equals or contains)</param>
        /// <param name="parameterValues">Expected values of the parameters</param>
        /// <returns></returns>
        public static bool VerifyParameterListValue(string parameterListObject, object[] parameterValuePairsList, string parameters, string compareCondition, string parameterValues)
        {
            bool bparameterVerified = false;

            //Get list of the individual parameters,compare conditions and their respective parameter values   
            string[] parametersArray = parameters.Split(',');
            string[] compareConditionArray = compareCondition.Split(',');
            string[] parameterValuesArray = parameterValues.Split(',');

            //Traversing through all the list object passed till object containing required parameters with their expected value is found
            //else return false if object in the list is not found.
            foreach (object parameterObjInstance in parameterValuePairsList)
            {
                bool bfound = true;
                int iCnt = 0;

                //Comparing each passed parameter in the each object instance and comparing it's value with expected value
                foreach (string parameter in parametersArray)
                {
                    //Check if the present object instance has the required parameter as it's member or property
                    if (parameterObjInstance.GetType().GetProperty(parametersArray[iCnt]) != null)
                    {
                        //Fetch the value of the parameter from the current object instance
                        string actualParameterValue = parameterObjInstance.GetType().GetProperty(parametersArray[iCnt]).GetValue(parameterObjInstance).ToString();
                        string expectedParameterValue = parameterValuesArray[iCnt].ToString();

                        //Comparing the parameter result and appending it with previous compared parameter value result
                        bfound = bfound && VerifyParameterValue(expectedParameterValue, compareConditionArray[iCnt], actualParameterValue);
                    }
                    else
                    {
                        //set the comparision result as false and break loop to fetch next object instance from the list
                        bfound = false;
                        break;
                    }

                    //Increment to move to compare with next parameter in the list
                    iCnt++;
                }

                //if the required Object instance is found , then set the verification result as True 
                //and break the loop to end the loop execution
                if (bfound)
                {
                    bparameterVerified = bfound;
                    break;
                }
            }

            //return the final comparision result
            return bparameterVerified;
        }

        /// <summary>
        /// Verification method which compares actual parameter value with expected parameter value using comparison
        /// operator i.e. equals or contains
        /// </summary>
        /// <param name="expectedParameterValue">Expected parameter value</param>
        /// <param name="conditionCompare">equals or contains</param>
        /// <param name="actualParameterValue">Actual value of the parameter</param>
        /// <returns>True/False</returns>
        public static bool VerifyParameterValue(string expectedParameterValue, string conditionCompare, string actualParameterValue)
        {
            bool bparameterVerified = false;

            if (conditionCompare.Equals("equals"))
            {

                if (actualParameterValue.ToString().Equals(expectedParameterValue.ToString()))
                {
                    bparameterVerified = true;
                }
            }
            else
            {
                if (actualParameterValue.ToString().Contains(expectedParameterValue.ToString().Trim()))
                {

                    bparameterVerified = true;
                }
            }

            return bparameterVerified;
        }
    }
}
