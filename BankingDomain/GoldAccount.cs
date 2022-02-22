namespace BankingDomain;

public class GoldAccount : BankAccount
{
    public override void Deposit(decimal amountToDeposit)
    {
        // this is going to run when the instance of the class is a Gold Account.
        // for BankAccounts, use the one in the base class.
        base.Deposit(amountToDeposit * 1.10M);
    }

    public void SendGiftToaster()
    {

    }
}
