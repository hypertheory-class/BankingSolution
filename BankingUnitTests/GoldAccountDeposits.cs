

using BankingDomain;

namespace BankingUnitTests;

public class GoldAccountDeposits
{
    [Fact]
    public void GetBonusOnDeposit()
    {
        var account = new GoldAccount();
        var openingBalance = account.GetBalance();
        var amountToDeposit = 100M;

        account.Deposit(amountToDeposit);

        Assert.Equal(
            openingBalance + amountToDeposit + 10M,
            account.GetBalance());
    }
}
