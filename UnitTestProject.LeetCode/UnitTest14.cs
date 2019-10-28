using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms;

namespace UnitTestProject.LeetCode
{
    [TestClass]
    public class UnitTest14
    {
        [TestMethod]
        public void TestMethod1()
        {
            string[] s = new string[] {"flower","flow","flight"};
            string act = question0014.LongestCommonPrefix(s);

            string except = "fl";
            Assert.AreEqual(except, act);
        }

        [TestMethod]
        public void TestMethod2()
        {
            string[] s = new string[] { "dog", "racecar", "car" };
            string act = question0014.LongestCommonPrefix(s);

            string except = "";
            Assert.AreEqual(except, act);
        }

        [TestMethod]
        public void TestMethod3()
        {
            string[] s = new string[] { "aa", "a" };
            string act = question0014.LongestCommonPrefix(s);

            string except = "a";
            Assert.AreEqual(except, act);
        }
    }
}
