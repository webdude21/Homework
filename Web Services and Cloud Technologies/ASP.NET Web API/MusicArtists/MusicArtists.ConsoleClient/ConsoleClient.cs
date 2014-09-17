namespace MusicArtists.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;

    using MusicArtists.Services.Models;

    using Newtonsoft.Json;

    internal class ConsoleClient
    {
        private static void Main()
        {
            var client = InitializeHttpClient("http://localhost:7416/");
            DisplayAllSongs(client);
        }

        private static HttpClient InitializeHttpClient(string baseUrl)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri(baseUrl)
            };

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }

        private static void DisplayAllSongs(HttpClient client)
        {
            var response = client.GetAsync("api/Songs").Result;

            if (response.IsSuccessStatusCode)
            {
                var responseResult = response.Content.ReadAsStringAsync().Result;
                var songs = JsonConvert.DeserializeObject<IEnumerable<SongOutputModel>>(responseResult);
                Console.WriteLine("{0,4} {1,-15} {2}", "Song Id", "Song name", "Album Id");

                foreach (var song in songs)
                {
                    Console.WriteLine("{0,4} {1,-20} {2}", song.Id, song.Title, song.AlbumId);
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }
    }
}