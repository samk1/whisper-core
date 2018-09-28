using System.Collections.Generic;
using System.IO;

namespace WhisperCore.Format
{
    public class WhisperArchive : WhisperCore.Format.Interfaces.IWhisperArchive
    {
        public WhisperArchive(WhisperCore.Format.Interfaces.IWhisperArchiveInfo archiveInfo, FileStream whisperFile)
        {
            this.Points = new WhisperPointList(archiveInfo, whisperFile);
        }

        public IReadOnlyList<WhisperCore.Format.Interfaces.IWhisperPoint> Points { get; }
    }
}