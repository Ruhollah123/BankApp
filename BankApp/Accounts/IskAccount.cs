using BankApp.Base;

namespace BankApp.Accounts;

internal class IskAccount : AccountBase
{
    internal override decimal Balance()
    {
        var t = bankTransactions.Sum(x => x.Amount);
        return t + StartingBalance;
    }
}