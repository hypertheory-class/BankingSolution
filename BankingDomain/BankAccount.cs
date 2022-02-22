namespace BankingDomain;

public class BankAccount
{
    private decimal balance = 5000M; // data
    public decimal GetBalance() // behavior
    {
        return balance; // "Sliming"
    }

    public void Withdraw(decimal amountToWithdraw) // behavior
    {
        balance -= amountToWithdraw;
    }

    public void Deposit(decimal amountToDeposit)
    {
        balance += amountToDeposit;
    }
}
