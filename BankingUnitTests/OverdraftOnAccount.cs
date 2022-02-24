

using System;

namespace BankingUnitTests;

public class OverdraftOnAccount
{
    private BankAccount account;
    public OverdraftOnAccount()
    {
        account = new BankAccount(new Mock<IDoBonusCalculations>().Object, new Mock<INotifyTheFeds>().Object);
    }

    [Fact]
    public void AccountHolderCanTakeEntireBalance()
    {
       

        account.Withdraw(account.GetBalance());

        Assert.Equal(0, account.GetBalance());
    }


    [Fact]
    public void BalanceNotAffectedByOverdraft()
    {
       
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
      

        Assert.Throws<OverdraftException>(
            () => account.Withdraw(account.GetBalance() + 1));
    }
}
