namespace WhisperCore.Format.Interfaces
{
    public interface IWhisperFile
    {
        IWhisperData Data { get; }

        IWhisperHeader Header { get; }
        
        string Path { get; }
    }
}