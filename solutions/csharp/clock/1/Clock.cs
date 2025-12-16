
public class Clock : IEquatable<Clock>
{
    private readonly int minutes; // total minutes from 00:00

    public Clock(int hours, int minutes)
    {
        this.minutes = Normalize(hours * 60 + minutes);
    }

    private static int Normalize(int totalMinutes)
    {
        int minutesInDay = 24 * 60;
        totalMinutes %= minutesInDay;
        if (totalMinutes < 0)
            totalMinutes += minutesInDay;
        return totalMinutes;
    }

    public Clock Add(int minutesToAdd)
    {
        return new Clock(0, minutes + minutesToAdd);
    }

    public Clock Subtract(int minutesToSubtract)
    {
        return Add(-minutesToSubtract);
    }

    public override string ToString()
    {
        int h = minutes / 60;
        int m = minutes % 60;
        return $"{h:D2}:{m:D2}";
    }

    // === Equality ===
    public bool Equals(Clock other)
    {
        if (ReferenceEquals(other, null))
            return false;

        return minutes == other.minutes;
    }

    public override bool Equals(object obj)
    {
        return Equals(obj as Clock);
    }

    public override int GetHashCode()
    {
        return minutes.GetHashCode();
    }

    public static bool operator ==(Clock a, Clock b)
    {
        if (ReferenceEquals(a, b))
            return true;
        if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
            return false;

        return a.minutes == b.minutes;
    }

    public static bool operator !=(Clock a, Clock b)
    {
        return !(a == b);
    }
}
