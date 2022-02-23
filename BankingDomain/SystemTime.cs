

namespace BankingDomain;

public class SystemTime : ISystemTime
{
    public DateTime GetCurrent()
    {
        return DateTime.Now; // This is the ONLY place in the whole application you are allowed to do this.
    }
}