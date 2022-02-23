

namespace BankingUnitTests.TestDoubles;

public class StubbedBonusCalculator : IDoBonusCalculations
{
    public decimal ForDeposit(decimal balance, decimal amountToDeposit)
    {
        if(balance == 5000M && amountToDeposit == 100)
        {
            return 42;
        } else
        {
            return 0;
        }
    }
}
