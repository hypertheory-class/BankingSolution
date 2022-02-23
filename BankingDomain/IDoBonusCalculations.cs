namespace BankingDomain
{
    public interface IDoBonusCalculations
    {
        decimal ForDeposit(decimal balance, decimal amountToDeposit);
    }
}