using System.Collections.Generic;

namespace WhisperCore.Format.Interfaces
{
    public interface IWhisperArchive
    {
        IReadOnlyList<IWhisperPoint> Points { get; }
    }
}