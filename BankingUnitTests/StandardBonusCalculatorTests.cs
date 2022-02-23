
using BankingDomain;

namespace BankingUnitTests;

public class StandardBonusCalculatorTests
{
    [Fact]
    public void AccountsWithAppropriateBalanceGetBonusDuringBusinessHours()
    {
        // Given - it is during business hours and they have a big enough balance
        var stubbedClock = new Mock<IProvideTheBusinessClock>();
        var bonusCalculator = new StandardBonusCalculator(stubbedClock.Object);
        stubbedClock.Setup(c => c.IsDuringBusinessHours()).Returns(true);
        var balance = 4000M;
        var amountOfDeposit = 100M;

        decimal  bonus = bonusCalculator.GetBonusFor(balance, amountOfDeposit);

        Assert.Equal(11, bonus);
   
    }

    [Fact]
    public void AccountsWithAppropriateBalanceGetBonusOutsideBusinessHours()
    {
        // Given - it is outside business hours they don't get the additional bonus
        var stubbedClock = new Mock<IProvideTheBusinessClock>();
        var bonusCalculator = new StandardBonusCalculator(stubbedClock.Object);
        stubbedClock.Setup(c => c.IsDuringBusinessHours()).Returns(false);
        var balance = 4000M;
        var amountOfDeposit = 100M;

        decimal bonus = bonusCalculator.GetBonusFor(balance, amountOfDeposit);

        Assert.Equal(10, bonus);

    }

    [Fact]
    public void AccountsBelowCutoffGetNoBalanceDuringBusinessHours()
    {
        var stubbedClock = new Mock<IProvideTheBusinessClock>();
        var bonusCalculator = new StandardBonusCalculator(stubbedClock.Object);
        stubbedClock.Setup(c => c.IsDuringBusinessHours()).Returns(true);
        var balance = 3999.99M;
        var amountOfDeposit = 100M;

        decimal bonus = bonusCalculator.GetBonusFor(balance, amountOfDeposit);

        Assert.Equal(0, bonus);
    }

    [Fact]
    public void AccountsBelowCutoffGetNoBalanceOutsideBusinessHours()
    {
        var stubbedClock = new Mock<IProvideTheBusinessClock>();
        var bonusCalculator = new StandardBonusCalculator(stubbedClock.Object);
        stubbedClock.Setup(c => c.IsDuringBusinessHours()).Returns(false);
        var balance = 3999.99M;
        var amountOfDeposit = 100M;

        decimal bonus = bonusCalculator.GetBonusFor(balance, amountOfDeposit);

        Assert.Equal(0, bonus);
    }
}
    