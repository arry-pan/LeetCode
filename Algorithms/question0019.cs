using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    /// <summary>
    /// 19. 删除链表的倒数第N个节点
    /// </summary>
    public class question0019
    {
        /*
         * 给定一个链表，删除链表的倒数第 n 个节点，并且返回链表的头结点。
         * 
         * 示例：给定一个链表: 1->2->3->4->5, 和 n = 2.
         * 
         * 当删除了倒数第二个节点后，链表变为 1->2->3->5.
         * 
         * 说明：给定的 n 保证是有效的。
         */


        public static ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            if (head == null) return head;

            int len = 1;//链表长度
            ListNode r = head;
            while (r.next != null)
            {
                len++;
                r = r.next;
            }

            int i = 0;
            r = new ListNode(0);
            var temp = r;
            while(head.next != null)
            {
                if (++i == len - n + 1)
                {
                    temp.next = head.next;
                    break;
                }

                temp.next = new ListNode(head.val);

                head = head.next;
                temp = temp.next;
            }

            return r.next;
        }

       
    }

    /* Definition for singly-linked list. */
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }

}
