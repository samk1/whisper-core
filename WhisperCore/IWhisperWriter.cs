namespace WhisperCore
{
    using System;
    using WhisperCore.Format;
    
    public interface IWhisperWriter
    {
        void Update(DateTime timestamp, double value);
    }
}