using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using XamarinGroup.Models;

namespace XamarinGroup.Repository
{
    public class GroupRepository
    {
        HttpClient _client;
        string Endpoint = "https://api.themoviedb.org/3/search/movie?api_key=11b2435829c14693e68170a0500f2746&language=en-US&query=Titanic&page=1&include_adult=false";

        //string APIKey = "81dbb02a439114a3128632faa0a71620";


        public GroupRepository()
        {

            _client = new HttpClient();

        }

        public async Task<Search> GetSearchMovie(string uri)
        {
            Search SearchData = null;
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    SearchData = JsonConvert.DeserializeObject<Search>(content);
                }
            }
            catch (Exception ex)
            {
                
            }

            return SearchData;
        }

    }
}
