


using BankingDomain;
using Xunit;

namespace BankingUnitTests;

public class NewBankAccounts
{
    [Fact]
    public void NewAccountsHaveCorrectOpeningBalance()
    {
        
        // WTCYWYH (Write the code you wish you had)
        // Given - we have a new bank account
        var account = new BankAccount(new Mock<IDoBonusCalculations>().Object);
        // When - I get the balance of that account
        decimal balance = account.GetBalance();
        // Then - it should be 5K
        Assert.Equal(5000M, balance);
    }
}
