using BankApp.Base;
using BankApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp;

internal class TypeOfAccount
{
    public static string DifferentTypeOfAccounts(string input)
    {
        Console.Clear();

        Console.WriteLine("1. Bank Konto");
        Console.WriteLine("2. Uddevalla Konto");
        Console.WriteLine("3. Isk Konto");
        Console.WriteLine("4. Savings Konto");
        Console.WriteLine("5. Aktie Konto");

        Console.Write("\nVilken typ av konto vill du skapa: ");
        var skapaKonto = Console.ReadLine();
        return skapaKonto;
    }

    public static AccountDetails ContactInput()
    {
        Console.Write("\nAnge Kontonamn: ");
        var kontoNamn = Console.ReadLine();

        Console.Write("Ange Kontonummer: ");
        int.TryParse(Console.ReadLine(), out int kontoNummer);

        AccountBase nyttKonto = null;
        string kontoTyp;

        return new AccountDetails {AccountName = kontoNamn, AccountNumber = kontoNummer, StartingBalance = 0};
    }

    public static void AddToAccontsList(Bank bank, AccountBase nyttKonto)
    {
        bank.AddAccount(nyttKonto);

        Console.WriteLine("Kontot har skapats");
        Console.Write("Tryck Enter för att fortsätta till menyn...");
        Console.ReadKey();
    }
}
