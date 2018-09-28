using System.IO;

namespace WhisperCore.Format
{
    public class WhisperFile : WhisperCore.Format.Interfaces.IWhisperFile
    {
        private readonly FileStream whisperFile;

        private WhisperCore.Format.Interfaces.IWhisperData data;

        private WhisperCore.Format.Interfaces.IWhisperHeader header;

        public WhisperFile(string whisperFilePath)
        {
            if (!File.Exists(whisperFilePath))
            {
                throw new FileNotFoundException($"Whisper file not found: {whisperFilePath}");
            }

            this.whisperFile = File.OpenRead(whisperFilePath);
            this.Path = whisperFilePath;
        }

        public WhisperCore.Format.Interfaces.IWhisperData Data => this.data ?? (this.data = new WhisperData(this.whisperFile, this.Header));

        public WhisperCore.Format.Interfaces.IWhisperHeader Header => this.header ?? (this.header = new WhisperHeader(this.whisperFile));
        
        public string Path { get; }
    }
}