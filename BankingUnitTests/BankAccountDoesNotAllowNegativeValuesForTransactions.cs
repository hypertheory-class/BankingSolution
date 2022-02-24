

using BankingDomain;

namespace BankingUnitTests;

public class BankAccountDoesNotAllowNegativeValuesForTransactions
{



    [Fact]
    public void DepositingANegativeValueDoesNotImpactBalance()
    {
        var account = new BankAccount(new Mock<IDoBonusCalculations>().Object, new Mock<INotifyTheFeds>().Object);
        var openingBalance = account.GetBalance();

        try
        {
            account.Deposit(-100);
        }
        catch (NoNegativeTransactionAmountsException)
        {

           // ignore thing..
        }

        Assert.Equal(openingBalance, account.GetBalance());
    }

    [Fact]
    public void DepositingANegativeValueThrowsAnException()
    {
        var account = new BankAccount(new Mock<IDoBonusCalculations>().Object, new Mock<INotifyTheFeds>().Object);
        var openingBalance = account.GetBalance();

        Assert.Throws<NoNegativeTransactionAmountsException>(() => account.Deposit(-100));


    }
}
