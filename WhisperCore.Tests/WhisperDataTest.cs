﻿namespace WhisperCore.Tests
{
    using System.IO;
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    [DeploymentItem("testfiles/1minute_1day.whisper")]
    public class WhisperDataTest
    {
        private WhisperCore.Format.Interfaces.IWhisperData whisperData;

        [TestInitialize]
        public void InitialiseWhisperData()
        {
            var whisperFile = File.OpenRead("testfiles/1minute_1day.whisper");
            this.whisperData = new WhisperCore.Format.WhisperData(whisperFile, new WhisperCore.Format.WhisperHeader(whisperFile));
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
        public void Property_Archives_EnumeratorCountIsOne()
        {
            Assert.AreEqual(1, this.whisperData.Archives.Count());
        }
        
        
    }
}
