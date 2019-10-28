using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    /// <summary>
    /// 10. 正则表达式匹配
    /// </summary>
    public class question0010
    {
        /* 给你一个字符串 s 和一个字符规律 p，请你来实现一个支持 '.' 和 '*' 的正则表达式匹配。
            '.' 匹配任意单个字符
            '*' 匹配零个或多个前面的那一个元素
            所谓匹配，是要涵盖 整个 字符串 s的，而不是部分字符串。

            说明:
            s 可能为空，且只包含从 a-z 的小写字母。
            p 可能为空，且只包含从 a-z 的小写字母，以及字符 . 和 *。
         */


        public bool IsMatch(string s, string p)
        {

            var sArray = s.ToCharArray();
            //解析p
            var rep = p.ToCharArray();

            for (int i = 0; i < sArray.Length; i++)
            { 
                
            }

            return false;
        }

      
    }
}
