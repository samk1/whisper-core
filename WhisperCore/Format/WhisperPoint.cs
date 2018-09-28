using System;
using System.Buffers.Binary;
using System.Linq;

namespace WhisperCore.Format
{
    public class WhisperPoint : WhisperCore.Format.Interfaces.IWhisperPoint
    {
        private static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public WhisperPoint(byte[] buffer)
        {
            var secondsSinceEpoch = BinaryPrimitives.ReadUInt32BigEndian(
                buffer.AsSpan(WhisperPointOffsets.Timestamp, sizeof(uint)));

            this.Timestamp = Epoch.AddSeconds(secondsSinceEpoch);

            var doubleBuffer = new byte[sizeof(double)];
            buffer.AsSpan(WhisperPointOffsets.Value, sizeof(double)).CopyTo(doubleBuffer);
            this.Value = BitConverter.ToDouble(doubleBuffer.Reverse().ToArray(), 0);

            this.Buffer = buffer;
        }

        public WhisperPoint(DateTime timestamp, double value)
        {
            this.Timestamp = timestamp;
            this.Value = value;
            
            byte[] buffer = new byte[WhisperPointOffsets.TotalSize];
            
            uint secondsSinceEpoch = (uint) (((TimeSpan) (timestamp - Epoch)).TotalSeconds);
                        
            BinaryPrimitives.WriteUInt32BigEndian(
                buffer.AsSpan(WhisperPointOffsets.Timestamp, sizeof(uint)), secondsSinceEpoch);
            
            BitConverter.GetBytes(value).Reverse().ToArray()
                .CopyTo(buffer.AsSpan(WhisperPointOffsets.Value, sizeof(double)));

            this.Buffer = buffer;
        }

        public DateTime Timestamp { get; }

        public double Value { get; }

        public byte[] Buffer { get; }
    }
}