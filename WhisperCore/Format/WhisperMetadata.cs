using System;
using System.Buffers.Binary;

namespace WhisperCore.Format
{
    public class WhisperMetadata : WhisperCore.Format.Interfaces.IWhisperMetadata
    {
        private readonly byte[] metadataBuffer;

        private WhisperCore.Format.Interfaces.WhisperAggregationType? aggregationType;

        private uint? archiveCount;

        private uint? maximumRetention;

        private float? xFilesFactor;

        public WhisperMetadata(byte[] metadataBuffer)
        {
            this.metadataBuffer = metadataBuffer;
        }

        public WhisperCore.Format.Interfaces.WhisperAggregationType AggregationType
        {
            get
            {
                if (this.aggregationType == null)
                {
                    var aggregationTypeValue = BinaryPrimitives.ReadUInt32BigEndian(
                        this.metadataBuffer.AsSpan(WhisperMetadataOffsets.AggregationType, sizeof(uint)));
                    this.aggregationType = (WhisperCore.Format.Interfaces.WhisperAggregationType)aggregationTypeValue;
                }

                return this.aggregationType.Value;
            }
        }

        public uint ArchiveCount
        {
            get
            {
                if (this.archiveCount == null)
                {
                    this.archiveCount = BinaryPrimitives.ReadUInt32BigEndian(
                        this.metadataBuffer.AsSpan(WhisperMetadataOffsets.ArchiveCount, sizeof(uint)));
                }

                return this.archiveCount.Value;
            }
        }

        public uint MaximumRetention
        {
            get
            {
                if (this.maximumRetention == null)
                {
                    this.maximumRetention = BinaryPrimitives.ReadUInt32BigEndian(
                        this.metadataBuffer.AsSpan(WhisperMetadataOffsets.MaximumRetention, sizeof(uint)));
                }

                return this.maximumRetention.Value;
            }
        }

        public float XFilesFactor
        {
            get
            {
                if (this.xFilesFactor == null)
                {
                    var floatBuffer = this.metadataBuffer.AsSpan(WhisperMetadataOffsets.XFilesFactor, sizeof(float));
                    floatBuffer.Reverse();
                    this.xFilesFactor = BitConverter.ToSingle(floatBuffer.ToArray(), 0);
                }

                return this.xFilesFactor.Value;
            }
        }
    }
}