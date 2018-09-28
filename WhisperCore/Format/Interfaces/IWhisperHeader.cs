using System.Collections.Generic;

namespace WhisperCore.Format.Interfaces
{
    public interface IWhisperHeader
    {
        IEnumerable<IWhisperArchiveInfo> ArchiveInfo { get; }

        IWhisperMetadata Metadata { get; }
    }
}