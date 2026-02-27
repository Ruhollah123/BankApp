using BankApp.Base;
using BankApp.Models;

namespace BankApp;

internal class TypeOfAccount
{
    public static string DifferentTypeOfAccounts(string input)
    {
        int selectionForAccounts = 0;
        Console.WriteLine("TYPER AV KOTON: ");
        string[] accounts = {
            "Bank Konto",
            "Uddevalla Konto",
            "Isk Konto",
            "Savings Konto",
            "Aktie Konto" };

        ConsoleKey key;

        do
        {
            Console.Clear();

            for (int i = 0; i < accounts.Length; i++)
            {
                if (i == selectionForAccounts)
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                else
                    Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(accounts[i]);
            }

            Console.ResetColor();
            key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.UpArrow && selectionForAccounts > 0)
                selectionForAccounts--;
            if (key == ConsoleKey.DownArrow && selectionForAccounts < accounts.Length - 1)
                selectionForAccounts++;

        } while (key != ConsoleKey.Enter);


        Console.Clear();
        //Console.Write("\nVilken typ av konto vill du skapa: ");
        //var skapaKonto = Console.ReadLine();
        return selectionForAccounts.ToString();
        //return skapaKonto;
    }

    public static AccountDetails ContactInput()
    {
        Console.Write("\nAnge Kontonamn: ");
        var kontoNamn = Console.ReadLine();

        Console.Write("Ange Kontonummer: ");
        int.TryParse(Console.ReadLine(), out int kontoNummer);

        AccountBase nyttKonto = null;
        string kontoTyp;

        return new AccountDetails { AccountName = kontoNamn, AccountNumber = kontoNummer, StartingBalance = 0 };
    }

    public static void AddToAccontsList(Bank bank, AccountBase nyttKonto)
    {
        bank.AddAccount(nyttKonto);

        Console.WriteLine("Kontot har skapats");
        Console.Write("Tryck Enter för att fortsätta till menyn...");
        Console.ReadKey();
    }
}
