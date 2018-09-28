namespace WhisperCore.Format
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using WhisperCore.Format.Interfaces;

    public class WhisperArchive : IWhisperArchive
    {
        private readonly WhisperPointList points;
        
        public WhisperArchive(IWhisperArchiveInfo archiveInfo, Stream whisperFile)
        {
            this.points = new WhisperPointList(archiveInfo, whisperFile);
            this.ArchiveInfo = archiveInfo;
        }

        public IReadOnlyList<IWhisperPoint> Points => this.points;
        
        public IWhisperArchiveInfo ArchiveInfo { get; }
        
        public void WritePoint(DateTime timestamp, double value)
        {
            this.points.WritePoint(timestamp, value);
        }
    }
}