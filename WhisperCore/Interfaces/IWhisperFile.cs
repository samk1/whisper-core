namespace WhisperCore.Interfaces
{
    public interface IWhisperFile
    {
        IWhisperData Data { get; }

        IWhisperHeader Header { get; }
    }
}