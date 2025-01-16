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

                string wallet = "0x742d35Cc6634C0532925a3b844Bc454e4438f44e";

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

                // Test Spot Deploy Auction
                Console.WriteLine($"\nFetching deploy auction info for {wallet}");
                var deployer = await client.Spot.GetSpotDeployAuctionAsync(wallet);

                Console.WriteLine("\nDeploy States:");
                foreach (var state in deployer.States)
                {
                    Console.WriteLine($"Token ID: {state.Token}");
                    Console.WriteLine($"Token Name: {state.Spec.Name}");
                    Console.WriteLine($"Full Name: {state.FullName}");
                    Console.WriteLine($"Max Supply: {state.MaxSupply}");
                    Console.WriteLine($"Genesis Balance: {state.HyperliquidityGenesisBalance}");
                    Console.WriteLine($"Total Genesis Balance (Wei): {state.TotalGenesisBalanceWei}");

                    Console.WriteLine("\nUser Genesis Balances:");
                    foreach (var (address, balance) in state.UserGenesisBalances)
                    {
                        Console.WriteLine($"  Address: {address}");
                        Console.WriteLine($"  Balance: {balance}");
                    }

                    Console.WriteLine("\nExisting Token Genesis Balances:");
                    foreach (var (token, balance) in state.ExistingTokenGenesisBalances)
                    {
                        Console.WriteLine($"  Token: {token}");
                        Console.WriteLine($"  Balance: {balance}");
                    }
                    Console.WriteLine();
                }

                Console.WriteLine("\nGas Auction Details:");
                Console.WriteLine($"Start Time: {DateTimeOffset.FromUnixTimeSeconds(deployer.GasAuction.StartTimeSeconds)}");
                Console.WriteLine($"Duration: {TimeSpan.FromSeconds(deployer.GasAuction.DurationSeconds)}");
                Console.WriteLine($"Start Gas: {deployer.GasAuction.StartGas}");
                Console.WriteLine($"Current Gas: {deployer.GasAuction.CurrentGas ?? "Not set"}");
                Console.WriteLine($"End Gas: {deployer.GasAuction.EndGas}");
            } catch(Exception e)
            {
                Console.WriteLine($"An error occured: {e.Message}");
            }

            Console.ReadKey();
        }


       
    }
}
