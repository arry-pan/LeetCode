using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms;

namespace UnitTestProject.LeetCode
{
    [TestClass]
    public class UnitTest12
    {
        [TestMethod]
        public void TestMethod1()
        {
            int num = 4;

            string act = question12.IntToRoman2(num);
           
            string except = "IV";
            Assert.AreEqual(except, act);
        }

        [TestMethod]
        public void TestMethod2()
        {
            int num = 98;
            string act = question12.IntToRoman2(num);
            string except = "XCVIII";
            Assert.AreEqual(except, act);
        }

        [TestMethod]
        public void TestMethod3()
        {
            int num = 954;

            string act = question12.IntToRoman2(num);
            string except = "CMLIV";
            Assert.AreEqual(except, act);
        }

        [TestMethod]
        public void TestMethod4()
        {
            int num = 3994;

            string act = question12.IntToRoman2(num);
            string except = "MMMCMXCIV";
            Assert.AreEqual(except, act);
        }
    }
}
