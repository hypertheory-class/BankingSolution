
namespace BankingUnitTests;

public class GoldAccountsGetBonusOnDeposit
{
    [Fact]
    public void GetsABonusOnDeposit()
    {

        // "Doing the same thing more than once but expecting different results"
        var account = new BankAccount();
        account.Type = AccountType.Gold;
        var openingBalance = account.GetBalance();
        var amountToDeposit = 100M;

        account.Deposit(amountToDeposit);

        Assert.Equal(
            openingBalance + amountToDeposit + 10M,
            account.GetBalance());


    }
}
