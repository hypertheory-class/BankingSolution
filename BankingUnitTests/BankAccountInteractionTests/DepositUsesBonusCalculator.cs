
namespace BankingUnitTests.BankAccountInteractionTests;

public class DepositUsesBonusCalculator
{

    [Fact]
    public void BonusCalculatorIsUsed()
    {

        // so, if the bank account has a balance of 5000, and I deposit 100, then 42 should be added as bonus to the account.
        // Given
        var stubbedBonusCalculator = new Mock<IDoBonusCalculations>();
        var account = new BankAccount(stubbedBonusCalculator.Object);
        stubbedBonusCalculator.Setup(c => c.ForDeposit(account.GetBalance(), 100)).Returns(42);

        // When
        account.Deposit(100);


        // Then
        Assert.Equal(5000M + 100 + 42, account.GetBalance());
    }
}
