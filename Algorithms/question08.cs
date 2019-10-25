using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Algorithms
{
    /// <summary>
    /// 8. 字符串转换整数 (atoi)
    /// </summary>
    public class question08
    {
        public static int MyAtoi(string str)
        {
            if (str.Trim().Length <= 0) return 0;

            char[] IntArray = new char[] {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

            var sArray = str.Trim().ToCharArray();           

            StringBuilder sr = new StringBuilder();
            for (int i = 0; i < sArray.Length; i++)
            {
                if (i == 0)
                {
                    if (sArray[i] == '+' || sArray[i] == '-')continue;
                }

                if (!IntArray.Contains(sArray[i]))break;
                
                sr.Append(sArray[i]);             
            }
            string r = sr.ToString().TrimStart(new char[] { '0' });
            if (r.Length < 1) return 0;

            //标记负值
            bool isNegative = sArray[0] == '-';
            if (r.Length > 10) return isNegative ? Int32.MinValue : Int32.MaxValue;

            long l = 0;
            if (long.TryParse(r, out l))
            {
                if (isNegative) l = 0L - l;
                if (l < Int32.MinValue) return Int32.MinValue;
                else if (l > Int32.MaxValue) return Int32.MaxValue;
                else return (int)l;
            }
            return 0;
        }


        public static int MyAtoi2(string str)
        {
            if (str.Trim().Length <= 0) return 0;

            var sArray = str.Trim().ToCharArray();

            int negative = 1, i = 0;
            long res = 0;
            if (sArray[0] == '-')
            {
                negative = -1;
                i++;
            }
            else if (sArray[0] == '+')
            {
                i++;
            }

            for (; i < sArray.Length; i++)
            {
                if (sArray[i] < 48 || sArray[i] > 57) break;

                res = res * 10 + (sArray[i] - 48);

                if (res * negative < Int32.MinValue) return Int32.MinValue;
                else if (res * negative > Int32.MaxValue) return Int32.MaxValue;
            }
            return (int)res * negative; 
        }
    }
}
