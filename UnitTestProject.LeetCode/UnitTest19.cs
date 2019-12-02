using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms;

namespace UnitTestProject.LeetCode
{
    [TestClass]
    public class UnitTest19
    {
        [TestMethod]
        public void TestMethod1()
        {
            ListNode listNode = new ListNode(1);
            //listNode.next = new ListNode(2);
            //listNode.next.next = new ListNode(3);
            //listNode.next.next.next = new ListNode(4);
            //listNode.next.next.next.next = new ListNode(5);

            int n = 0;
            var act = question0019.RemoveNthFromEnd(listNode, n);

            var except = 4;

            Assert.AreEqual(except, act);
        }
    }
}
