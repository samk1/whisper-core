namespace WhisperCore.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class WhisperArchiveInfoTest
    {
        private WhisperCore.Format.Interfaces.IWhisperArchiveInfo archiveInfo;

        [TestInitialize]
        public void InitialiseArchiveInfo()
        {
            byte[] archiveInfoBuffer = { 0, 0, 0, 28, 0, 0, 0, 60, 0, 0, 5, 160 };
            this.archiveInfo = new WhisperCore.Format.WhisperArchiveInfo(archiveInfoBuffer);
        }

        [TestMethod]
        public void Constructor()
        {
            Assert.IsNotNull(this.archiveInfo);
        }

        [TestMethod]
        public void Property_Offset()
        {
            Assert.AreEqual((uint)28, this.archiveInfo.Offset);
        }

        [TestMethod]
        public void Property_SecondsPerPoint()
        {
            Assert.AreEqual((uint)60, this.archiveInfo.SecondsPerPoint);
        }

        [TestMethod]
        public void Property_Points()
        {
            Assert.AreEqual((uint)1440, this.archiveInfo.Points);
        }
    }
}
