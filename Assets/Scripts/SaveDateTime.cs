public class SaveDateTime
{
    private readonly int _year;
    private readonly int _month;
    private readonly int _day;

    private readonly int _hour;
    private readonly int _minute;
    private readonly int _second;
    private readonly int _milliseconds;

    public SaveDateTime(int year, int month, int day, int hour, int minute, int second, int milliseconds)
    {
        _year = year;
        _month = month;
        _day = day;
        _hour = hour;
        _minute = minute;
        _second = second;
        _milliseconds = milliseconds;
    }

    public override string ToString()
    {
        return $"{_year}:{_month}:{_day}:{_hour}:{_minute}:{_second}:{_milliseconds}";
    }

    public string DateTimeGet()
    {
        return ToString();
    }
}
