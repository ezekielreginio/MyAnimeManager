using CommonComponents;
using InfrastructureLayer.DataAccess.Repositories;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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

        public async Task<dynamic> LoginUser(String authorizationCode)
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
                    Console.WriteLine("Added Successfully");
                    dynamic jsonUserData = await GetAnimeStatisticsUsingToken();
                    return jsonUserData;
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
                return null;
            return null;
        }

        public async Task<dynamic> GetAnimeStatisticsUsingToken()
        {
            string accessToken = _restfulRepository.GetAccessToken();
            HttpClient client = new HttpClient();
            string requestURL = "https://api.myanimelist.net/v2/users/@me?fields=anime_statistics";

            var req = new HttpRequestMessage(HttpMethod.Get, requestURL) { };
            req.Headers.Add("Authorization", "Bearer " + accessToken);

            HttpResponseMessage response = await client.SendAsync(req);
            if (response.IsSuccessStatusCode)
            {
                String animeStatistics = await response.Content.ReadAsStringAsync();
                dynamic jsonUserData = JsonConvert.DeserializeObject(animeStatistics);
                return jsonUserData;
            }
            else
                return null;
        }
        public async Task<dynamic> GetAnimeDetails(String title)
        {
            HttpClient client = new HttpClient();
            string requestURL = "https://api.myanimelist.net/v2/anime?q=" + title + "&limit=1";
            string accessToken = _restfulRepository.GetAccessToken();
            int maxChar = 50;
            if (title.Length < maxChar)
            {
                maxChar = title.Length - 1;
            }

            var req = setRequest(HttpMethod.Get, "https://api.myanimelist.net/v2/anime?q=" + title.Substring(0, maxChar) + "&limit=10", accessToken);

            HttpResponseMessage response = await client.SendAsync(req);

            if (response.IsSuccessStatusCode)
            {
                String animeQuery = await response.Content.ReadAsStringAsync();
                dynamic jsonAnimeResult = JsonConvert.DeserializeObject(animeQuery);
                int animeID = -1;
                for (int i = 0; i < ((JArray)jsonAnimeResult["data"]).Count; i++)
                {
                    dynamic anime = jsonAnimeResult["data"][i];
                    Console.WriteLine(anime["node"]["title"]);
                    if (title.ToLower().Equals(StringExtensions.RemoveSpecialCharacters((String)anime["node"]["title"]).ToLower()))
                    {
                        animeID = jsonAnimeResult["data"][i]["node"]["id"];
                        break;
                    }

                }

                var reqAnime = setRequest(HttpMethod.Get, "https://api.myanimelist.net/v2/anime/" + animeID + "?fields=id,title,main_picture,alternative_titles,start_date,end_date,synopsis,mean,rank,popularity,num_list_users,num_scoring_users,nsfw,created_at,updated_at,media_type,status,genres,my_list_status,num_episodes,start_season,broadcast,source,average_episode_duration,rating,pictures,background,related_anime,related_manga,recommendations,studios,statistics", accessToken);
                client = new HttpClient();
                HttpResponseMessage responseAnime = await client.SendAsync(reqAnime);
                //Console.WriteLine(responseAnime);
                if (responseAnime.IsSuccessStatusCode)
                {
                    String animeDetails = await responseAnime.Content.ReadAsStringAsync();
                    //Console.WriteLine("Anime Details: " + animeDetails);
                    return JsonConvert.DeserializeObject(animeDetails);
                }
                else return null;

            }
            else return null;
            return null;
        }

        //Private Methods
        private static dynamic setRequest(HttpMethod method, String requestURL, String accessToken)
        {
            dynamic req = new HttpRequestMessage(method, requestURL) { };
            req.Headers.Add("Authorization", "Bearer " + accessToken);

            return req;
        }
    }
}
