using BankApp.Base;

namespace BankApp.Accounts;

internal class BankAccount : AccountBase
{
    public BankAccount(string accountName, string accountNumber, decimal interestRate)
    {
        AccountName = accountName;
        AccountNumber = accountNumber;
        InterestRate = interestRate;
    }
    public BankAccount()
    {
        
    }




    internal override decimal Balance()
    {
        var t = bankTransactions.Sum(x => x.Amount);
        return t + StartingBalance;
    }

    public void BankKonto(string skapaKonto)
    {
        Bank nyaTillägg = new Bank();
        Console.Clear();
        Console.Write("Ange Kontonamn: ");
        var kontoNamn = Console.ReadLine();

        Console.Write("Ange Kontonummer: ");
        int.TryParse(Console.ReadLine(), out int kontoNummer);


        AccountBase nyttKonto = new BankAccount(kontoNamn, kontoNummer.ToString()); // "possibly null reference" på kontoNamn.
        nyaTillägg.AddAccount(nyttKonto);
        Console.WriteLine("Kontot har skapats");
        Console.Write("Tryck Enter för att fortsätta till menyn...");
        Console.ReadKey();
    }
}


