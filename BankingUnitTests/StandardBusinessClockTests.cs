
namespace BankingUnitTests;

public class StandardBusinessClockTests
{
    [Fact]
    public void CanTellUsWhenItIsDuringBusinessHours()
    {
        var fakeClock = new Mock<ISystemTime>();
        var clock = new StandardBusinessClock(fakeClock.Object);
        fakeClock.Setup(c => c.GetCurrent()).Returns(new System.DateTime(1969, 4, 20, 9, 01, 00));

        Assert.True(clock.IsDuringBusinessHours());
    }


    [Fact]
    public void CanTellUsWhenItIsOutsideBusinessHours()
    {
        var fakeClock = new Mock<ISystemTime>();
        var clock = new StandardBusinessClock(fakeClock.Object);
        fakeClock.Setup(c => c.GetCurrent()).Returns(new System.DateTime(1969, 4, 20, 17, 00, 00));

        Assert.False(clock.IsDuringBusinessHours());
    }
}
