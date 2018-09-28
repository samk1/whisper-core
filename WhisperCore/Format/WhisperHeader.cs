using System.Collections.Generic;
using System.IO;

namespace WhisperCore.Format
{
    public class WhisperHeader : WhisperCore.Format.Interfaces.IWhisperHeader
    {
        private readonly FileStream whisperFile;

        private WhisperCore.Format.Interfaces.IWhisperMetadata metadata;

        public WhisperHeader(FileStream whisperFile)
        {
            this.whisperFile = whisperFile;
        }

        public IEnumerable<WhisperCore.Format.Interfaces.IWhisperArchiveInfo> ArchiveInfo
        {
            get
            {
                var archiveCount = this.Metadata.ArchiveCount;
                var i = 0;

                while (i < archiveCount)
                {
                    var archiveInfoBuffer = new byte[WhisperHeaderOffsets.ArchiveInfoSize];
                    var currentOffset = WhisperHeaderOffsets.ArchiveInfo + (i * WhisperHeaderOffsets.ArchiveInfoSize);
                    this.whisperFile.Seek(currentOffset, SeekOrigin.Begin);
                    this.whisperFile.Read(archiveInfoBuffer, 0, archiveInfoBuffer.Length);
                    yield return new WhisperArchiveInfo(archiveInfoBuffer);
                    i++;
                }
            }
        }

        public WhisperCore.Format.Interfaces.IWhisperMetadata Metadata
        {
            get
            {
                if (this.metadata == null)
                {
                    var metadataBuffer = new byte[WhisperHeaderOffsets.MetadataSize];
                    this.whisperFile.Seek(WhisperHeaderOffsets.Metadata, SeekOrigin.Begin);
                    this.whisperFile.Read(metadataBuffer, 0, metadataBuffer.Length);
                    this.metadata = new WhisperMetadata(metadataBuffer);
                }

                return this.metadata;
            }
        }
    }
}