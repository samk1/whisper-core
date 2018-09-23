namespace WhisperCore.Tests
{
    using System.IO;
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using WhisperCore.Interfaces;

    [TestClass]
    [DeploymentItem("testfiles/1minute_1day.whisper")]
    public class WhisperDataTest
    {
        private IWhisperData whisperData;

        [TestInitialize]
        public void InitialiseWhisperData()
        {
            var whisperFile = File.OpenRead("testfiles/1minute_1day.whisper");
            this.whisperData = new WhisperData(whisperFile, new WhisperHeader(whisperFile));
        }

        [TestMethod]
        public void Constructor()
        {
            Assert.IsNotNull(this.whisperData);
        }

        [TestMethod]
        public void Property_Archives()
        {
            Assert.IsNotNull(this.whisperData.Archives);
        }

        [TestMethod]
        public void Property_Archives_CountIsOne()
        {
            Assert.AreEqual(1, this.whisperData.Archives.Count());
        }
    }
}
