namespace Music_Backend.Utils
{
    public class DateTimeExtensions
    {
        public static DateTimeOffset? ConvertToTimeZone(DateTimeOffset? date, int timeZone)
        {
            if (timeZone < -12 || timeZone > 12)
                return date;
            return new DateTimeOffset(
                date.Value.Year, date.Value.Month, date.Value.Day,
                date.Value.Hour, date.Value.Minute, date.Value.Second
                , TimeSpan.FromHours(timeZone));
        }
    }
}
