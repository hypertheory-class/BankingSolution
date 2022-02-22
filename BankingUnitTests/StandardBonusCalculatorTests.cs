
using BankingDomain;

namespace BankingUnitTests;

public class StandardBonusCalculatorTests
{
    [Fact]
    public void AccountsWithAppropriateBalanceGetDeposit()
    {
        var bonusCalculator = new StandardBonusCalculator();
        var balance = 10000M;
        var amountOfDeposit = 100M;

        decimal  bonus = bonusCalculator.GetBonusFor(balance, amountOfDeposit);

        Assert.Equal(10, bonus);
   
    }

    [Fact]
    public void AccountsBelowCutoffGetNoBalance()
    {
        var bonusCalculator = new StandardBonusCalculator();
        var balance = 9999.99M;
        var amountOfDeposit = 100M;

        decimal bonus = bonusCalculator.GetBonusFor(balance, amountOfDeposit);

        Assert.Equal(0, bonus);
    }
}
    