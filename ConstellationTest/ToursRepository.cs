using ConstellationTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace ConstellationTest
{
    public class ToursRepository
    {
        private readonly Tours model;

        public static Task<ToursRepository> Create() => Create("https://cdn.sozvezdie-tour.ru/demo_offers.json");

        private static async Task<ToursRepository> Create(string url)
        {
            return new ToursRepository
                ( 
                new Tours
                    {
                        List = DeserializeList(await LoadTours(url).ConfigureAwait(false)).ToArray()
                    }
             ) ;
        }

        private static Tours DeserializeClass(string jsonData)
        {
            var serializer = new JavaScriptSerializer();
            var records = serializer.Deserialize<Tours>(jsonData);
            return records;
        }
        private static IEnumerable<Tour> DeserializeList(string jsonData)
        {
            var serializer = new JavaScriptSerializer();
            var records = serializer.Deserialize<List<Tour>>(jsonData);
            return records;
        }

        private async static Task<string> LoadTours(string url)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url).ConfigureAwait(false);
            var result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            return result;
        }

        private ToursRepository(Tours model)
        {
            this.model = model;
        }

        internal Tours LoadAll()
        {
            return model;
        }
    }
}