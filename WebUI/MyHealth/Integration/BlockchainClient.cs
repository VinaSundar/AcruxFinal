using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RestSharp;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Linq;


namespace MyHealth.Integration
{
    public static class BlockchainClient
    {
        private const string baseHlServerUrl = "http://hyperacrux.eastus.cloudapp.azure.com:3000/api/";
        private const string getByIdFormat = "{0}/{1}";

        private static RestClient GetRestClient()
        {
            JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            RestClient restClient = new RestClient(baseHlServerUrl);

            return restClient;
        }


        // Transactions ------------------------------------------------------------------------
        
        // Transactions ------------------------------------------------------------------------


        // Test ------------------------------------------------------------------------

        // Test ------------------------------------------------------------------------
    }
}
