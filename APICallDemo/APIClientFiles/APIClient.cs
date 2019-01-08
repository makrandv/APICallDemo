using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

namespace APICallDemo
{
    /// <summary>
    /// This class has methods which calls the requested API using the specified URL 
    /// and reads the response message returned from the requested API
    /// </summary>
    public class APIClient
    {
        /// <summary>
        /// Method calls the API using the provided URL and reads the response and returns it to the calling function.
        /// Method uses asynchronous call as it needs to call API over web using HTTP protocol.
        /// </summary>
        /// <param name="url">API URL</param>
        /// <returns>Response of the API call in the string format</returns>
        public static async Task<string> ReturnResponse(string url)
        {
            //Create a HTTPClient to call the API using the provided URL
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);

                client.DefaultRequestHeaders.Accept.Clear();

                //Get the response in Json format
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                //Wait untill the GetAsync method provides the HTTP response
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    //Once the response code is successful ,read the content of the response message 
                    //and await till the response is read completely

                    string strResult = await response.Content.ReadAsStringAsync();

                    return strResult;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
