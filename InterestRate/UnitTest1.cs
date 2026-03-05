using BankApp.Factories;
using Entities.Accounts;

namespace InterestRate;

public class UnitTest1
{
    [Fact]
    public void AccountBase_CalculateInterestRate_theInterestRate()
    {
        var account = new BankAccount("test", 876, 0.01m);

        account.Deposit(9000, new DateTime (2025, 1, 1));
        var interest = account.CalculateInterestRate(2025);

        Assert.Equal(90, interest, 2);
    }

    [Fact]
    public void AccountBase_CalculateInterestRate_theInterestRate1()
    {
        var account = new BankAccount("test", 876, 0.02m);

        account.Deposit(5000, new DateTime(2025, 1, 1));
        var interest = account.CalculateInterestRate(2025);

        Assert.Equal(100, interest, 0);
    }

    [Fact]
    public void AccountBase_Deposit_theInterestRate2()
    {
        var account = new BankAccount("test", 876, 0.02m);

        var syntax = account.Deposit(12000, new DateTime(2025, 1, 1));

        Assert.Equal(false, syntax);
    }
}