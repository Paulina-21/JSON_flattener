using Microsoft.VisualStudio.TestTools.UnitTesting;
using JSON_flattener;
using System;
using System.IO;

namespace JSON_flattener.Tests
{
    [TestClass()]
    public class JSON_transformerTests
    {
        [TestMethod()]
        [ExpectedException(typeof(FileNotFoundException))]
        public void GetPropertiesFromJsonTest_FileNotFound()
        {
            string file_name = "text.json"; //filename misspelled on purpose
            JSON_transformer.GetPropertiesFromJson(file_name);
            Assert.Fail();
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetPropertiesFromJsonTest_FileEmpty()
        {
            //file used for testing is empty by default
            string file_name = "test.json";
            JSON_transformer.GetPropertiesFromJson(file_name);
            Assert.Fail();
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void GetPropertiesFromJsonTest_NotJsonFormat()
        {
            //file used for testing is empty by default
            string file_name = "test.json";
            JSON_transformer.GetPropertiesFromJson(file_name);
            Assert.Fail();
        }
    }
}