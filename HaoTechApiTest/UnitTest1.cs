using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace HaoTechApiTest
{
    public class UnitTest1
    {
        private IConfidentialClientApplication _client;
       [Fact]
        public async Task Test1()
        {
            await SetupClient();
        }  

        private async Task SetupClient()
        {
            string authority = "";
            string clientId = "";
            string appSecret = "";

            _client = ConfidentialClientApplicationBuilder.Create(clientId)
                                                      .WithClientSecret(appSecret)
                                                      .WithAuthority(new Uri(authority))
                                                      .Build();
            //string[] scopes = new string[] { "https://graph.microsoft.com/.default" };
            string[] scopes = new string[] { "https://HaoTech.onmicrosoft.com/HaoTechApi/.default" };
            try
            {
                var result = await _client.AcquireTokenForClient(scopes).ExecuteAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
