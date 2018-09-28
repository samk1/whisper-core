

using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace WhisperCore.Format
{
    using System;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using WhisperCore.Format.Interfaces;

    public class WhisperPointList : IReadOnlyList<WhisperPoint>
    {
        private readonly WhisperPointEnumerator enumerator;
        private readonly IWhisperArchiveInfo archiveInfo;
        private readonly Stream whisperFile;

        public WhisperPointList(WhisperCore.Format.Interfaces.IWhisperArchiveInfo archiveInfo, Stream whisperFile)
        {
            this.Count = (int) archiveInfo.Points;
            this.enumerator = new WhisperPointEnumerator(whisperFile, archiveInfo);
            this.archiveInfo = archiveInfo;
            this.whisperFile = whisperFile;
        }

        public IEnumerator<WhisperPoint> GetEnumerator() => this.enumerator;
        
        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        public int Count { get; }

        public WhisperPoint this[int index] => this.enumerator.PointAt(index);

        private long GetPointOffset(DateTime timestamp)
        {
            var firstPoint = this.First();
            
            if (firstPoint.IntTimestamp == 0)
            {
                return this.archiveInfo.Offset;
            }
            else
            {
                long timeDiff = timestamp.SecondsSinceEpoch() - firstPoint.IntTimestamp;

                return this.archiveInfo.Offset +
                       ((timeDiff / this.archiveInfo.SecondsPerPoint) * WhisperPointOffsets.TotalSize);
            }
        }

        public void WritePoint(DateTime timestamp, double value)
        {
            long offset = GetPointOffset(timestamp);
            DateTime normalTimestamp = DateTimeExtensions.Epoch.AddSeconds(
                timestamp.SecondsSinceEpoch() / this.archiveInfo.SecondsPerPoint * this.archiveInfo.SecondsPerPoint);
            var point = new WhisperPoint(normalTimestamp, value);
            
            this.whisperFile.Seek(offset, SeekOrigin.Begin);
            this.whisperFile.Write(point.Buffer, 0, point.Buffer.Length);
        }
        
        private class WhisperPointEnumerator : IEnumerator<WhisperPoint>
        {
            private readonly WhisperCore.Format.Interfaces.IWhisperArchiveInfo archiveInfo;
            private readonly Stream whisperFile;
            private int index;

            public WhisperPointEnumerator(Stream whisperFile, WhisperCore.Format.Interfaces.IWhisperArchiveInfo archiveInfo)
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