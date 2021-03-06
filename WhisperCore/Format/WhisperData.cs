﻿namespace WhisperCore.Format
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using WhisperCore.Format.Interfaces;

    public class WhisperData : IWhisperData
    {
        private readonly IWhisperHeader header;

        private readonly Stream whisperFile;

        public WhisperData(Stream whisperFile, IWhisperHeader header)
        {
            this.whisperFile = whisperFile;
            this.header = header;
        }

        public IEnumerable<IWhisperArchive> Archives
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