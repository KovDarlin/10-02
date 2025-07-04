using System;

class Bank
{
    private string correctPin = "7898";
    private double balance = 10000;

    public void Start()
    {
        Func<string, bool> checkPin = delegate (string inputPin)
        {
            return inputPin == correctPin;
        };

        Console.Write("Enter PIN-код: ");
        string enteredPin = Console.ReadLine();

        if (!checkPin(enteredPin))
        {
            Console.WriteLine("No correct PIN code.");
            return;
        }

        Console.WriteLine("Allowed!");

        Action<double> showBalance = b => Console.WriteLine($"Current balance: {b} UAH");

        Func<double, bool> withdraw = amount =>
        {
            if (amount <= 0)
            {
                Console.WriteLine("The amount must be greater than 0!");
                return false;
            }

            if (amount <= balance)
            {
                balance -= amount;
                Console.WriteLine($"Removed: {amount} UAH");
                return true;
            }
            else
            {
                Console.WriteLine("No enought money!");
                return false;
            }
        };

        showBalance(balance);

        Console.Write("Enter the amount to withdraw: ");
        if (double.TryParse(Console.ReadLine(), out double amount))
        {
            if (withdraw(amount))
                showBalance(balance);
        }
        else
        {
            Console.WriteLine("Invalid amount value!");
        }
    }
}

class Program
{
    static void Main()
    {
        Bank bank = new();
        bank.Start();
    }
}
