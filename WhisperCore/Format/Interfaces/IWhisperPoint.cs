using System;

namespace WhisperCore.Format.Interfaces
{
    public interface IWhisperPoint
    {
        DateTime Timestamp { get; }

        double Value { get; }
        
        byte[] Buffer { get; }
    }
}