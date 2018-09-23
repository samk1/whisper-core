namespace WhisperCore.Interfaces
{
    using System.Collections.Generic;

    public interface IWhisperArchive
    {
        IEnumerable<IWhisperPoint> Points { get; }
    }
}