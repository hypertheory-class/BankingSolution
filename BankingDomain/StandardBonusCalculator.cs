namespace BankingDomain
{
    // SPOT (Single Point of Truth) for bonus calculation.
    public class StandardBonusCalculator : IDoBonusCalculations
    {
        //public decimal ForDeposit(decimal balance, decimal amountToDeposit)
        //{
        //   return GetBonusFor(balance, amountToDeposit);
        //}
        private readonly IProvideTheBusinessClock _businessClock;

        public StandardBonusCalculator(IProvideTheBusinessClock businessClock)
        {
            _businessClock = businessClock;
        }

        public decimal GetBonusFor(decimal balance, decimal amountOfDeposit)
        {
            var bonusModifier = .10M;
            if (_businessClock.IsDuringBusinessHours())
            {
                bonusModifier += .01M;

            }

            if (balance >= 4000) // JFHCI
            {
                return amountOfDeposit * bonusModifier;
            }
            else
            {
                return 0;
            }

        }

        private bool DuringBusinessHours()
        {
            return DateTime.Now.Hour >= 9 && DateTime.Now.Hour < 17;
        }

        decimal IDoBonusCalculations.ForDeposit(decimal balance, decimal amountToDeposit)
        {
            return GetBonusFor(balance, amountToDeposit);
        }
    }
}