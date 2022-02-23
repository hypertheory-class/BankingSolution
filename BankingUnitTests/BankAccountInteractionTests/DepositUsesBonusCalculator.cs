
namespace BankingUnitTests.BankAccountInteractionTests;

public class DepositUsesBonusCalculator
{

    [Fact]
    public void BonusCalculatorIsUsed()
    {

        // so, if the bank account has a balance of 5000, and I deposit 100, then 42 should be added as bonus to the account.

        var account = new BankAccount(new TestDoubles.StubbedBonusCalculator());

        account.Deposit(100);

        Assert.Equal(5000M + 100 + 42, account.GetBalance());
    }
}
