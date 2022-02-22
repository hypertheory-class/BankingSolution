

namespace BankingUnitTests;

public class OverdraftOnAccount
{



    [Fact]
    public void BalanceNotAffectedByOverdraft()
    {
        var account = new BankAccount();
        var openingBalance = account.GetBalance();

        account.Withdraw(openingBalance + 1);

        Assert.Equal(openingBalance, account.GetBalance());
    }
}
