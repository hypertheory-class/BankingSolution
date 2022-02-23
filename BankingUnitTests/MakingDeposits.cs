

namespace BankingUnitTests;

public class MakingDeposits
{

    [Theory]
    [InlineData(100)]
    [InlineData(200.10)]
    [InlineData(1.25)]
    public void DepositingIncreasesBalance(decimal amountToDeposit)
    {
        // Given - Create the entire isolated universe that you are testing. (Arrange)
        var account = new BankAccount(new TestDoubles.DummyBonusCalculator());
        var openingBalance = account.GetBalance();
        // When (Act)
        account.Deposit(amountToDeposit);
        // Then (Assert)
       
        Assert.Equal(
            openingBalance + amountToDeposit,
            account.GetBalance());
    }
}
