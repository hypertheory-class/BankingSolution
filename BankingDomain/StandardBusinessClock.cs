

namespace BankingDomain;

public class StandardBusinessClock : IProvideTheBusinessClock
{
    private readonly ISystemTime _clock;

    public StandardBusinessClock(ISystemTime clock)
    {
        _clock = clock;
    }

    public bool IsDuringBusinessHours()
    {
        return _clock.GetCurrent().Hour >= 9 && _clock.GetCurrent().Hour < 17;
    }
}
