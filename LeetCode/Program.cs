using Algorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "abcacbb";
            question3 q3 = new question3();
            int r = q3.LengthOfLongestSubstring(s);

            Console.WriteLine(string.Format("{0}测试结果：{1}", s, r));
            Console.ReadKey();
        }
    }
}
