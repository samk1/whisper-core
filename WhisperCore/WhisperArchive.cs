namespace WhisperCore
{
    using System.Collections.Generic;
    using System.IO;

    using WhisperCore.Interfaces;

    public class WhisperArchive : IWhisperArchive
    {
        private readonly IWhisperArchiveInfo archiveInfo;

        private readonly FileStream whisperFile;

        public WhisperArchive(IWhisperArchiveInfo archiveInfo, FileStream whisperFile)
        {
            this.archiveInfo = archiveInfo;
            this.whisperFile = whisperFile;
        }

        public IEnumerable<IWhisperPoint> Points
        {
            get
            {
                var archiveOffset = this.archiveInfo.Offset;
                var i = 0;

                while (i < this.archiveInfo.Points)
                {
                    var currentOffset = archiveOffset + (i * WhisperPointOffsets.TotalSize);
                    var pointBuffer = new byte[WhisperPointOffsets.TotalSize];
                    this.whisperFile.Seek(currentOffset, SeekOrigin.Begin);
                    this.whisperFile.Read(pointBuffer, 0, pointBuffer.Length);

                    yield return new WhisperPoint(pointBuffer);

                    i++;
                }
            }
        }
    }
}