namespace WhisperCore.Tests
{
    using System.IO;
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using WhisperCore.Interfaces;

    [TestClass]
    public class WhisperArchiveTest
    {
        private IWhisperArchive whisperArchive;

        [TestInitialize]
        public void InitialiseWhisperArchive()
        {
            var whisperFile = File.OpenRead("testfiles/1minute_1day.whisper");
            var whisperData = new WhisperData(whisperFile, new WhisperHeader(whisperFile));
            this.whisperArchive = whisperData.Archives.First();
        }

        [TestMethod]
        public void Constructor()
        {
            Assert.IsNotNull(this.whisperArchive);
        }

        [TestMethod]
        public void Property_Points()
        {
            Assert.IsNotNull(this.whisperArchive.Points);
        }

        [TestMethod]
        public void Property_Points_CountIs1440()
        {
            Assert.AreEqual(1440, this.whisperArchive.Points.Count());
        }
    }
}
