namespace WhisperCore.Format
{
    using System.Collections.Generic;
    using System.IO;
    using WhisperCore.Format.Interfaces;

    public class WhisperHeader : IWhisperHeader
    {
        private readonly Stream whisperFile;

        private IWhisperMetadata metadata;

        public WhisperHeader(Stream whisperFile)
        {
            this.whisperFile = whisperFile;
        }

        public IEnumerable<IWhisperArchiveInfo> ArchiveInfo
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

        public IWhisperMetadata Metadata
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