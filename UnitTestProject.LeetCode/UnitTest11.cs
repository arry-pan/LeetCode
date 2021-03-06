﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms;

namespace UnitTestProject.LeetCode
{
    [TestClass]
    public class UnitTest11
    {
        [TestMethod]
        public void TestMethod1()
        {
            int[] a = new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 };
            int act = question0011.MaxArea3(a);

            int except = 49;
            Assert.AreEqual(except, act);
        }

        [TestMethod]
        public void TestMethod2()
        {
            int[] a = new int[] { 1, 8 };
            int act = question0011.MaxArea3(a);

            int except = 1;
            Assert.AreEqual(except, act);
        }

        [TestMethod]
        public void TestMethod3()
        {
            int[] a = new int[] { 1, 7, 6, 2, 5, 4, 8, 8, 6 };
            int act = question0011.MaxArea3(a);

            int except = 42;
            Assert.AreEqual(except, act);
        }
    }
}
