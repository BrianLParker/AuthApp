namespace AuthApp.Shared.Brokers.DateTimes
{
    using System;
    public interface IDateTimeBroker
    {
        DateTimeOffset GetDateTime();
    }
}
