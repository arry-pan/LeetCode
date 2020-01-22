using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms;

namespace UnitTestProject.LeetCode
{
    [TestClass]
    public class UnitTest22
    {
        [TestMethod]
        public void TestMethod1()
        {           
            int n = 2;
            var act = question0022.GenerateParenthesis(n);

            var except = 4;

            Assert.AreEqual(except, act);
        }
    }
}
