﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Smart_bike_G3.Repositories
{
    public class Repository
    {
        private static HttpClient GetHttpClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("accept", "application/json");
            return client;
        }
        public async static Task AddResults(int videoid, string user, int distance )
        {
            using (HttpClient client = GetHttpClient())
            {
                try
                {
                    string url = $"https://smartbikeapi.azurewebsites.net/api/smartbike/video/{videoid}/{user}/{distance}";

                    var response = await client.PostAsync(url, null);
                    if (!response.IsSuccessStatusCode)
                    {
                        throw new Exception("Something went wrong");
                    }

                }
                catch (Exception ex)
                {

                    throw ex;
                }

            }
        }
    }
}
