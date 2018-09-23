namespace WhisperCore
{
    using System;
    using System.Buffers.Binary;

    using WhisperCore.Interfaces;

    public class WhisperPoint : IWhisperPoint
    {
        private static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        private readonly byte[] pointBuffer;

        private DateTime? timestamp;

        private double? value;

        public WhisperPoint(byte[] pointBuffer)
        {
            this.pointBuffer = pointBuffer;
        }

        public DateTime Timestamp
        {
            get
            {
                if (this.timestamp == null)
                {
                    var secondsSinceEpoch = BinaryPrimitives.ReadUInt32BigEndian(
                        this.pointBuffer.AsSpan(WhisperPointOffsets.Timestamp, sizeof(uint)));

                    this.timestamp = Epoch.AddSeconds(secondsSinceEpoch);
                }

                return this.timestamp.Value;
            }
        }

        public double Value
        {
            get
            {
                if (this.value == null)
                {
                    var doubleBuffer = this.pointBuffer.AsSpan(WhisperPointOffsets.Value, sizeof(double));
                    doubleBuffer.Reverse();
                    this.value = BitConverter.ToDouble(doubleBuffer.ToArray(), 0);
                }

                return this.value.Value;
            }
        }
    }
}