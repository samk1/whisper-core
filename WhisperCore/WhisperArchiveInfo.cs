namespace WhisperCore
{
    using System;
    using System.Buffers.Binary;

    using WhisperCore.Interfaces;

    public class WhisperArchiveInfo : IWhisperArchiveInfo
    {
        private readonly byte[] archiveInfoBuffer;

        private uint? offset;

        private uint? points;

        private uint? secondsPerPoint;

        public WhisperArchiveInfo(byte[] archiveInfoBuffer)
        {
            this.archiveInfoBuffer = archiveInfoBuffer;
        }

        public uint Offset
        {
            get
            {
                if (this.offset == null)
                {
                    this.offset = BinaryPrimitives.ReadUInt32BigEndian(
                        this.archiveInfoBuffer.AsSpan(WhisperArchiveInfoOffsets.Offset, sizeof(uint)));
                }

                return this.offset.Value;
            }
        }

        public uint Points
        {
            get
            {
                if (this.points == null)
                {
                    this.points = BinaryPrimitives.ReadUInt32BigEndian(
                        this.archiveInfoBuffer.AsSpan(WhisperArchiveInfoOffsets.Points, sizeof(uint)));
                }

                return this.points.Value;
            }
        }

        public uint SecondsPerPoint
        {
            get
            {
                if (this.secondsPerPoint == null)
                    this.secondsPerPoint = BinaryPrimitives.ReadUInt32BigEndian(
                        this.archiveInfoBuffer.AsSpan(WhisperArchiveInfoOffsets.SecondsPerPoint, sizeof(uint)));

                return this.secondsPerPoint.Value;
            }
        }
    }
}