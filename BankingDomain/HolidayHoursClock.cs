

namespace BankingDomain;

public class HolidayHoursClock : IProvideTheBusinessClock

{
    private readonly ISystemTime _clock;

    public HolidayHoursClock(ISystemTime clock)
    {
        _clock = clock;
    }

    public bool IsDuringBusinessHours()
    {
        return _clock.GetCurrent().Hour >= 9 && _clock.GetCurrent().Hour <= 20;
    }
}
