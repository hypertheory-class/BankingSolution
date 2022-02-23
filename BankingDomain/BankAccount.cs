namespace BankingDomain;


public class BankAccount
{
    private decimal balance = 5000M; // data
    private IDoBonusCalculations _accountDepositBonusCalculator;

    public BankAccount(IDoBonusCalculations accountDepositBonusCalculator)
    {
        _accountDepositBonusCalculator = accountDepositBonusCalculator;
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
            balance -= amountToWithdraw;
        }


    }

    public void Deposit(decimal amountToDeposit)
    {
        decimal bonus = _accountDepositBonusCalculator.ForDeposit(balance, amountToDeposit);
        balance += amountToDeposit + bonus;
    }
}
