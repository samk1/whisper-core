namespace WhisperCore.Interfaces
{
    public enum WhisperAggregationType
    {
        /// <summary>
        ///     The average.
        /// </summary>
        Average = 1,

        /// <summary>
        ///     The sum.
        /// </summary>
        Sum = 2,

        /// <summary>
        ///     The last.
        /// </summary>
        Last = 3,

        /// <summary>
        ///     The maximum.
        /// </summary>
        Maximum = 4,

        /// <summary>
        ///     The minimum.
        /// </summary>
        Minimum = 5,

        /// <summary>
        ///     The average zero.
        /// </summary>
        AverageZero = 6,

        /// <summary>
        ///     The absolute maximum.
        /// </summary>
        AbsoluteMaximum = 7,

        /// <summary>
        ///     The absolute minimum.
        /// </summary>
        AbsoluteMinimum = 8
    }

    public interface IWhisperMetadata
    {
        WhisperAggregationType AggregationType { get; }

        uint ArchiveCount { get; }

        uint MaximumRetention { get; }

        float XFilesFactor { get; }
    }
}