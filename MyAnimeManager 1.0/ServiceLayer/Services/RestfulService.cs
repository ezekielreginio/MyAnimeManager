using InfrastructureLayer.DataAccess.Repositories;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class RestfulService : IRestfulService
    {
        private HttpClient client = new HttpClient();

        private IRestfulRepository _restfulRepository;

        public RestfulService()
        {

        }

        public RestfulService(IRestfulRepository restfulRepository)
        {
            _restfulRepository = restfulRepository;
        }

        public async Task<int> LoginUser(String authorizationCode)
        {
            string requestURL = "https://myanimelist.net/v1/oauth2/token";
            string accessToken;
            var nvc = new List<KeyValuePair<string, string>>();

            nvc.Add(new KeyValuePair<string, string>("client_id", "798f54733a1dd810ed0760206d54b815"));
            nvc.Add(new KeyValuePair<string, string>("client_secret", "2e2d80ada923ebdf838354403d073487f061c97709a062cd97feb475427ea96a"));
            nvc.Add(new KeyValuePair<string, string>("code", authorizationCode));
            nvc.Add(new KeyValuePair<string, string>("code_verifier", "NklUDX_CzS8qrMGWaDzgKs6VqrinuVFHa0xnpWPDy7_fggtM6kAar4jnTwOgzK7nPYfE9n60rsY4fhDExWzr5bf7sEvMMmSXcT2hWkCstFGIJKoaimoq5GvAEQD8NZ8g"));
            nvc.Add(new KeyValuePair<string, string>("grant_type", "authorization_code"));

            var req = new HttpRequestMessage(HttpMethod.Post, requestURL) { Content = new FormUrlEncodedContent(nvc) };
            HttpResponseMessage response = await client.SendAsync(req);

            if (response.IsSuccessStatusCode)
            {

                accessToken = await response.Content.ReadAsStringAsync();
                dynamic jsonAccessToken = JsonConvert.DeserializeObject(accessToken);
                bool isAddSuccess = _restfulRepository.AddAccessToken(accessToken);
                if (isAddSuccess)
                {
                    int isUserStatisticsAvailable = await GetAnimeStatisticsUsingToken();
                }
                //jsonConfig = JSONController.initializeAccessToken();
                //jsonConfig = JsonConvert.DeserializeObject(File.ReadAllText("config.json"));
                //jsonConfig["token"]["access_token"] = jsonAccessToken["access_token"];
                //jsonConfig["token"]["token_type"] = jsonAccessToken["token_type"];
                //jsonConfig["token"]["expires_in"] = jsonAccessToken["expires_in"];
                //jsonConfig["token"]["refresh_token"] = jsonAccessToken["refresh_token"];

                //string jsonStr = JsonConvert.SerializeObject(jsonConfig);
                //File.WriteAllText("config.json", jsonStr);
                //return 200;
            }
            else
                return 400;
            return 0;
        }

        public async Task<int> GetAnimeStatisticsUsingToken()
        {
            string accessToken = _restfulRepository.GetAccessToken();
            HttpClient client = new HttpClient();
            string requestURL = "https://api.myanimelist.net/v2/users/@me?fields=anime_statistics";

            var req = new HttpRequestMessage(HttpMethod.Get, requestURL) { };
            req.Headers.Add("Authorization", "Bearer " + accessToken);

            HttpResponseMessage response = await client.SendAsync(req);
            Console.WriteLine(response);
            if (response.IsSuccessStatusCode)
            {
                String animeStatistics = await response.Content.ReadAsStringAsync();
                dynamic jsonUserData = JsonConvert.DeserializeObject(animeStatistics);
                Console.WriteLine("Calling Add");
                _restfulRepository.AddProfileData(animeStatistics);
                return 200;
            }
            else
                return (int)response.StatusCode;
        }
    }
}
