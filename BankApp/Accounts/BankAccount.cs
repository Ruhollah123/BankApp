using BankApp.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp.Accounts;

internal class BankAccount : AccountBase
{
    public BankAccount(string accountName, string accountNumber)
    {
        AccountName = accountName;
        AccountNumber = accountNumber;
    }

    internal override decimal Balance()
    {
        var t = bankTransactions.Sum(x => x.Amount);
        return t + StartingBalance;
    }
}


