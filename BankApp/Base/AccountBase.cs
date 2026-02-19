namespace BankApp.Base;

internal abstract class AccountBase
{
    internal Guid Id { get; set; } = Guid.NewGuid();
    protected decimal StartingBalance { get; set; } = 0;
    public string AccountName { get; set; } = ""; //Hur man får den gröna linjen att försvinna//
    public string AccountNumber { get; set; } = "";

    internal decimal InterestRate { get; set; } = 0;

    protected List<BankTransaction> bankTransactions = new List<BankTransaction>();

    internal abstract decimal Balance();

    internal virtual void Deposit(decimal amount)
    {
        if (amount > 10000)
        {
            Console.WriteLine("Ett fel har inträffat, Man får inte sätta in mer än 10000kr...");
        }
        else if (amount < 0)
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

