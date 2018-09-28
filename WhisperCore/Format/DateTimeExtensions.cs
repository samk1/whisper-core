namespace WhisperCore.Format
{
    using System;

    public static class DateTimeExtensions
    {
        public static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        
        public static int SecondsSinceEpoch(this DateTime dateTime)
        {
            return (int) (dateTime - Epoch).TotalSeconds;
        }
    }
}