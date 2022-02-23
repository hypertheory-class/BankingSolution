
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
        var openingBalance = account.GetBalance();
        stubbedBonusCalculator.Setup(c => c.ForDeposit(openingBalance, 100)).Returns(5323);

        // When
        account.Deposit(100);


        // Then
        Assert.Equal(openingBalance + 100 + 5323, account.GetBalance());
    }
}
