namespace WhisperCore.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    [TestClass]
    public class WhisperWriterTest
    {
        private IWhisperWriter whisperWriter;

        [TestInitialize]
        [DeploymentItem("testfiles/1minute_1day_writer.whisper")]
        public void InitialiseWriter()
        {
            this.whisperWriter = new WhisperWriter("testfiles/1minute_1day_writer.whisper");
        }

        [TestMethod]
        public void Construct()
        {
            Assert.IsNotNull(this.whisperWriter);
        }
    }
}