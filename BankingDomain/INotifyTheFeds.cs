namespace BankingDomain
{
    public interface INotifyTheFeds
    {
        void AccountWithdrawn(BankAccount bankAccount, decimal amountToWithdraw);
    }
}