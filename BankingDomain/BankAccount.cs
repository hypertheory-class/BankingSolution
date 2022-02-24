namespace BankingDomain;


public class BankAccount
{
    private decimal balance = 5000M; // data
    private IDoBonusCalculations _accountDepositBonusCalculator;
    private INotifyTheFeds _fedNotifier;

    public BankAccount(IDoBonusCalculations accountDepositBonusCalculator, INotifyTheFeds fedNotifier)
    {
        _accountDepositBonusCalculator = accountDepositBonusCalculator;
        _fedNotifier = fedNotifier;
    }

    public decimal GetBalance() // behavior
    {
        return balance; // "Sliming"
    }

    public void Withdraw(decimal amountToWithdraw) // behavior
    {
        if (amountToWithdraw > balance)
        {

            throw new OverdraftException();
        }
        else
        {
            // Writing the Code You Wish You Had
            _fedNotifier.AccountWithdrawn(this, amountToWithdraw);
            balance -= amountToWithdraw;
        }


    }

    public void Deposit(decimal amountToDeposit)
    {
        decimal bonus = _accountDepositBonusCalculator.ForDeposit(balance, amountToDeposit);
        balance += amountToDeposit + bonus;
    }
}
