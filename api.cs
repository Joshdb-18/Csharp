using System;
using System.Net.Http;

namespace GoogleSearchAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a search query:");
            string query = Console.ReadLine();
            GetGoogleResults(query).Wait();
        }

        static async System.Threading.Tasks.Task GetGoogleResults(string query)
        {
            using (var client = new HttpClient())
            {
                // API endpoint for searching Google
                string url = $"https://www.google.com/search?q={query}";

                // Make the API request
                HttpResponseMessage response = await client.GetAsync(url);

                // Check the response status code
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Failed to retrieve response: {await response.Content.ReadAsStringAsync()}");
                }

                // Extract the response content
                string responseContent = await response.Content.ReadAsStringAsync();

                Console.WriteLine(responseContent);
            }
        }
    }
}

