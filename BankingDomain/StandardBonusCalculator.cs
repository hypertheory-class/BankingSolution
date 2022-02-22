namespace BankingDomain
{
    public class StandardBonusCalculator
    {
       

        public decimal GetBonusFor(decimal balance, decimal amountOfDeposit)
        {
           if(balance >= 10000) // JFHCI
            {
                return amountOfDeposit * .10M;
            }  else
            {
                return 0;
            }
        }
    }
}