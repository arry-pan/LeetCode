using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    /* 7. 整数反转
     给出一个 32 位的有符号整数，你需要将这个整数中每位上的数字进行反转。

    示例 1:

    输入: 123
    输出: 321
     示例 2:

    输入: -123
    输出: -321
    示例 3:

    输入: 120
    输出: 21

     */
    /// <summary>
    /// 
    /// </summary>
    public class question07
    {
        public int Reverse(int x)
        {
            int result = 0;
            if (x <= Int32.MinValue)
            {
                return result;
            }
            bool positive = x >= 0;
            x = Math.Abs(x);
            StringBuilder s = new StringBuilder();
            while (x != 0)
            {
                s.Append(x % 10);
                x = x / 10;
            }
            int.TryParse(s.ToString(), out result);

            return positive ? result : 0 - result;
        }
    }
}
