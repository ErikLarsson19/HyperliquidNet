using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperliquidNet.src.Examples
{
    public class SpotBalanceExample
    {

        public static async Task Main(string[] args)
        {
            try
            {
                using var client = new HyperliquidClient();

                string wallet = "";

                Console.WriteLine($"Fetching spot balance for {wallet}");

                var balances = await client.Spot.GetSpotBalanceAsync(wallet);

                Console.WriteLine("\nBalances");

                foreach(var balance in balances.Balances)
                {
                    Console.WriteLine($"Token: {balance.Coin}");
                    Console.WriteLine($"  Total: {balance.Total}");
                    Console.WriteLine($"  Hold: {balance.Hold}");
                    Console.WriteLine($"  Entry NTL: {balance.EntryNtl}");
                    Console.WriteLine();
                }
            } catch(Exception e)
            {
                Console.WriteLine($"An error occured: {e.Message}");
            }

            Console.ReadKey();
        }
    }
}
