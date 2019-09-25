using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms;

namespace UnitTestProject.LeetCode
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string param = "aabcabcbb";

            var act = new question3().LengthOfLongestSubstring(param);
            var except = 3;

            Assert.IsTrue(act == except);
        }
    }
}
