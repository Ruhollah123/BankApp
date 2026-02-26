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
                break;
            case AccountType.IskAccount:
                break;
            case AccountType.UddevallaAccount:
                break;
            default:
                break;
        }
        return default;
    }
}
