namespace WhisperCore.Tests
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using WhisperCore.Interfaces;

    [TestClass]
    public class WhisperPointTest
    {
        private IWhisperPoint whisperPoint;

        [TestInitialize]
        public void InitiliseWhisperPoint()
        {
            byte[] pointBuffer = { 91, 167, 108, 144, 64, 89, 0, 0, 0, 0, 0, 0, 0 };
            this.whisperPoint = new WhisperPoint(pointBuffer);
        }

        [TestMethod]
        public void Constructor()
        {
            Assert.IsNotNull(this.whisperPoint);
        }

        [TestMethod]
        public void Property_Timestamp()
        {
            Assert.AreEqual(DateTime.Parse("23 September 2018 10:36:00"), this.whisperPoint.Timestamp);
        }

        [TestMethod]
        public void Property_Value()
        {
            Assert.AreEqual(100, this.whisperPoint.Value);
        }
    }
}
