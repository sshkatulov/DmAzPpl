using Aquality.Selenium.Browsers;
using RestSharp;
using System;
using System.Net;

namespace FWL.Framework.API
{
    public abstract class BaseApiClient
    {
        protected RestClient RestClient;
        protected string AuthToken;

        protected BaseApiClient(string baseUri, string authToken = null)
        {
            AuthToken = authToken;
            RestClient = new RestClient(baseUri);
        }

        public IRestResponse SendAndGetResponse(RestRequest request, HttpStatusCode? expectedHttpStatusCode = null)
        {
            IRestResponse response = null;

            AqualityServices.ConditionalWait.WaitForTrue(() =>
            {
                response = RestClient.Execute(request);
                return expectedHttpStatusCode == null || expectedHttpStatusCode == response?.StatusCode;
            }, TimeSpan.FromMilliseconds(10000), TimeSpan.FromMilliseconds(1000),
            $"Waiting for response status code: {expectedHttpStatusCode}");

            return response;
        }
    }
}