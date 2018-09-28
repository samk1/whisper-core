namespace WhisperCore.Tests
{
    using System.IO;
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    [DeploymentItem("testfiles/1minute_1day.whisper")]
    public class WhisperHeaderTest
    {
        private WhisperCore.Format.Interfaces.IWhisperHeader whisperHeader;

        [TestInitialize]
        public void InitialiseWhisperHeader()
        {
            var whisperFile = File.OpenRead("testfiles/1minute_1day.whisper");
            this.whisperHeader = new WhisperCore.Format.WhisperHeader(whisperFile);
        }

        [TestMethod]
        public void Constructor()
        {
            Assert.IsNotNull(this.whisperHeader);
        }

        [TestMethod]
        public void Property_Metadata()
        {
            Assert.IsNotNull(this.whisperHeader.Metadata);
        }

        [TestMethod]
        public void Property_ArchiveInfo()
        {
            Assert.IsNotNull(this.whisperHeader.ArchiveInfo);
        }

        [TestMethod]
        public void Property_ArchiveInfo_CountIsOne()
        {
            Assert.AreEqual(1, this.whisperHeader.ArchiveInfo.Count());
        }
    }
}
