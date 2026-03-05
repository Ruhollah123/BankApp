using Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Accounts;

public class AktieAccount : AccountBase
{
    public AktieAccount(string accountName, int accountNumber, decimal interestRate)
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
