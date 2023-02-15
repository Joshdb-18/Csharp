using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace StockMarketApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize user's balance to $10,000
            double balance = 10000;

            // Read stock data from the API in a JSON format
            string jsonData = System.IO.File.ReadAllText("stocks.json");
            List<Stock> stocks = JsonConvert.DeserializeObject<List<Stock>>(jsonData);

            // Loop through the menu options until the user exits
            bool running = true;
            while (running)
            {
                Console.WriteLine("\nWelcome to the Stock Market App");
                Console.WriteLine("1. Top up");
                Console.WriteLine("2. Buy stocks");
                Console.WriteLine("3. Sell stocks");
                Console.WriteLine("4. List available stocks");
                Console.WriteLine("5. Exit");
                Console.WriteLine("\nYour current balance is: $" + balance);
                Console.Write("\nPlease select an option: ");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("\nEnter the amount you want to top up: $");
                        balance += double.Parse(Console.ReadLine());
                        Console.WriteLine("\nYour balance has been updated to $" + balance);
                        break;
                    case 2:
                        Console.WriteLine("\nList of available stocks: ");
                        for (int i = 0; i < stocks.Count; i++)
                        {
                            Console.WriteLine((i + 1) + ". " + stocks[i].Name + stocks[i].Symbol + " ($" + stocks[i].Price + ")");
                        }
                        Console.Write("\nPlease select the stock you want to buy: ");
                        int stockChoice = int.Parse(Console.ReadLine());
                        Console.Write("\nEnter the quantity you want to buy: ");
                        int quantity = int.Parse(Console.ReadLine());
                        Stock selectedStock = stocks[stockChoice - 1];
                        double cost = selectedStock.Price * quantity;
                        if (cost > balance)
                        {
                            Console.WriteLine("\nInsufficient funds. Please top up and try again.");
                        }
                        else
                        {
                            balance -= cost;
                            Console.WriteLine("\nYou have successfully bought " + quantity + " shares of " + selectedStock.Name + " for $" + cost);
                        }
                        break;
                    case 3:
                        Console.WriteLine("\nList of stocks you own: ");
                        Console.WriteLine("\nYou don't currently own any stocks");
                        break;
                    case 4:
                        Console.WriteLine("\nList of available stocks: ");
                        for (int i = 0; i < stocks.Count; i++)
                        {
                            Console.WriteLine((i + 1) + ". " + stocks[i].Name + stocks[i].Symbol + ($" + stocks[i].Price + ")");
                        }
                        break;
                    case 5:
			Console.WriteLine("\nExiting Stock Market App...");
                        running = false;
                        break;
                    default:
                        Console.WriteLine("\nInvalid option. Please try again.");
                        break;
                }
            }
        }
    }

    class Stock
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }
}


