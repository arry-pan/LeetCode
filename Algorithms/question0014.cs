using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    /// <summary>
    /// 14. 最长公共前缀
    /// </summary>
    public class question0014
    {
        /*
         * 编写一个函数来查找字符串数组中的最长公共前缀。
         * 如果不存在公共前缀，返回空字符串 ""。
         * 示例 1:输入: ["flower","flow","flight"]
         * 输出: "fl"
         * 
         * 示例 2:输入: ["dog","racecar","car"]
         * 输出: ""
         * 解释: 输入不存在公共前缀。
         * 
         * 说明: 所有输入只包含小写字母 a-z 
         */

        public static string LongestCommonPrefix(string[] strs)
        {
            if (strs == null || strs.Length < 1) return "";

            string l = strs[0];
            int j = 0;

            for (int i = 1; i < strs.Length; i++)
            {
                for (j = 0; j < Math.Min(l.Length, strs[i].Length); j++)
                {
                    if (l[j] != strs[i][j])
                    {
                        if (j == 0) return "";
                        break;                        
                    }
                }
                l = l.Substring(0, j);
            }

            return l;
        }
    }
}
