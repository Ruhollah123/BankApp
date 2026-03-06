using BankApp;
using Entities.Accounts;
using Entities.Base;

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
        //var bank = new Bank();

        //var deletingAccount = new UddevallaAccount { d}

        //bool result = bank.InputToDeleteAccount(bank);

        //Assert.True(result);
    }

    //Skriv ett test som verifierar att metoden returnerar true och faktiskt tar
    //bort ett konto när man skickar in ett giltigt objekt.
}