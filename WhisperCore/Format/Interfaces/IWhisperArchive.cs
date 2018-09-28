using System.Collections.Generic;

namespace WhisperCore.Format.Interfaces
{
    using System;

    public interface IWhisperArchive
    {
        IReadOnlyList<IWhisperPoint> Points { get; }
        
        IWhisperArchiveInfo ArchiveInfo { get; }

        void WritePoint(DateTime timestamp, double value);
    }
}