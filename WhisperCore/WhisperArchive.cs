namespace WhisperCore
{
    using System.Collections.Generic;
    using System.IO;

    using WhisperCore.Interfaces;

    public class WhisperArchive : IWhisperArchive
    {
        public WhisperArchive(IWhisperArchiveInfo archiveInfo, FileStream whisperFile)
        {
            this.Points = new WhisperPointList(archiveInfo, whisperFile);
        }

        public IReadOnlyList<IWhisperPoint> Points { get; }
    }
}