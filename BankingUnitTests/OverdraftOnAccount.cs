

using System;

namespace BankingUnitTests;

public class OverdraftOnAccount
{
    private readonly BankAccount _account;
    public OverdraftOnAccount()
    {
        _account = new BankAccount(new Mock<IDoBonusCalculations>().Object, new Mock<INotifyTheFeds>().Object);
    }

    [Fact]
    public void AccountHolderCanTakeEntireBalance()
    {
       

        _account.Withdraw(_account.GetBalance());

        Assert.Equal(0, _account.GetBalance());
    }


    [Fact]
    public void BalanceNotAffectedByOverdraft()
    {
       
        var openingBalance = _account.GetBalance();

        try
        {
            _account.Withdraw(openingBalance + 1);
        }
        catch (OverdraftException)
        {

            // Swallow the thing.
        }
        finally
        {
            // this will run if there is an exception or there isn't one.
            Assert.Equal(openingBalance, _account.GetBalance());
        }

    }

    [Fact]
    public void OverdraftThrows()
    {
        Assert.Throws<OverdraftException>(
            () => _account.Withdraw(_account.GetBalance() + 1));
    }
}
