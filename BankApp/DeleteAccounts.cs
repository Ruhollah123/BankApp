using BankApp.Base;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace BankApp;

internal class DeleteAccounts
{
    public static bool WetherAccountExists(List<AccountBase> accounts)
    {
        Console.Clear();
        if (!accounts.Any())
        {
            Console.WriteLine("Du har inga aktiva konton än");
            Console.Write("Tryck Enter för att fortsätta till menyn...");
            Console.ReadKey();
            return false;
        }

        foreach (var konto in accounts)
        {
            Console.WriteLine($"Kontonamn: {konto.AccountName}, Kontonummer: {konto.AccountNumber}");
        }
        return true;
    }
}
