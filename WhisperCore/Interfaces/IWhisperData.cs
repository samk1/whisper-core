namespace WhisperCore.Interfaces
{
    using System.Collections.Generic;

    public interface IWhisperData
    {
        IEnumerable<IWhisperArchive> Archives { get; }
    }
}