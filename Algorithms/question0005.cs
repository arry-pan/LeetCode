using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    /// <summary>
    /// 5. 最长回文子串
    /// </summary>
    public class question0005
    {
        /*
             给定一个字符串 s，找到 s 中最长的回文子串。你可以假设 s 的最大长度为 1000。

            示例 1：

            输入: "babad"
            输出: "bab"
            注意: "aba" 也是一个有效答案。
            示例 2：

            输入: "cbbd"
            输出: "bb"
         */

        #region 1.暴力法

        /// <summary>
        /// 最长回文子串
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string LongestPalindrome(string s)
        {
            int maxPalindromicLength = 0;
            string maxPalindromic = string.Empty;
            var len = s.Length;

            for (int i = 0; i < len; i++)
            {
                for (int j = i + 1; j <= len; j++)
                {
                    var sub_s = s.Substring(i, j - i);
                    if (isPalindromic(sub_s))
                    {
                        if (sub_s.Length > maxPalindromicLength)
                        {
                            maxPalindromicLength = sub_s.Length;
                            maxPalindromic = sub_s;
                        }
                    }
                }
            }

            return maxPalindromic;
        }

        /// <summary>
        /// 判断是否是回文字符串
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool isPalindromic(string s)
        {
            int len = s.Length;
            for (int i = 0; i < len / 2; i++)
            {
                if (s.Substring(i, 1) != s.Substring(len - 1 - i, 1))
                {
                    return false;
                }
            }
            return true;
        }

        #endregion

        /// <summary>
        /// 2暴力法-优化
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string LongestPalindrome2(string s)
        {
            var len = s.Length;
            string maxPalindromic = "";
            bool[] p = new bool[len];
            for (int i = len - 1; i >= 0; i--)
            {
                for (int j = len - 1; j >= i; j--)
                {
                    p[j] = s.Substring(i, 1) == s.Substring(j, 1) && ( j - i < 3 || p[j - 1]);
                    if (p[j] && j - i + 1 > maxPalindromic.Length)
                    {
                        maxPalindromic = s.Substring(i, j - i + 1);
                    }
                }
            }

            return maxPalindromic;
        }

        #region 3扩展中心法

        /// <summary>
        /// 3扩展中心法
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string LongestPalindrome3(string s)
        {
            if (s == null || s.Length < 1) return "";
            int len = s.Length;
            int start = 0, end = 0;
            int palindromicLength = 0;

            #region 普通遍历
            //for (int i = 0; i < len; i++)
            //{
            //    int len1 = expandAroundCenter(s, i, i);
            //    int len2 = expandAroundCenter(s, i, i+1);
            //    int palindromicLength = Math.Max(len1, len2);
            //    if (palindromicLength > end + 1 - start)
            //    {
            //        start = i - (palindromicLength - 1) / 2;
            //        end = i + palindromicLength / 2 ;
            //    }
            //} 
            #endregion

            for (int left = (len - 1) / 2, right = (len - 1) / 2; left >= 0 || right < len; left--, right++)
            {
                if (left >= 0 && (left + 1) * 2 > palindromicLength)
                {
                    int len1 = expandAroundCenter(s, left, left);
                    int len2 = expandAroundCenter(s, left, left + 1);

                    palindromicLength = Math.Max(len1, len2);
                    if (palindromicLength > end + 1 - start)
                    {
                        start = left - (palindromicLength - 1) / 2;
                        end = left + palindromicLength / 2;
                    }
                }

                if (right < len && (len - right) * 2 + 1 > palindromicLength)
                {
                    int len3 = expandAroundCenter(s, right, right);
                    int len4 = expandAroundCenter(s, right, right + 1);

                    palindromicLength = Math.Max(len3, len4);
                    if (palindromicLength > end + 1 - start)
                    {
                        start = right - (palindromicLength - 1) / 2;
                        end = right + palindromicLength / 2;
                    }
                }
               
            }

            return s.Substring(start, end+1 - start);
        }

        public int expandAroundCenter(string s, int left, int right)
        {
            int l = left; int r = right;
            var sArray = s.ToCharArray();
            while (l >= 0 && r < sArray.Length && s[l] == s[r])
            {
                l--;
                r++;
            }
            return r - l - 1;
        }
        
        #endregion

        #region Manacher's Algorithm 马拉车算法。

        public string LongestPalindrome4(string s)
        {
            string T = PreProcessString(s);
            int len = T.Length;
            int[] P = new int[len];
            int C = 0;//当前回文子串的中心
            int R = 0;//当前回文子串的右边界

            for (int i = 1; i < len - 1; i++)
            {
                int i_mirror = 2 * C - i;
                if (R > i)
                {
                    P[i] = Math.Min(R - i, P[i_mirror]);
                }
                else
                {
                    P[i] = 0;
                }

                // 碰到之前讲的三种特殊情况时候，需要利用中心扩展法
                while (T.Substring(i + P[i] + 1, 1) == T.Substring(i - P[i] - 1, 1))
                {
                    P[i]++;
                }

                //判断是否需要更新R
                if (i + P[i] > R)
                {
                    C = i;
                    R = i + P[i];
                }
            }

            //找出最长回文子串的中心
            int maxLen = 0;
            int centerIndex = 0;
            for (int i = 1; i < len - 1; i++)
            {
                if (P[i] > maxLen)
                {
                    maxLen = P[i];
                    centerIndex = i;
                }
            }

            //返回最长回文子串
            return s.Substring((centerIndex - maxLen) / 2, maxLen);
        }

        /// <summary>
        /// 预处理字符串，字符间隔填充#，首尾加^和$;
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string PreProcessString(string s)
        {
            if (null == s || s.Length < 1)
                return "^$";
            var sArray = s.ToCharArray();

            return string.Format("^#{0}#$", string.Join("#", sArray));
        }

        #endregion

        #region MyRegion

        public string LongestPalindrome5(string s)
        {
            if (s == null || s.Length == 0)
            {
                return "";
            }
            // 保存起始位置，测试了用数组似乎能比全局变量稍快一点
            int[] range = new int[2];
            char[] str = s.ToCharArray();
            for (int i = 0; i < s.Length; i++)
            {
                // 把回文看成中间的部分全是同一字符，左右部分相对称
                //找到下一个与当前字符不同的字符
                i = findLongest(str, i, range);
            }
            return s.Substring(range[0], range[1] - range[0] + 1);
        }

        public static int findLongest(char[] str, int low, int[] range)
        {
            //查找中间部分
            int high = low;
            while (high < str.Length - 1 && str[high + 1] == str[low])
            {
                high++;
            }
            //定位中间部分的最后一个字符
            int ans = high;
            //从中间向左右扩散
            while (low > 0 && high < str.Length - 1 && str[low - 1] == str[high + 1])
            {
                low--;
                high++;
            }
            //记录最大长度
            if (high - low > range[1] - range[0])
            {
                range[0] = low;
                range[1] = high;
            }
            return ans;
        }

        #endregion
    }
}
