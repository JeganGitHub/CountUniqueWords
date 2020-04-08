using CountUniqueWords;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace UnitTest
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void PrintWordCountsInFile_FileNotFound()
        {
            //Arrange
            var program = new Program();

            //Act
            var output = program.PrintWordCountsInFile("somenotfoundfile.txt");

            //Assert
            Assert.AreNotEqual("File Not Found!", output);
        }

        [TestMethod]
        public void PrintWordCountsInFile_FileFoundWithWordCounts()
        {
            //Arrange
            var program = new Program();

            //Act
            var output = program.PrintWordCountsInFile("PositiveAttitude.txt");

            //Assert
            Assert.AreNotEqual("File Not Found!", output);
            Assert.AreNotEqual("General Exception", output);
        }

        [TestMethod]
        public void PrintWordCountsInFile_EmptyFile()
        {
            //Arrange
            var program = new Program();

            //Act
            var output = program.PrintWordCountsInFile("EmptyFile.txt");

            //Assert
            Assert.AreNotEqual("File Not Found!", output);
            Assert.AreNotEqual("General Exception", output);
            Assert.AreNotEqual("0", output);
        }

    }
}
