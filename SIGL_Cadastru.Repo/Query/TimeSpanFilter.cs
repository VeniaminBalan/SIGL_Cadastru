using FluentDateTime;

namespace Query;

public enum TimeFilterMode 
{
    StartDate,
    EndDate,
    Mixt
}

public class TimeSpanFilter
{
    public DateOnly StartTime { get; private set; }
    public DateOnly EndTime { get; private set; }

    public TimeFilterMode FilterMode { get; private set; }
    private TimeSpanFilter(DateOnly startTime, DateOnly endTime)
    {
        StartTime = startTime;
        EndTime = endTime;
    }

    private TimeSpanFilter(DateOnly startTime, DateOnly endTime, TimeFilterMode mode)
    {
        StartTime = startTime;
        EndTime = endTime;
        FilterMode = mode;
    }

    public static TimeSpanFilter? Create(DateOnly startTime, DateOnly endTime, TimeFilterMode mode = TimeFilterMode.Mixt) 
    {
        if (startTime > endTime)
            return null;// throw exception ex: TimeSpanNotValid


        return new TimeSpanFilter(startTime, endTime);
    }
}
