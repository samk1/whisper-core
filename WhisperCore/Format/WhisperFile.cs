using System.IO;

namespace WhisperCore.Format
{
    using WhisperCore.Format.Interfaces;
    
    public class WhisperFile : IWhisperFile
    {
        private readonly Stream whisperFile;

        private IWhisperData data;

        private IWhisperHeader header;

        public WhisperFile(string whisperFilePath)
        {
            if (!File.Exists(whisperFilePath))
            {
                throw new FileNotFoundException($"Whisper file not found: {whisperFilePath}");
            }

            this.whisperFile = new MemoryStream(File.ReadAllBytes(whisperFilePath));

            this.Path = whisperFilePath;
        }

        public IWhisperData Data => this.data ?? (this.data = new WhisperData(this.whisperFile, this.Header));

        public IWhisperHeader Header => this.header ?? (this.header = new WhisperHeader(this.whisperFile));
        
        public string Path { get; }
    }
}