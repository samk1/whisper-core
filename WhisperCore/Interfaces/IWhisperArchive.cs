namespace WhisperCore.Interfaces
{
    using System.Collections.Generic;

    public interface IWhisperArchive
    {
        IReadOnlyList<IWhisperPoint> Points { get; }
    }
}