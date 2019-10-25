using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    /// <summary>
    /// 13. 罗马数字转整数
    /// </summary>
    public class question13
    {
        public static int RomanToInt(string s)
        {
            Dictionary<char, int> dic = new Dictionary<char, int>();
            dic.Add('I', 1);
            dic.Add('V', 5);
            dic.Add('X', 10);
            dic.Add('L', 50);
            dic.Add('C', 100);
            dic.Add('D', 500);
            dic.Add('M', 1000);

            int res = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (i + 1 < s.Length && dic[s[i]] < dic[s[i + 1]])
                {
                    res -= dic[s[i]];
                }
                else
                {
                    res += dic[s[i]];
                }
            }
            return res;
        }
    }
}
