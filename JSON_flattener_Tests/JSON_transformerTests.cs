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
            string file_name = "empty_test.json";
            JSON_transformer.GetPropertiesFromJson(file_name);
            Assert.Fail();
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void GetPropertiesFromJsonTest_NotJsonFormat()
        {
            //file used for testing is empty by default
            string file_name = "notJson_test.json";
            JSON_transformer.GetPropertiesFromJson(file_name);
            Assert.Fail();
        }

        [TestMethod()]
        public void GetPropertiesFromJsonTest_Working()
        {
            string file_name = "test.json";
            var dic= JSON_transformer.GetPropertiesFromJson(file_name);
            Assert.AreEqual(dic.Count,4);
        }
    }
}