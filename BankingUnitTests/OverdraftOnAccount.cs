

using System;

namespace BankingUnitTests;

public class OverdraftOnAccount
{
    [Fact]
    public void AccountHolderCanTakeEntireBalance()
    {
        var account = new BankAccount(new Mock<IDoBonusCalculations>().Object);

        account.Withdraw(account.GetBalance());

        Assert.Equal(0, account.GetBalance());
    }


    [Fact]
    public void BalanceNotAffectedByOverdraft()
    {
        var account = new BankAccount(new Mock<IDoBonusCalculations>().Object);
        var openingBalance = account.GetBalance();

        try
        {
            account.Withdraw(openingBalance + 1);
        }
        catch (OverdraftException)
        {

            // Swallow the thing.
        }
        finally
        {
            // this will run if there is an exception or there isn't one.
            Assert.Equal(openingBalance, account.GetBalance());
        }

    }

    [Fact]
    public void OverdraftThrows()
    {
        var account = new BankAccount(new Mock<IDoBonusCalculations>().Object);

        Assert.Throws<OverdraftException>(
            () => account.Withdraw(account.GetBalance() + 1));
    }
}
