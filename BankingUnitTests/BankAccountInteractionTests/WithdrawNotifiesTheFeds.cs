
namespace BankingUnitTests.BankAccountInteractionTests;

public class WithdrawNotifiesTheFeds
{
    [Theory]
    [InlineData(100)]
    [InlineData(42)]
    public void FedIsNotifiedOnSuccessfulWithdraw(decimal amountToWithdraw)
    {
        // Given
        var mockedFed = new Mock<INotifyTheFeds>();
        var account = new BankAccount(new Mock<IDoBonusCalculations>().Object, mockedFed.Object);
        // When
        account.Withdraw(amountToWithdraw);

        // Then
        // ??? WHAT? We can't look at the account to know this happened,
        // like with the bonus calculation - the balance on the account changed there
        // nothing about the account (the "State" of the account) changes here, but
        // It is still super important.

        mockedFed.Verify(f => f.AccountWithdrawn(account, amountToWithdraw), Times.Once);
  
    }

    [Fact]
    public void FedIsNotNotifiedOnOverdraft()
    {
        // Given
        var mockedFed = new Mock<INotifyTheFeds>();
        var account = new BankAccount(new Mock<IDoBonusCalculations>().Object, mockedFed.Object);
        // When
        try
        {
            account.Withdraw(account.GetBalance() + .01M);
        }
        catch (System.Exception)
        {

            // just ignore the exception, we are just making sure the fed isn't notified if anything goes wrong
        }

        // Then
        // ??? WHAT? We can't look at the account to know this happened,
        // like with the bonus calculation - the balance on the account changed there
        // nothing about the account (the "State" of the account) changes here, but
        // It is still super important.

        mockedFed.Verify(f => f.AccountWithdrawn(It.IsAny<BankAccount>(), It.IsAny<decimal>()), Times.Never);

    }
}
