using BankApp.Factories;
using Entities.Accounts;
using Services.Models;

namespace ServiceTest2;

public class UnitTest1
{
    [Fact]
    public void AccountFactory_CreateAccount_ShouldReturnBankAccount()
    {
        //Arrange
        var accountDetails = new AccountDetails()
        {
            AccountName = "Test Account",
            AccountNumber = 11,
            AccountType = Entities.Types.AccountType.BankAccount,
            StartingBalance = 0
        };

        //Act
        var account = AccountFactory.CreateAccount(accountDetails);

        //Assert
        Assert.IsType<BankAccount>(account);

    }

    [Fact]
    public void AccountFactory_CreateAccount_ShouldReturnUddevallaAccount()
    {
        //Arrange
        var accountDetails = new AccountDetails()
        {
            AccountName = "Test Account",
            AccountNumber = 11,
            AccountType = Entities.Types.AccountType.UddevallaAccount,
            StartingBalance = 0
        };


        //Act
        var account = AccountFactory.CreateAccount(accountDetails);

        //Assert
        Assert.IsType<UddevallaAccount>(account);

    }

    [Fact]
    public void AccountFactory_CreateAccount_ShouldReturnSavingsAccount()
    {
        //Arrange
        var accountDetails = new AccountDetails()
        {
            AccountName = "Test Account",
            AccountNumber = 11,
            AccountType = Entities.Types.AccountType.SavingsAccount,
            StartingBalance = 0
        };


        //Act
        var account = AccountFactory.CreateAccount(accountDetails);

        //Assert
        Assert.IsType<SavingsAccount>(account);

    }
    [Fact]
    public void AccountFactory_CreateAccount_ShouldReturnIskAccount()
    {
        //Arrange
        var accountDetails = new AccountDetails()
        {
            AccountName = "Test Account",
            AccountNumber = 11,
            AccountType = Entities.Types.AccountType.IskAccount,
            StartingBalance = 0
        };


        //Act
        var account = AccountFactory.CreateAccount(accountDetails);

        //Assert
        Assert.IsType<IskAccount>(account);

    }
    [Fact]
    public void AccountFactory_CreateAccount_ShouldReturnAkiteAccount()
    {
        //Arrange
        var accountDetails = new AccountDetails()
        {
            AccountName = "Test Account",
            AccountNumber = 11,
            AccountType = Entities.Types.AccountType.AktieAccount,
            StartingBalance = 0
        };


        //Act
        var account = AccountFactory.CreateAccount(accountDetails);

        //Assert
        Assert.IsType<AktieAccount>(account);

    }
}
