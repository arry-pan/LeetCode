using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    /// <summary>
    /// 22. 括号生成
    /// </summary>
    public class question0022
    {
        /*
         * 给出 n 代表生成括号的对数，请你写出一个函数，使其能够生成所有可能的并且有效的括号组合。
         * 
         * [
         *  "((()))",
         *  "(()())",
         *  "(())()",
         *  "()(())",
         *  "()()()"
         * ]
         */

        public static IList<string> GenerateParenthesis(int n)
        {
            IList<string> ans = new List<string>();
            backtrack(ans, "", 0, 0, n);
            return ans;
        }

        private static void backtrack(IList<string> ans, string cur, int open, int close, int max)
        {
            if (cur.Length == max * 2)
            {
                ans.Add(cur);
                return;
            }

            if(open < max) 
                backtrack(ans, cur + "(", open +1, close, max);
            if (close < open)
                backtrack(ans, cur + ")", open, close + 1, max);
        }

    }
}
