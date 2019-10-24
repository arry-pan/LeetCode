using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms;

namespace UnitTestProject.LeetCode
{
    [TestClass]
    public class UnitTest6
    {
        [TestMethod]
        public void TestMethod1()
        {
            string s = "LEETCODEISHIRING";
            int numRows = 3;

            string act = question6.Convert3(s, numRows);
            string except = "LCIRETOESIIGEDHN";
            Assert.AreEqual(except, act);
        }

        [TestMethod]
        public void TestMethod2()
        {
            string s = "LEETCODEISHIRING";
            int numRows = 4;

            string act = question6.Convert3(s, numRows);
            string except = "LDREOEIIECIHNTSG";
            Assert.AreEqual(except, act);
        }

        [TestMethod]
        public void TestMethod3()
        {
            string s = "LECDF";
            int numRows = 2;

            string act = question6.Convert3(s, numRows);
            string except = "LCFED";
            Assert.AreEqual(except, act);
        }
    }
}
