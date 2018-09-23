namespace WhisperCore
{
    using System;
    using System.Buffers.Binary;

    using WhisperCore.Interfaces;

    public class WhisperMetadata : IWhisperMetadata
    {
        private readonly byte[] metadataBuffer;

        private WhisperAggregationType? aggregationType;

        private uint? archiveCount;

        private uint? maximumRetention;

        private float? xFilesFactor;

        public WhisperMetadata(byte[] metadataBuffer)
        {
            this.metadataBuffer = metadataBuffer;
        }

        public WhisperAggregationType AggregationType
        {
            get
            {
                if (this.aggregationType == null)
                {
                    var aggregationTypeValue = BinaryPrimitives.ReadUInt32BigEndian(
                        this.metadataBuffer.AsSpan(WhisperMetadataOffsets.AggregationType, sizeof(uint)));
                    this.aggregationType = (WhisperAggregationType)aggregationTypeValue;
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