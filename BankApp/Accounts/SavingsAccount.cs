using BankApp.Base;

namespace BankApp.Accounts;

internal class SavingsAccount : AccountBase
{
    public SavingsAccount(string accountName, int accountNumber, decimal interestRate)
    {
        AccountName = accountName;
        AccountNumber = accountNumber;
        InterestRate = interestRate;
    }

    internal override decimal Balance()
    {
        var t = bankTransactions.Sum(x => x.Amount);
        return t + StartingBalance;
    }


}
