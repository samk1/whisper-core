namespace WhisperCore.Tests
{
    using System.Runtime.CompilerServices;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using WhisperCore.Interfaces;

    [TestClass]
    [DeploymentItem("testfiles/1minute_1day.whisper")]
    public class WhisperFileTest
    {
        private IWhisperFile whisperFile;

        [TestInitialize]
        public void InitialiseWhisperFile()
        {
            this.whisperFile = new WhisperFile("testfiles/1minute_1day.whisper");
        }

        [TestMethod]
        public void Constructor()
        {
            Assert.IsNotNull(this.whisperFile);
        }

        [TestMethod]
        public void Property_Header()
        {
            Assert.IsNotNull(this.whisperFile.Header);
        }

        [TestMethod]
        public void Property_Data()
        {
            Assert.IsNotNull(this.whisperFile.Data);
        }
    }
}
