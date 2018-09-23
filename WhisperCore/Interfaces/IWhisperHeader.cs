namespace WhisperCore.Interfaces
{
    using System.Collections.Generic;

    public interface IWhisperHeader
    {
        IEnumerable<IWhisperArchiveInfo> ArchiveInfo { get; }

        IWhisperMetadata Metadata { get; }
    }
}