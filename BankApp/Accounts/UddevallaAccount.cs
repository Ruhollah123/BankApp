using BankApp.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp.Accounts;

internal class UddevallaAccount : AccountBase
{
    internal override decimal Balance()
    {
        var t = bankTransactions.Sum(x => x.Amount);
        return t + StartingBalance;
    }

    public void AccountForUddevalla(string skapaKonto)
    {
        var iskAccount = new IskAccount();

        Console.Clear();
        Console.Write("Ange Kontonamn: ");
        var uddevallaKonto = Console.ReadLine();

        Console.Write("Ange Kontonummer: ");
        int.TryParse(Console.ReadLine(), out int UddevallaKontoNummer);

        AccountBase förUddevalla = new BankAccount(uddevallaKonto, UddevallaKontoNummer.ToString(), 2);
        iskAccount.AddAccount(förUddevalla);

        Console.WriteLine("Uddevalla-Kontot har skapats");
        Console.Write("Tryck Enter för att fortsätta till menyn...");
        Console.ReadKey();
    }
}