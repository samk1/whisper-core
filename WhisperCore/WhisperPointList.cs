

namespace WhisperCore
{
    using System.IO;
    using System.Collections;
    using System.Collections.Generic;
    
    using WhisperCore.Interfaces;

    public class WhisperPointList : IReadOnlyList<WhisperPoint>
    {
        private readonly WhisperPointEnumerator enumerator;

        public WhisperPointList(IWhisperArchiveInfo archiveInfo, FileStream whisperFile)
        {
            this.Count = (int) archiveInfo.Points;
            this.enumerator = new WhisperPointEnumerator(whisperFile, archiveInfo);
        }

        public IEnumerator<WhisperPoint> GetEnumerator() => this.enumerator;
        
        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        public int Count { get; }

        public WhisperPoint this[int index] => this.enumerator.PointAt(index);
        
        private class WhisperPointEnumerator : IEnumerator<WhisperPoint>
        {
            private readonly IWhisperArchiveInfo archiveInfo;
            private readonly FileStream whisperFile;
            private int index;

            public WhisperPointEnumerator(FileStream whisperFile, IWhisperArchiveInfo archiveInfo)
            {
                this.whisperFile = whisperFile;
                this.archiveInfo = archiveInfo;
            }
        
            public bool MoveNext()
            {
                this.index++;
                return this.index <= this.archiveInfo.Points;
            }

            public void Reset()
            {
                this.index = 0;
            }

            public WhisperPoint Current => this.PointAt(this.index);
            

            object IEnumerator.Current => this.Current;
        
            public void Dispose()
            {
            }

            public WhisperPoint PointAt(int i)
            {
                var currentOffset =
                    this.archiveInfo.Offset + (i * WhisperPointOffsets.TotalSize);
                var pointBuffer = new byte[WhisperPointOffsets.TotalSize];
                
                this.whisperFile.Seek(currentOffset, SeekOrigin.Begin);
                this.whisperFile.Read(pointBuffer, 0, pointBuffer.Length);
                
                return new WhisperPoint(pointBuffer);
            }
        }
    }
}