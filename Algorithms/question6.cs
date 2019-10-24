using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    /// <summary>
    /// 6. Z 字形变换
    /// </summary>
    public class question6
    {

        /*
         *将一个给定字符串根据给定的行数，以从上往下、从左到右进行 Z 字形排列。
        *
        *比如输入字符串为 "LEETCODEISHIRING" 行数为 3 时，排列如下：
        *
        *L    C    I    R
        *E T O E S I  I  G
        *E    D   H   N
        *之后，你的输出需要从左往右逐行读取，产生出一个新的字符串，比如："LCIRETOESIIGEDHN"。
        *
        *请你实现这个将字符串进行指定行数变换的函数：
        *
        *示例 1: 
        *输入: s = "LEETCODEISHIRING", numRows = 3
        *输出: "LCIRETOESIIGEDHN"
         *
        *示例 2:
        *输入: s = "LEETCODEISHIRING", numRows = 4
        *输出: "LDREOEIIECIHNTSG"
        *解释:
        *L      D      R
        *E  O E    I  I
        *E C   I H   N
        *T      S      G
         */
        /// <summary>
        /// 解法1，按行排序
        /// </summary>
        /// <param name="s"></param>
        /// <param name="numRows"></param>
        /// <returns></returns>
        public static string Convert(string s, int numRows)
        {
            if (s == null || s.Length <= numRows || numRows == 1) return s;

            string[] rows = new string[Math.Min(s.Length, numRows)];
           
            int curRow = 0;
            bool goingDown = false;//控制转向curRow == 0 || curRow == numRows - 1时，调转向

            foreach (char c in s.ToCharArray())
            {
                rows[curRow] += c;
                if (curRow == 0 || curRow == numRows - 1) goingDown = !goingDown;

                curRow += goingDown ? 1 : -1;
            }

            return string.Join("", rows);
        }

        /// <summary>
        /// 解法2，按行访问
        /// </summary>
        /// <param name="s"></param>
        /// <param name="numRows"></param>
        /// <returns></returns>
        public static string Convert2(string s, int numRows)
        {
            if (s == null || s.Length <= numRows || numRows == 1) return s;

            var sArray = s.ToCharArray();
            int cycleLength = 2 * numRows - 2;

            string result = string.Empty ;
            
            //按行取值
            for (int r = 0; r < numRows; r++)
            {
                for (int i = 0; i + r < sArray.Length; i += cycleLength)
                {
                    result += sArray[i + r];
                    if (r != 0 && r != numRows - 1 && i + cycleLength - r < sArray.Length)
                    { 
                        result += sArray[i + cycleLength - r];
                    }
                }
            }

            return result;
        }


        public static string Convert3(string s, int numRows)
        {
            if (s == null || s.Length <= numRows || numRows == 1) return s;

            var sArray = s.ToCharArray();
            int cycleLength = 2 * numRows - 2;

            string[] rows = new string[Math.Min(s.Length, numRows)];

            for (int i = 0; i < sArray.Length; i++)
            {
                int rowi = i % cycleLength;
                if (rowi > numRows - 1) rowi = cycleLength - rowi;
                rows[rowi] += sArray[i];
            }

            return string.Join("", rows);
        }

    }
}
