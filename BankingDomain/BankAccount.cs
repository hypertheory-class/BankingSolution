namespace BankingDomain;


public enum AccountType {  Standard, Gold };
public class BankAccount
{
    public AccountType Type = AccountType.Standard;
    private decimal balance = 5000M; // data
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
        //balance = Type switch
        //{
        //    AccountType.Standard => balance += amountToDeposit,
        //    AccountType.Gold => balance += amountToDeposit * 1.10M,
        //    _ => balance
        //};
        balance = Type == AccountType.Standard ? balance += amountToDeposit : balance += amountToDeposit * 1.10M;
    }
}
