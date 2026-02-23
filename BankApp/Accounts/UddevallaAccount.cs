using BankApp.Base;

namespace BankApp.Accounts;

internal class UddevallaAccount : AccountBase
{
    internal override decimal Balance()
    {
        var t = bankTransactions.Sum(x => x.Amount);
        return t + StartingBalance;
    }

    
}