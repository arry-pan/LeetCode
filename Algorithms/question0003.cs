using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    /*
     示例 1:

    输入: "abcabcbb"
    输出: 3 
    解释: 因为无重复字符的最长子串是 "abc"，所以其长度为 3。
    示例 2:

    输入: "bbbbb"
    输出: 1
    解释: 因为无重复字符的最长子串是 "b"，所以其长度为 1。
    示例 3:

    输入: "pwwkew"
    输出: 3
    解释: 因为无重复字符的最长子串是 "wke"，所以其长度为 3。
         请注意，你的答案必须是 子串 的长度，"pwke" 是一个子序列，不是子串。
     */

    /// <summary>
    /// 3.无重复字符的最长子串
    /// </summary>
    /// 给定一个字符串，请你找出其中不含有重复字符的 最长子串 的长度。
    /// 遍历字符串，每次以 i 值记录，不回溯 i 值，用flag记录遍历过程找到的重复的字符的位置。
    /// 如果遇到重复字符，i-flag 即为子串长度，此时flag重新定位到子串中重复字符的位置，i 继续往后遍历。
    /// 这里length跟result记录长度。
    public class question0003
    {
        public int LengthOfLongestSubstring(string s)
        {
            int i = 0;
            int flag = 0;
            int length = 0;
            int result = 0;
            char[] sc = s.ToCharArray();
            while (i < s.Length) 
            {
                int pos = s.IndexOf(sc[i], flag);
                if (pos < i)
                {
                    if (length > result)
                    {
                        result = length;
                    }
                    if (result >= s.Length - pos - 1)
                    {
                        return result;
                    }
                    length = i - pos - 1;
                    flag = pos + 1;
                }
                length++;
                i++;
            }
            
            return length;
        }
    }
}
