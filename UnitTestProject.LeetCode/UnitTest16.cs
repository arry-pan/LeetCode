using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms;

namespace UnitTestProject.LeetCode
{
    [TestClass]
    public class UnitTest16
    {
        [TestMethod]
        public void TestMethod1()
        {
            int[] s = new int[] { -1, 2, 1, -4 };
            var act = question0016.ThreeSumClosest(s, 1);

            var except = 2;

            Assert.AreEqual(except, act);
        }

        [TestMethod]
        public void TestMethod2()
        {
            int[] s = new int[] { 0, 0, 0 };
            var act = question0016.ThreeSumClosest(s, 1);

            var except = 0;

            Assert.AreEqual(except, act);
        }

        [TestMethod]
        public void TestMethod3()
        {
            int[] s = new int[] { 0,2,1,-3 };
            var act = question0016.ThreeSumClosest(s, 1);

            var except = 0;

            Assert.AreEqual(except, act);
        }

        [TestMethod]
        public void TestMethod4()
        {
            int[] s = new int[] { 1,2,4,8,16,32,64,128 };
            var act = question0016.ThreeSumClosest(s, 82);

            var except = 82;

            Assert.AreEqual(except, act);
        }

        [TestMethod]
        public void TestMethod5()
        {
            int[] s = new int[] { 1,-3,3,5,4,1 };
            var act = question0016.ThreeSumClosest(s, 1);

            var except = 1;

            Assert.AreEqual(except, act);
        }

        [TestMethod]
        public void TestMethod6()
        {
            int[] s = new int[] { 1, 2, 5, 10, 11 };
            var act = question0016.ThreeSumClosest(s, 12);

            var except = 13;

            Assert.AreEqual(except, act);
        }

        [TestMethod]
        public void TestMethod7()
        {
            int[] s = new int[] { -1, 0, 1, 1, 55 };
            var act = question0016.ThreeSumClosest(s, 3);

            var except = 2;

            Assert.AreEqual(except, act);
        }
    }
}
