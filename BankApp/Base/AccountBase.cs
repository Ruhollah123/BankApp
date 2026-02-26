namespace BankApp.Base;

internal abstract class AccountBase
{
    internal Guid Id { get; } = Guid.NewGuid();
    protected decimal StartingBalance { get; } = 0;
    public string AccountName { get; set; } = "";
    public int AccountNumber { get; set; }
    internal decimal InterestRate { get; set; } = 2;

    protected List<BankTransaction> bankTransactions = new List<BankTransaction>();


    public List<BankTransaction> SeedTransactions()
    {
        bankTransactions.Add(new BankTransaction { Amount = 5000, TransactionalDate = new DateTime(2025, 1, 1) });
        bankTransactions.Add(new BankTransaction { Amount = 12999, TransactionalDate = new DateTime(2025, 2, 18) });
        bankTransactions.Add(new BankTransaction { Amount = 4000, TransactionalDate = new DateTime(2025, 3, 25) });
        bankTransactions.Add(new BankTransaction { Amount = 3000, TransactionalDate = new DateTime(2025, 4, 11) });
        bankTransactions.Add(new BankTransaction { Amount = 2000, TransactionalDate = new DateTime(2025, 5, 4) });
        bankTransactions.Add(new BankTransaction { Amount = 1000, TransactionalDate = new DateTime(2025, 6, 7) });
        bankTransactions.Add(new BankTransaction { Amount = 1500, TransactionalDate = new DateTime(2025, 7, 2) });
        bankTransactions.Add(new BankTransaction { Amount = 8905, TransactionalDate = new DateTime(2025, 8, 14) });
        bankTransactions.Add(new BankTransaction { Amount = 7000, TransactionalDate = new DateTime(2025, 9, 9) });
        bankTransactions.Add(new BankTransaction { Amount = 15000, TransactionalDate = new DateTime(2025, 11, 15) });

        return bankTransactions;
    }

    public decimal CalculateInterestRate()
    {
        decimal totalInterestRate = 0;

        DateTime startOfYear = new DateTime(2025, 1, 1);
        DateTime endOfYear = new DateTime(2025, 12, 31);

        for (DateTime day = startOfYear; day <= endOfYear; day = day.AddDays(1))
        {
            decimal balanceForTheDay = Balance();

            foreach (var transaction in bankTransactions)
            {
                if (transaction.TransactionalDate <= day)
                {
                    balanceForTheDay += transaction.Amount;
                }
            }

            totalInterestRate += balanceForTheDay * (InterestRate / 100 / 365);
        }

        return totalInterestRate;
    }

    internal abstract decimal Balance();

    internal virtual void Deposit(decimal amount)
    {
        if (amount >= 10000)
        {
            Console.WriteLine("Ett fel har inträffat, Man får inte sätta in mer än 10000kr...");
        }
        else if (amount <= 0)
        {
            Console.WriteLine("Inkorrekt nummer, måste vara ett positiv siffra");
        }
        else
        {
            Console.WriteLine("Insättning genomförd");
            var t = new BankTransaction
            {
                Amount = amount,
                TransactionalDate = DateTime.Now
            };

            bankTransactions.Add(t);
        }
    }

    internal virtual void Withdraw(decimal amount)
    {
        var balance = Balance();

        if (balance < amount)
        {
            Console.WriteLine("Inte tillräckligt pengar för att ta ut");
        }
        else if (amount <= 0)
        {
            Console.WriteLine("\nNumret får inte vara 0 eller negativ!");
        }
        else
        {
            Console.WriteLine("Uttag genomförd");
            var t = new BankTransaction
            {

                Amount = -amount,
                TransactionalDate = DateTime.Now
            };

            bankTransactions.Add(t);
        }
    }
}