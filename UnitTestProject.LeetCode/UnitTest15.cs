using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms;

namespace UnitTestProject.LeetCode
{
    [TestClass]
    public class UnitTest15
    {
        [TestMethod]
        public void TestMethod1()
        {
            int[] s = new int[] {-1,0,1,2,-1};
            var act = question0015.ThreeSum(s);

            var except = new int[][] { new int[]{-1,0,1 }};

            Assert.AreEqual(except, act);
        }

        [TestMethod]
        public void TestMethod2()
        {
            int[] s = new int[] {3,0,-2,-1,1,2,2 };
            var act = question0015.ThreeSum(s);

            var except = new int[][] { new int[] { -1, 0, 1 } };

            Assert.AreEqual(except, act);
        }
    }
}
