
namespace BankingUnitTests;

public class CalculatingBonusesForBankAccounts
{
    [Fact]
    public void AccountsWithAppropriateBalanceGetDeposit()
    {
        IDoBonusCalculations bonusCalculator = new StandardBonusCalculator();
        var balance = 4000M;
        var amountOfDeposit = 100M;

        decimal bonus = bonusCalculator.ForDeposit(balance, amountOfDeposit);

        Assert.Equal(10, bonus);

    }

    [Fact]
    public void AccountsBelowCutoffGetNoBalance()
    {
        IDoBonusCalculations bonusCalculator = new StandardBonusCalculator();
        var balance = 3999.99M;
        var amountOfDeposit = 100M;

        decimal bonus = bonusCalculator.ForDeposit(balance, amountOfDeposit);

        Assert.Equal(0, bonus);
    }
}



