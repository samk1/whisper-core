using System.Linq;

namespace WhisperCore
{
    using System;
    using System.IO;
    
    using WhisperCore.Format;
    
    public class WhisperWriter : IWhisperWriter
    {
        private readonly string whisperFilePath;

        public WhisperWriter(string whisperFilePath)
        {
            this.whisperFilePath = whisperFilePath;
        }

        public void Update(DateTime timestamp, double value)
        {
            using (var whisperFile = File.OpenWrite(this.whisperFilePath))
            {
                var header = new WhisperHeader(whisperFile);
                var data = new WhisperData(whisperFile, header);

                var archives = data.Archives.ToList()
                    .OrderBy(archive => archive.ArchiveInfo.SecondsPerPoint);

                var highestPrecisionArchive = archives.First();
                highestPrecisionArchive.WritePoint(timestamp, value);
            }
        }
    }
}