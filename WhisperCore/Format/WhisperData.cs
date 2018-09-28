using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WhisperCore.Format
{
    public class WhisperData : WhisperCore.Format.Interfaces.IWhisperData
    {
        private readonly WhisperCore.Format.Interfaces.IWhisperHeader header;

        private readonly FileStream whisperFile;

        public WhisperData(FileStream whisperFile, WhisperCore.Format.Interfaces.IWhisperHeader header)
        {
            this.whisperFile = whisperFile;
            this.header = header;
        }

        public IEnumerable<WhisperCore.Format.Interfaces.IWhisperArchive> Archives
        {
            get
            {
                var i = 0;
                while (i < this.header.ArchiveInfo.Count())
                {
                    var currentArchiveInfo = this.header.ArchiveInfo.ElementAt(i);
                    yield return new WhisperArchive(currentArchiveInfo, this.whisperFile);
                    i++;
                }
            }
        }
    }
}