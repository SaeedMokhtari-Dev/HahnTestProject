using System;
using System.Net.Http;
using System.Threading.Tasks;
using Hahn.ApplicationProcess.December2020.Domain.Configs;
using Microsoft.Extensions.Options;

namespace Hahn.ApplicationProcess.December2020.Domain.HTTPClients
{
    public class RestCountryClient
    {
        private readonly HttpClient _client;
        private readonly RestCountriesAPIs _restCountriesApIs;
        public RestCountryClient(HttpClient client, 
            IOptionsSnapshot<RestCountriesAPIs> restCountriesAPIs)
        {
            _client = client;
            _restCountriesApIs = restCountriesAPIs.Value;
        }
        public async Task<string> SearchByFullName(string fullName)
        {
            var uri = new Uri($"{_restCountriesApIs.BaseAddress}{string.Format(_restCountriesApIs.SearchByFullName, fullName)}");
            var response = await _client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsStringAsync().Result;
            }
            return null;
        }
    }
}