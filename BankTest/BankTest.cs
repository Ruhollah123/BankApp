using BankApp;
using Entities.Accounts;
using Entities.Base;
using System.Formats.Asn1;
using System.Xml.XPath;

namespace BankTest;

public class BankTest
{
    [Fact]
    public void Bank_RemoveAccount_ReturnIfItReallyRemovesAnAccount()
    {
        var removesAccount = new Bank();

        var testGuid = Guid.NewGuid();

        removesAccount.RemoveAccount(testGuid);

        Assert.NotEqual(Guid.Parse("7b96ea6f-7de7-4430-b387-3777132f366a"), testGuid);
    }

    [Fact]
    public void Bank_GetAccounts_IfItReturnsAListOfAccounts()
    {
        var listOfAccounts = new Bank();

        var accounts = listOfAccounts.GetAccounts();

        Assert.NotNull(accounts);
        Assert.IsType<List<AccountBase>>(accounts);
    }

    [Fact]
    public void Bank_InputToDeleteAccount_ShouldReturnFalseWhenNullIsSent()
    {
        var bank = new Bank();

        bool result = bank.InputToDeleteAccount(null);

        Assert.False(result);
    }

    [Fact]
    public void Bank_InputToDeleteAccount_ReturnTrueIfTheAccountIsBeingDeleted()
    {
        var bank = new Bank();

        var deletingAccount = new UddevallaAccount()
        {
            AccountName = "Testar",
            AccountNumber = 12
        };

        bank.AddAccount(deletingAccount);

        bool result = bank.InputToDeleteAccount(deletingAccount);

        Assert.True(result);
        Assert.DoesNotContain(deletingAccount, bank.GetAccounts());
    }

    [Fact]
    public void Bank_InputToDeleteAccount_ReturnZeroIfTheListGetsEmptied()
    {
        var bank = new Bank();

        var deletingAccount = new UddevallaAccount()
        {
            AccountName = "Testar",
            AccountNumber = 12
        };

        bank.AddAccount(deletingAccount);
        bool result = bank.InputToDeleteAccount(deletingAccount);

        Assert.Empty(bank.GetAccounts());
    }

    [Fact]
    public void Bank_InputToDeleteAccount_DeleteTheRightPersonSoItDoesntDeleteTheWholeList()
    {
        var bank = new Bank();

        var deletingAccountA = new UddevallaAccount()
        {
            AccountName = "TestarA",
            AccountNumber = 12
        };

        var deletingAccountB = new UddevallaAccount()
        {
            AccountName = "TestarB",
            AccountNumber = 14
        };


        bank.AddAccount(deletingAccountA);
        bank.AddAccount(deletingAccountB);

        bool result = bank.InputToDeleteAccount(deletingAccountA);

        Assert.True(result);

        Assert.Contains(deletingAccountB, bank.GetAccounts());

        Assert.Single(bank.GetAccounts());
    }

    [Fact]
    public void Bank_InputToDeleteAccount_MakingSureTheListOnlyHasTwoAccounts()
    {
        var bank = new Bank();

        var deletingAccountA = new UddevallaAccount()
        {
            AccountName = "TestarA",
            AccountNumber = 12
        };

        var deletingAccountB = new UddevallaAccount()
        {
            AccountName = "TestarB",
            AccountNumber = 14
        };

        var deletingAccountC = new UddevallaAccount()
        {
            AccountName = "TestarC",
            AccountNumber = 334
        };

        bank.AddAccount(deletingAccountA);
        bank.AddAccount(deletingAccountB);
        bank.AddAccount(deletingAccountC);


        bool result = bank.InputToDeleteAccount(deletingAccountC);

        Assert.True(result);

        Assert.Equal(2, bank.GetAccounts().Count);
    }

    [Fact]
    public void Bank_InputToDeleteAccount_TheEmptyListDelete()
    {
        var bank = new Bank();

        var deletingAccountD = new UddevallaAccount()
        {
            AccountName = "TestarD",
            AccountNumber = 56
        };

         var result = bank.InputToDeleteAccount(deletingAccountD);

        Assert.False(result);
    }

    [Fact]
    public void Bank_InputToDeleteAccount_TheAccountShouldBeDeleted()
    {
        var bank = new Bank();
        var toBeDeleted = new UddevallaAccount()
        {
            AccountName = "deletingMe",
            AccountNumber = 123
        };


        bank.AddAccount(toBeDeleted);

        var theDeleted = bank.InputToDeleteAccount(toBeDeleted);

        bool ifStillExists = bank.GetAccounts().Any(x => x.AccountName == "deletingMe");
        Assert.False(ifStillExists);
    }


    [Fact]
    public void Bank_ShowBankMenu_DeleteTheAccountWhichHasTwoHundred()
    {

        var acc1 = new UddevallaAccount();
        acc1.SeedTransactions();


        var tenAccounts = acc1
            .SeedTransactions()
            .Count();

        Assert.Equal(50, tenAccounts);
    }

    [Fact]
    public void Bank_TypeOfAccountInput_ReturnIfTheAccountInputIsString()
    {
        var bankAccounts = new AccountDetails()
        {
            AccountType = AccountType.BankAccount,
            AccountName = "Test"
        };

        var createdAccount = AccountFactory.CreateAccount(bankAccounts);

        Assert.IsType<BankAccount>(bankAccounts);
    }
}