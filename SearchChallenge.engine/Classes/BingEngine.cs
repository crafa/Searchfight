using SearchChallenge.engine.Config;
using SearchChallenge.engine.Interfaces;
using SearchChallenge.engine.Models;
using SearchChallenge.engine.Utils;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SearchChallenge.engine.Classes
{
    public class BingEngine : ReadConfig, ISearchEngine
    {
        private HttpClient _httpClient { get; }
        private readonly string urlSearch = ReadSetting("BingUrl");
        private readonly string keySearch = ReadSetting("BingKey");
        public string Name { get => "Bing Engine"; }

        public BingEngine()
        {
            _httpClient = new HttpClient();
        }

        public async Task<long> GetTotalResults(string term)
        {
            if (string.IsNullOrWhiteSpace(term))
            {
                throw new ArgumentException("Argument cannot be null or empty!", "term");
            }
            _httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", keySearch);
            using (var response = await _httpClient.GetAsync(string.Format(urlSearch, term)))
            {
                if (response.IsSuccessStatusCode)
                {
                    var results = (await response.Content.ReadAsStringAsync());
                    var numberResults = JsonUtility.GetJsonValue<BingResults>(results);
                    return long.Parse(numberResults.webPages.totalEstimatedMatches);
                }
                throw new Exception("There was an error calling to the service.");
            }
        }
    }
}
