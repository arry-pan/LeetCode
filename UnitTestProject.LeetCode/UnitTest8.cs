using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms;

namespace UnitTestProject.LeetCode
{
    [TestClass]
    public class UnitTest8
    {
        [TestMethod]
        public void TestMethod1()
        {
            string s = "  0000000000012345678";

            int act = question0008.MyAtoi2(s);
            int except = 12345678;
            Assert.AreEqual(except, act);
        }

        [TestMethod]
        public void TestMethod2()
        {
            string s = "  + 04500E2323ISHIRING";

            int act = question0008.MyAtoi2(s);
            int except = 0;
            Assert.AreEqual(except, act);
        }

        [TestMethod]
        public void TestMethod3()
        {
            string s = "   - 04 2  ";

            int act = question0008.MyAtoi2(s);
            int except = 0;
            Assert.AreEqual(except, act);
        }

        [TestMethod]
        public void TestMethod4()
        {
            string s = "+2147483648L7EETCODEISHIRING";

            int act = question0008.MyAtoi2(s);
            int except = 2147483647;
            Assert.AreEqual(except, act);
        }
    }
}
