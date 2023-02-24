using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your monthly salary? $ ");
        decimal salary = decimal.Parse(Console.ReadLine());

        Dictionary<string, decimal> expenses = new Dictionary<string, decimal>();

        Console.WriteLine("\nPlease answer the following survey questions to calculate your daily expenses:\n");

	Console.Write("How much do you spend on food per month? $ ");
        expenses["Food"] = decimal.Parse(Console.ReadLine());
	Console.Write("How much do you spend on housing per month? $ ");
        expenses["Housing"] = decimal.Parse(Console.ReadLine());
	Console.Write("How much do you spend on transportation per month? $ ");
        expenses["Transportation"] = decimal.Parse(Console.ReadLine());
	Console.Write("How much do you spend on utilities (e.g. electricity, water) per month? $ ");
        expenses["Utilities"] = decimal.Parse(Console.ReadLine());
	Console.Write("How much do you spend on entertainment (e.g. movies, hobbies) per month? $ ");
        expenses["Entertainment"] = decimal.Parse(Console.ReadLine());
	Console.Write("How much do you intend to spend on Unforseen Circumstances? $ ");
	expenses["Unforseen_circumstances"] = decimal.Parse(Console.ReadLine());

	Console.WriteLine();
	decimal totalExpenses = 0;
        foreach (var expense in expenses.Values)
        {
            totalExpenses += expense;
        }

        decimal dailyExpenses = totalExpenses / 30;
        decimal dailyBudget = salary / 30;

        if (dailyBudget >= dailyExpenses)
        {
            Console.WriteLine($"Your daily budget is ${dailyBudget:0.00}.");
            Console.WriteLine("You need to spend the following amount on each item each day:");
            foreach (var expense in expenses)
            {
                Console.WriteLine($"{expense.Key}: ${expense.Value / 30:0.00}");
            }
        }
        else
        {
            Console.WriteLine("Dammit!!\nYou are overspending.");
        }
    }
}


