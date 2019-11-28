using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms;

namespace UnitTestProject.LeetCode
{
    [TestClass]
    public class UnitTest17
    {
        [TestMethod]
        public void TestMethod1()
        {
            var act = question0017.LetterCombinations("");

            var except = 2;

            Assert.AreEqual(except, act);
        }
    }
}
