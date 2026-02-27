using BankApp.Accounts;
using BankApp.Base;

namespace BankApp;

internal class HandleAccount
{
    public static void AccountNotExisting(Bank bank)
    {
        if (!bank.accounts.Any())
        {
            Console.WriteLine("Ingen konto har registrerats ännu");
            Console.Write("Tryck Enter för att fortsätta till menyn...");
            Console.ReadKey();
            return;
        }
    }

    public static AccountBase CurrentActiveAccounts(Bank bank)
    {
        foreach (var konton in bank.accounts)
        {
            Console.WriteLine($"\nNamn: {konton.AccountName}, Kontonummer: {konton.AccountNumber}");
        }

        Console.Write("\nSkriv någon av följande Konto-nummer du vill hantera: ");
        int.TryParse(Console.ReadLine(), out int hantering);
        var konto = bank.accounts.FirstOrDefault(x => x.AccountNumber == hantering);
        return konto;
    }

    public static void DepositIntoAccount(AccountBase account)
    {
        Console.Write("Ange belopp du vill sätta in: ");
        decimal.TryParse(Console.ReadLine(), out decimal amount);
        account.Deposit(amount);
        Console.Write("Tryck Enter för att fortsätta till menyn...");
        Console.ReadKey();
    }

    public static void WithdrawFromAccount(AccountBase account)
    {
        Console.Write("Ange beloppet du vill ta ut: ");
        int.TryParse(Console.ReadLine(), out int taUtBelopp);

        account.Withdraw(taUtBelopp);
        Console.Write("Tryck Enter för att fortsätta till menyn...");
        Console.ReadKey();
    }

    public static void CurrentBalance(AccountBase account)
    {

        Console.WriteLine($"\nDitt saldo är: {account.Balance()}");
        Console.Write("Tryck Enter för att fortsätta till menyn...");
        Console.ReadKey();
    }

    public static void TransactionsDuringTheYear()
    {
        Console.WriteLine("Alla insättningar under året: ");

        var myAccount = new BankAccount("", 420, 2);

        myAccount.SeedTransactions();

        foreach (var t in myAccount.SeedTransactions())
        {
            Console.WriteLine($"\nBelopp: {t.Amount}kr");
            Console.WriteLine($"Datum: {t.TransactionalDate}");
        }

        Console.WriteLine($"\nRänta: {Math.Round(myAccount.CalculateInterestRate(), 2)}kr");
        Console.Write("\nTryck Enter för att fortsätta till menyn...");
        Console.ReadKey();
    }
}
