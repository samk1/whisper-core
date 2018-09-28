using System.Collections.Generic;

namespace WhisperCore.Format.Interfaces
{
    public interface IWhisperData
    {
        IEnumerable<IWhisperArchive> Archives { get; }
    }
}