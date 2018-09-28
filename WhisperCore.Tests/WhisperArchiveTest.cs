namespace WhisperCore.Tests
{
    using System.IO;
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class WhisperArchiveTest
    {
        private WhisperCore.Format.Interfaces.IWhisperArchive whisperArchive;

        [TestInitialize]
        public void InitialiseWhisperArchive()
        {
            var whisperFile = File.OpenRead("testfiles/1minute_1day.whisper");
            var whisperData = new WhisperCore.Format.WhisperData(whisperFile, new WhisperCore.Format.WhisperHeader(whisperFile));
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
        public void Property_Points_EnumeratorCountIs1440()
        {
            Assert.AreEqual(1440, this.whisperArchive.Points.Count());
        }
        
        [TestMethod]
        public void Property_Points_PropertyCountIs1440()
        {
            Assert.AreEqual(1440, this.whisperArchive.Points.Count);
        }

        [TestMethod]
        public void Property_Points_CanBeIndexed()
        {
            Assert.IsNotNull(this.whisperArchive.Points[0]);
        }

        [TestMethod]
        public void Property_Points_CanAccessGenericEnumerator()
        {
            Assert.IsNotNull(this.whisperArchive.Points.GetEnumerator());
        }

        [TestMethod]
        public void Property_Points_CanAccessNonGenericEnumerator()
        {
            Assert.IsNotNull(((System.Collections.IEnumerable)this.whisperArchive.Points).GetEnumerator());
        }

        [TestMethod]
        public void Property_Points_GenericEnumerator_CanReset()
        {
            using (var enumerator = this.whisperArchive.Points.GetEnumerator())
            {
                enumerator.Reset();
            };
        }

        [TestMethod]
        public void Property_Points_GenericEnumerator_CanDispose()
        {
            var enumerator = this.whisperArchive.Points.GetEnumerator();
            enumerator.Dispose();
        }

        [TestMethod]
        public void Property_Points_GenericEnumerator_CanAccessCurrent()
        {
            using (var enumerator = this.whisperArchive.Points.GetEnumerator())
            {
                Assert.IsNotNull(enumerator.Current);
            }
        }

        [TestMethod]
        public void Property_Points_NonGenericEnumerator_CanAccessCurrent()
        {
            var enumerator = ((System.Collections.IEnumerable) this.whisperArchive.Points).GetEnumerator();
            Assert.IsNotNull(enumerator.Current);
        }
    }
}
