using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms;

namespace UnitTestProject.LeetCode
{
    [TestClass]
    public class UnitTest18
    {
        [TestMethod]
        public void TestMethod1()
        {
            int[] s = new int[] {1, 0, -1, 0, -2, 2 };
            int target = 0;
            var act = question0018.FourSum(s, target);

            var except = 2;

            Assert.AreEqual(except, act);
        }

        [TestMethod]
        public void TestMethod2()
        {
            int[] s = new int[] { 0, 0, 0, 0 };
            int target = 1;
            var act = question0018.FourSum(s, target);

            var except = 2;

            Assert.AreEqual(except, act);
        }

        [TestMethod]
        public void TestMethod3()
        {
            int[] s = new int[] { -3,-2,-1,0,0,1,2,3 };
            int target = 0;
            var act = question0018.FourSum(s, target);

            var except = 8;

            Assert.AreEqual(except, act);
        }

         [TestMethod]
        public void TestMethod4()
        {
            int[] s = new int[] { -1,0,1,2,-1,-1,-4 };
            int target = -1;
            var act = question0018.FourSum(s, target);

            var except = 2;

            Assert.AreEqual(except, act);
        }

        [TestMethod]
        public void TestMethod5()
        {
            int[] s = new int[] { 1,-2,-5,-4,-3,3,3,5 };
            int target = -11;
            var act = question0018.FourSum(s, target);

            var except = 2;

            Assert.AreEqual(except, act);
        }


    }
}
