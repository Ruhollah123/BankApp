using Entities.Accounts;
using Entities.Base;
using Entities.Types;
using Services.Models;

namespace Services;

public static class AccountFactory
{
    public static AccountBase CreateAccount(AccountDetails accountDetails)
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
