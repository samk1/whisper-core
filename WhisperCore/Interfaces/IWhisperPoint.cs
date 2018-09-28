namespace WhisperCore.Interfaces
{
    using System;

    public interface IWhisperPoint
    {
        DateTime Timestamp { get; }

        double Value { get; }
        
        byte[] Buffer { get; }
    }
}