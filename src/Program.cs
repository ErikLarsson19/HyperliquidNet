using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperliquidNet
{
    using System;
    using System.Net.Http;
    using System.Text;
    using System.Text.Json;
    using System.Threading.Tasks;

    class Program
    {
        static async Task Main()
        {
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            try
            {
                // Create proper request structure
                var requestData = new
                {
                    type = "meta"  // Based on Python SDK's info endpoint
                };

                var requestContent = new StringContent(
                    JsonSerializer.Serialize(requestData),
                    Encoding.UTF8,
                    "application/json");

                Console.WriteLine("Request Content:");
                Console.WriteLine(JsonSerializer.Serialize(requestData, new JsonSerializerOptions { WriteIndented = true }));

                var response = await client.PostAsync(
                    "https://api.hyperliquid.xyz/info",
                    requestContent);

                Console.WriteLine("\nResponse Status: " + response.StatusCode);

                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine("\nResponse Content:");
                Console.WriteLine(content);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}