namespace BankingDomain
{
    // SPOT (Single Point of Truth) for bonus calculation.
    public class StandardBonusCalculator : IDoBonusCalculations
    {
        //public decimal ForDeposit(decimal balance, decimal amountToDeposit)
        //{
        //   return GetBonusFor(balance, amountToDeposit);
        //}

        public decimal GetBonusFor(decimal balance, decimal amountOfDeposit)
        {
           if(balance >= 4000) // JFHCI
            {
                return amountOfDeposit * .10M;
            }  else
            {
                return 0;
            }
        }

        decimal IDoBonusCalculations.ForDeposit(decimal balance, decimal amountToDeposit)
        {
            return GetBonusFor(balance, amountToDeposit);
        }
    }
}