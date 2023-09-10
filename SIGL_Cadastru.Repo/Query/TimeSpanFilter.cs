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
    public DateOnly? StartTime { get; private set; }
    public DateOnly? EndTime { get; private set; }

    public TimeFilterMode FilterMode { get; private set; }
    private TimeSpanFilter()
    {

    }

    public static TimeSpanFilter? Create(TimeFilterMode mode, DateOnly date)
    {
        switch (mode)
        {
            case TimeFilterMode.StartDate:
                return new TimeSpanFilter 
                {
                    StartTime = date,
                    EndTime = null,
                    FilterMode= mode
                };
            case TimeFilterMode.EndDate:
                return new TimeSpanFilter
                {
                    StartTime = null,
                    EndTime = date,
                    FilterMode = mode
                };
            default:
                throw new Exception("mode time span filter invalid");
        }

    }

    public static TimeSpanFilter? Create(TimeFilterMode mode, DateOnly startDate, DateOnly endDate)
    {
        if (startDate > endDate)
            return null;


        return new TimeSpanFilter 
        {
            StartTime = startDate,
            EndTime= endDate,
            FilterMode= mode
        };

    }
}
