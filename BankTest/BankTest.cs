using BankApp;
using BankApp.Factories;
using Entities.Accounts;
using Entities.Base;
using Entities.Types;
using Services.Models;

namespace BankTest;

public class BankTest
{
    [Fact]
    public void Bank_RemoveAccount_ReturnIfItReallyRemovesAnAccount()
    {
        var removesAccount = new Bank();

        var testGuid = Guid.NewGuid();

        removesAccount.RemovingAccount(testGuid);

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
        var accounts = new BankAccount();

        var transactions = accounts.SeedTransactions();

        var countOverFive = transactions.Count(t => t.Amount > 5000);

        Assert.Equal(4, countOverFive);
    }

    [Fact]
    public void Bank_TypeOfAccountInput_ReturnIfTheAccountInputIsString()
    {
        var bank = new AccountDetails()
        {
            AccountName = "Test",
            AccountType = AccountType.BankAccount
        };


        var createdAccount = AccountFactory.CreateAccount(bank);

        Assert.IsType<BankAccount>(createdAccount);
    }



    [Fact]
    public void Bank_ShowBankMenu_IfTheTypeOfAccountInputIsAString()
    {
        var bank = new Bank();

        Bank.ShowBankMenu(bank);

        Assert.True(true);
    }

    [Fact]
    public void Bank_ShowBankMenu_CreatingAccountsAndCountingThem()
    {
        var bank = new Bank();

        bank.AddAccount(new UddevallaAccount());
        bank.AddAccount(new UddevallaAccount());
        bank.AddAccount(new UddevallaAccount());
        bank.AddAccount(new BankAccount());
        bank.AddAccount(new BankAccount());
        bank.AddAccount(new IskAccount());
        bank.AddAccount(new IskAccount());


        var theList = bank.GetAccounts().OfType<IskAccount>().Count();

        Assert.Equal(4, theList);
    }



    [Fact]
    public void TypeOfAccount_DifferentTypeOfAccounts_ReturnsTheTypeOfAccountCreated()
    {
        var bank = new Bank();

        var theAccount = new UddevallaAccount();
        TypeOfAccount.AddToAccountsList(bank, theAccount);

        var result = bank.GetAccounts().Count();

        Assert.Equal(1, result);

    }


    [Fact]
    public void Bank_ShowBankMenu_AddAnAccountThenDeleteIt()
    {

        var accounts = new List<AccountBase> { new UddevallaAccount { AccountNumber = 1 } };
        var input = new StringReader("1");
        Console.SetIn(input);

        var result = DeleteAccounts.WetherAccountExists(accounts);

        Assert.Equal(1, result);



        //var bank = new Bank();

        //var theAccount = new UddevallaAccount()
        //{
        //    AccountName = "Test",
        //    AccountNumber = 1,
        //    InterestRate = 1,
        //};

        //bank.AddAccount(theAccount);
        //bank.RemoveAccount(1);

        //Assert.Empty(bank.GetAccounts());
    }

    [Fact]
    public void Bank_ShowAllAccounts_WetherTheActualAccountIsBeingShown()
    {
        var bank = new Bank();

        var theAccount = new UddevallaAccount
        {
            AccountName = "Test",
            AccountNumber = 1,
            InterestRate = 2
        };

        bank.AddAccount(theAccount);

        bank.ShowAllAccounts("1");


        var result = bank.GetAccounts().Count();

        Assert.Equal(1, result);
    }

    [Fact]
    public void Bank_RemoveAccount_WhatHappensIfAccountIsNull()
    {
        var bank = new Bank();

        var listOfAccounts = new List<AccountBase> {

            new UddevallaAccount { AccountName = "Aron", AccountNumber = 2, InterestRate = 2},
            new UddevallaAccount { AccountName = "Karin", AccountNumber = 3, InterestRate = 4},
            new UddevallaAccount { AccountName = "Nia", AccountNumber = 4, InterestRate = 3},
        };

        var input = new StringReader("2");
        Console.SetIn(input);


        foreach (var accounts in listOfAccounts)
        {
            bank.AddAccount(accounts);
        }

        bank.RemoveAccount(2);

        var accountToDelete = listOfAccounts.Where(x => x.AccountNumber == 2);

        Assert.DoesNotContain(bank.GetAccounts(), x => x.AccountNumber == 2);
    }


    [Fact]
    public void Bank_RemoveAccount_WhatHappensWhenAccountIsNull()
    {

    }
}