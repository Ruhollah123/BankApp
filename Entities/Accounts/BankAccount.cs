using Entities.Base;

namespace Entities.Accounts;

public class BankAccount : AccountBase
{
    public BankAccount(string accountName, int accountNumber, decimal interestRate)
    {
        AccountName = accountName;
        AccountNumber = accountNumber;
        InterestRate = interestRate;
    }

    public override decimal Balance()
    {
        var t = bankTransactions.Sum(x => x.Amount);
        return t + StartingBalance;
    }
}


