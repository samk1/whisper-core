namespace WhisperCore.Tests
{
    using System.IO;
    
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    [DeploymentItem("testfiles/1minute_1day.whisper")]
    public class WhisperFileTest
    {
        private WhisperCore.Format.Interfaces.IWhisperFile whisperFile;

        [TestInitialize]
        public void InitialiseWhisperFile()
        {
            this.whisperFile = new WhisperCore.Format.WhisperFile("testfiles/1minute_1day.whisper");
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

        [TestMethod]
        public void Property_Path_Exists()
        {
            Assert.IsTrue(File.Exists(this.whisperFile.Path));
        }

        [TestMethod]
        public void Constructor_NonExistentFile()
        {
            string path = System.Guid.NewGuid().ToString();

            if (File.Exists(path))
            {
                Assert.Inconclusive("The test file exists");
            }
            else
            {
                try
                {
                    var file = new WhisperCore.Format.WhisperFile(path);
                }
                catch (FileNotFoundException exception)
                {
                    return;
                }
            }
            
            Assert.Fail("The constructor did not detect the non-existent file");
        }
    }
}
