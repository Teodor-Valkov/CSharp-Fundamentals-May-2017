using System;
using System.Collections.Generic;

internal class StartUp
{
    private static void Main()
    {
        Dictionary<int, BankAccount> bankAccounts = new Dictionary<int, BankAccount>();

        string input = string.Empty;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] inputArgs = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string command = inputArgs[0];

            switch (command)
            {
                case "Create":
                    Create(inputArgs, bankAccounts);
                    break;

                case "Deposit":
                    Deposit(inputArgs, bankAccounts);
                    break;

                case "Withdraw":
                    Withdraw(inputArgs, bankAccounts);
                    break;

                case "Print":
                    Print(inputArgs, bankAccounts);
                    break;
            }
        }
    }

    private static void Create(string[] inputArgs, Dictionary<int, BankAccount> bankAccounts)
    {
        int id = int.Parse(inputArgs[1]);

        if (!bankAccounts.ContainsKey(id))
        {
            BankAccount bankAccount = new BankAccount
            {
                ID = id,
                Balance = 0
            };

            bankAccounts[id] = bankAccount;
        }
        else
        {
            Console.WriteLine("Account already exists");
        }
    }

    private static void Deposit(string[] inputArgs, Dictionary<int, BankAccount> bankAccounts)
    {
        int id = int.Parse(inputArgs[1]);
        double deposit = double.Parse(inputArgs[2]);

        if (!bankAccounts.ContainsKey(id))
        {
            Console.WriteLine("Account does not exist");
        }
        else
        {
            bankAccounts[id].Deposit(deposit);
        }
    }

    private static void Withdraw(string[] inputArgs, Dictionary<int, BankAccount> bankAccounts)
    {
        int id = int.Parse(inputArgs[1]);
        double withdrawal = double.Parse(inputArgs[2]);

        if (!bankAccounts.ContainsKey(id))
        {
            Console.WriteLine("Account does not exist");
        }
        else
        {
            if (bankAccounts[id].Balance < withdrawal)
            {
                Console.WriteLine("Insufficient balance");
            }
            else
            {
                bankAccounts[id].Withdraw(withdrawal);
            }
        }
    }

    private static void Print(string[] inputArgs, Dictionary<int, BankAccount> bankAccounts)
    {
        int id = int.Parse(inputArgs[1]);

        if (!bankAccounts.ContainsKey(id))
        {
            Console.WriteLine("Account does not exist");
        }
        else
        {
            Console.WriteLine(bankAccounts[id]);
        }
    }
}