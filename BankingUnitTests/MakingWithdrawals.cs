
namespace BankingUnitTests;

public class MakingWithdrawals
{

    [Theory]
    [InlineData(100)]
    [InlineData(10)]
    public void MakingAWithdrawalDecreasesTheBalance(decimal amountToWithdraw)
    {
        // Given
        var account = new BankAccount();
        var openingBalance = account.GetBalance();
       
        // When
        account.Withdraw(amountToWithdraw);

        // Then
        Assert.Equal(openingBalance - amountToWithdraw, account.GetBalance());

    }
}
