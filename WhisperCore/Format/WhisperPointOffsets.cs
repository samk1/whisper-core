namespace WhisperCore.Format
{
    public static class WhisperPointOffsets
    {
        public const int Timestamp = 0;

        public const int TotalSize = sizeof(uint) + sizeof(double);

        public const int Value = 4;
    }
}