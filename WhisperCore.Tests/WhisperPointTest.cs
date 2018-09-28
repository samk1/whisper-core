namespace WhisperCore.Tests
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using WhisperCore.Interfaces;

    [TestClass]
    public class WhisperPointTest
    {
        private IWhisperPoint whisperPointFromBuffer;
        private WhisperPoint whisperPointFromUpdate;

        [TestInitialize]
        public void InitialiseWhisperPoint()
        {
            byte[] pointBuffer = { 91, 167, 108, 144, 64, 89, 0, 0, 0, 0, 0, 0 };
            this.whisperPointFromBuffer = new WhisperPoint(pointBuffer);
            this.whisperPointFromUpdate = new WhisperPoint(DateTime.Parse("23 September 2018 10:36:00"), 100);
        }

        [TestMethod]
        public void Constructor_FromBuffer()
        {
            Assert.IsNotNull(this.whisperPointFromBuffer);
        }

        [TestMethod]
        public void Property_Timestamp_FromBuffer()
        {
            Assert.AreEqual(DateTime.Parse("23 September 2018 10:36:00"), this.whisperPointFromBuffer.Timestamp);
        }

        [TestMethod]
        public void Property_Value_FromBuffer()
        {
            Assert.AreEqual(100, this.whisperPointFromBuffer.Value);
        }

        [TestMethod]
        public void Property_Buffer_FromBuffer()
        {
            byte[] pointBuffer = { 91, 167, 108, 144, 64, 89, 0, 0, 0, 0, 0, 0 };
            CollectionAssert.AreEqual(pointBuffer, this.whisperPointFromBuffer.Buffer);
        }

        [TestMethod]
        public void Constructor_FromUpdate()
        {
            Assert.IsNotNull(this.whisperPointFromUpdate);
        }

        [TestMethod]
        public void Property_Timestamp_FromUpdate()
        {
            Assert.AreEqual(DateTime.Parse("23 September 2018 10:36:00"), this.whisperPointFromUpdate.Timestamp);
        }
        
        [TestMethod]
        public void Property_Value_FromUpdate()
        {
            Assert.AreEqual(100, this.whisperPointFromUpdate.Value);
        }

        [TestMethod]
        public void Property_Buffer_FromUpdate()
        {
            byte[] pointBuffer = { 91, 167, 108, 144, 64, 89, 0, 0, 0, 0, 0, 0 };
            CollectionAssert.AreEqual(pointBuffer, this.whisperPointFromUpdate.Buffer);
        }
    }
}
