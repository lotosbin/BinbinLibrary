using Binbin.System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BinbinSystemForNet40Test
{


    /// <summary>
    ///This is a test class for StringExtensionTest and is intended
    ///to contain all StringExtensionTest Unit Tests
    ///</summary>
    [TestClass()]
    public class StringExtensionTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for AddHttp
        ///</summary>
        [TestMethod()]
        public void AddHttpTest()
        {
            string s = string.Empty; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            AddHttpTest(expected, s);
            this.AddHttpTest("http://www.ymatou.com", "www.ymatou.com");
            this.AddHttpTest("http://www.ymatou.com", "http://www.ymatou.com");
            this.AddHttpTest("http://www.ymatou.com", "http://www.ymatou.com");
        }

        private void AddHttpTest(string expected, string s)
        {
            string actual;
            actual = StringExtension.AddHttp(s);
            Assert.AreEqual(expected, actual);
        }
    }
}
