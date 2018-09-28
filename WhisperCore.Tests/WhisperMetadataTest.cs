namespace WhisperCore.Tests
{
    using System.IO;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class WhisperMetadataTest
    {
        private WhisperCore.Format.Interfaces.IWhisperMetadata whisperMetadata;

        [TestInitialize]
        public void InitialiseWhisperMetadata()
        {
            byte[] metadataBuffer = { 0, 0, 0, 1, 0, 1, 81, 128, 63, 0, 0, 0, 0, 0, 0, 1 };
            this.whisperMetadata = new WhisperCore.Format.WhisperMetadata(metadataBuffer);
        }

        [TestMethod]
        public void Constructor()
        {
            Assert.IsNotNull(this.whisperMetadata);
        }

        [TestMethod]
        public void Property_AggregationType()
        {
            Assert.AreEqual(WhisperCore.Format.Interfaces.WhisperAggregationType.Average, this.whisperMetadata.AggregationType);
        }

        [TestMethod]
        public void Property_MaximumRetention()
        {
            Assert.AreEqual((uint)86400, this.whisperMetadata.MaximumRetention);
        }

        [TestMethod]
        public void Property_XFilesFactor()
        {
            Assert.AreEqual(0.5, this.whisperMetadata.XFilesFactor);
        }

        [TestMethod]
        public void Property_ArchiveCount()
        {
            Assert.AreEqual((uint)1, this.whisperMetadata.ArchiveCount);
        }
    }
}
