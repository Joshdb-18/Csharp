using System;
using System.Collections.Generic;

namespace StockTrader
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal balance = 10000;
            Dictionary<string, decimal> stocks = new Dictionary<string, decimal>();
            stocks.Add("AAPL", 200);
            stocks.Add("GOOG", 150);
            stocks.Add("MSFT", 175);

            while (true)
            {
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1. Top up");
                Console.WriteLine("2. Buy stock");
                Console.WriteLine("3. Sell stock");
                Console.WriteLine("4. List available stocks");

                string option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        Console.WriteLine("Enter the amount you would like to top up:");
                        decimal topUpAmount = decimal.Parse(Console.ReadLine());
                        balance += topUpAmount;
                        Console.WriteLine($"Your new balance is ${balance}");
                        break;
                    case "2":
                        Console.WriteLine("Enter the stock symbol you would like to buy:");
                        string stockToBuy = Console.ReadLine();
                        if (stocks.ContainsKey(stockToBuy))
                        {
                            Console.WriteLine($"The current price of {stockToBuy} is ${stocks[stockToBuy]}");
                            Console.WriteLine("Enter the amount of shares you would like to buy:");
                            int shares = int.Parse(Console.ReadLine());
                            decimal totalCost = shares * stocks[stockToBuy];
                            if (totalCost <= balance)
                            {
                                balance -= totalCost;
                                Console.WriteLine($"You bought {shares} shares of {stockToBuy} for ${totalCost}");
                                Console.WriteLine($"Your new balance is ${balance}");
                            }
                            else
                            {
                                Console.WriteLine("Insufficient funds");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Stock not found");
                        }
                        break;
                    case "3":
                        Console.WriteLine("Enter the stock symbol you would like to sell:");
                        string stockToSell = Console.ReadLine();
                        if (stocks.ContainsKey(stockToSell))
                        {
                            Console.WriteLine("Enter the amount of shares you would like to sell:");
                            int shares = int.Parse(Console.ReadLine());
                            decimal totalSellPrice = shares * stocks[stockToSell];
                            balance += totalSellPrice;
                            Console.WriteLine($"You sold {shares} shares of {stockToSell} for ${totalSellPrice}");
                            Console.WriteLine($"Your new balance is ${balance}");
                        }
                        else
                        {
                            Console.WriteLine("Stock not found");
                        }
                        break;
                    case "4":
                        Console.WriteLine("Available stocks:");
                        foreach (KeyValuePair<string, decimal> stock in stocks)
			{
				Console.WriteLine($"{stock.Key} - ${stock.Value}");
			}
			break;
		    default:
			Console.WriteLine("Invalid option, please try again");
			break;
		}
	    }
	}
    }
}

