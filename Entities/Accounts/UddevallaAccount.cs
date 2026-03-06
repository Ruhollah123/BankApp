using Entities.Base;

namespace Entities.Accounts;

public class UddevallaAccount : AccountBase
{
    public UddevallaAccount(string accountName, int accountNumber, decimal interestRate)
    {
        AccountName = accountName; 
        AccountNumber = accountNumber;
        InterestRate = interestRate;
    }
    public UddevallaAccount()
    {
        
    }
    public override decimal Balance()
    {
        var t = bankTransactions.Sum(x => x.Amount);
        return t + StartingBalance;
    }
}