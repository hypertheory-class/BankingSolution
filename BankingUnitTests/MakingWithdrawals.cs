
namespace BankingUnitTests;

public class MakingWithdrawals
{

    [Theory]
    [InlineData(100)]
    [InlineData(10)]
    [InlineData(10.25)]
    public void MakingAWithdrawalDecreasesTheBalance(decimal amountToWithdraw)
    {
        // Given
        var account = new BankAccount(new Mock<IDoBonusCalculations>().Object);
        var openingBalance = account.GetBalance();
       
        // When
        account.Withdraw(amountToWithdraw);

        // Then
        Assert.Equal(openingBalance - amountToWithdraw, account.GetBalance());

    }
}
