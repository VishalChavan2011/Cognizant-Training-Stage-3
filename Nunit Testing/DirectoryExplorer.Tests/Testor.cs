using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using MagicFilesLib;

namespace DirectoryExplorer.Tests
{ 
    [TestFixture]

    public class Testor
    {
        private readonly string _file1 = "file.txt";
        private readonly string _file2 = "file2.txt";

        Mock<IDirectoryExplorer> mock;

        [OneTimeSetUp]
        public void Setup()
        {
            mock = new Mock<IDirectoryExplorer>();
        }

        [TestCase("/Home/890682")]

        public void TestorClass(string path)
        {
            List<string> files = new List<string>()
            {
                _file1,
                _file2
            };
            mock.Setup(p => p.GetFiles(path)).Returns(files);
            var result = mock.Object.GetFiles(path);
            Assert.AreEqual(2,result.Count);
            Assert.IsTrue(result.Contains(_file1));   

        }
    }
}
