
namespace BankingUnitTests;

public class MakingWithdrawals
{

    [Fact]
    public void MakingAWithdrawalDecreasesTheBalance()
    {
        // Given
        var account = new BankAccount();
        var openingBalance = account.GetBalance();
        var amountToWithdraw = 100M;

        // When
        account.Withdraw(amountToWithdraw);

        // Then
        Assert.Equal(openingBalance - amountToWithdraw, account.GetBalance());

    }
}
