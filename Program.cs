using Microsoft.Owin.Hosting;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;

namespace Galytix
{
    public class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            string baseAddress = "http://localhost:8080/";

            using (WebApp.Start<Startup>(url: baseAddress))
            {
                HttpClient httpClient = new HttpClient();

                var averageGrowthRateRequest = new AverageGrowthRateRequest
                {
                    Country = "ae",
                    LineOfBusiness = "transport",
                    YearStart = 2008,
                    YearEnd = 2015,
                    PeersToReturn = 3
                };

                var stringContent = new StringContent(JsonConvert.SerializeObject(averageGrowthRateRequest), Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(baseAddress + "server/api/CountryGwp", stringContent);
                Console.WriteLine(response);
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);

                Console.ReadLine();
            }
        }
    }
}
