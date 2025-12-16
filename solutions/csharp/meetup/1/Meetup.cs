public enum Schedule
{
    Teenth,
    First,
    Second,
    Third,
    Fourth,
    Last
}

public class Meetup
{
    private readonly int _month;
    private readonly int _year;

    public Meetup(int month, int year)
    {
        _month = month;
        _year = year;
    }

    public DateTime Day(DayOfWeek dayOfWeek, Schedule schedule)
    {
        var daysInMonth = DateTime.DaysInMonth(_year, _month);

        var matchingDays = new List<DateTime>();

        for (int day = 1; day <= daysInMonth; day++)
        {
            var date = new DateTime(_year, _month, day);
            if (date.DayOfWeek == dayOfWeek)
            {
                matchingDays.Add(date);
            }
        }

        return schedule switch
        {
            Schedule.First => matchingDays[0],
            Schedule.Second => matchingDays[1],
            Schedule.Third => matchingDays[2],
            Schedule.Fourth => matchingDays[3],
            Schedule.Last => matchingDays[^1],
            Schedule.Teenth => matchingDays.First(d => d.Day >= 13 && d.Day <= 19),
            _ => throw new ArgumentException("Invalid schedule")
        };
    }
}