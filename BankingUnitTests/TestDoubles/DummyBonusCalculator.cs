

namespace BankingUnitTests.TestDoubles;

public class DummyBonusCalculator : IDoBonusCalculations
{
    public decimal ForDeposit(decimal balance, decimal amountToDeposit)
    {
        // I don't care. Whatever.
        return 0;
    }
}
