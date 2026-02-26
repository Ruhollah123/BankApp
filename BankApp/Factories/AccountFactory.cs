using BankApp.Accounts;
using BankApp.Base;
using BankApp.Models;
using BankApp.Types;

namespace BankApp.Factories;

internal static class AccountFactory
{
    internal static AccountBase CreateAccount(AccountDetails accountDetails)
    {
        switch (accountDetails.AccountType)
        {
            case AccountType.BankAccount:
                return new BankAccount(accountDetails.AccountName,
                    accountDetails.AccountNumber, accountDetails.StartingBalance);

            case AccountType.IskAccount:
                return new UddevallaAccount(accountDetails.AccountName,
                    accountDetails.AccountNumber, accountDetails.StartingBalance);

            case AccountType.UddevallaAccount:
                return new IskAccount(accountDetails.AccountName,
                    accountDetails.AccountNumber, accountDetails.StartingBalance);

            case AccountType.SavingsAccount:
                return new SavingsAccount(accountDetails.AccountName,
                    accountDetails.AccountNumber, accountDetails.StartingBalance);

            case AccountType.AktieAccount:
                return new AktieAccount(accountDetails.AccountName,
                    accountDetails.AccountNumber, accountDetails.StartingBalance);

            default:
                throw new NotImplementedException();
        }
    }
}
