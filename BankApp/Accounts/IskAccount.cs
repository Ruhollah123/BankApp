using BankApp.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp.Accounts;

internal class IskAccount : AccountBase
{
    internal override decimal Balance()
    {
        var t = bankTransactions.Sum(x => x.Amount);
        return t + StartingBalance;
    }


    public void AccountForIsk(string skapaKonto)
    {
        Bank sammaSak = new Bank();
        Console.Clear();
        Console.Write("Ange Kontonamn: ");
        var iskKonto = Console.ReadLine();

        Console.Write("Ange Kontonummer: ");
        int.TryParse(Console.ReadLine(), out int iskKontoNummer);

        AccountBase förIsk = new BankAccount(iskKonto, iskKontoNummer.ToString(), 2);
        sammaSak.AddAccount(förIsk);

        Console.WriteLine("Isk-Kontot har skapats");
        Console.Write("Tryck Enter för att fortsätta till menyn...");
        Console.ReadKey();
    }

}