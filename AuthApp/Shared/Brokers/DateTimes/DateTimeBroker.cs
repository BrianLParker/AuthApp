namespace AuthApp.Shared.Brokers.DateTimes
{
    using System;

    public class DateTimeBroker : IDateTimeBroker
    {
        public DateTimeOffset GetDateTime() => DateTimeOffset.UtcNow;
    }
}
