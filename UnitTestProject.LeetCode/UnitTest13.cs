using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms;

namespace UnitTestProject.LeetCode
{
    [TestClass]
    public class UnitTest13
    {
        [TestMethod]
        public void TestMethod1()
        {
            string s = "III";
            int act = question0013.RomanToInt(s);

            int except = 3;
            Assert.AreEqual(except, act);
        }

        [TestMethod]
        public void TestMethod2()
        {
            string s = "CMLIV";
            int act = question0013.RomanToInt(s);

            int except = 954;
            Assert.AreEqual(except, act);
        }

        [TestMethod]
        public void TestMethod3()
        {
            string s = "LVIII";
            int act = question0013.RomanToInt(s);

            int except = 58;
            Assert.AreEqual(except, act);
        }

        [TestMethod]
        public void TestMethod4()
        {
            string s = "MCMXCIV";
            int act = question0013.RomanToInt(s);

            int except = 1994;
            Assert.AreEqual(except, act);
        }
    }
}
