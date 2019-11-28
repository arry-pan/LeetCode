using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    /// <summary>
    /// 17. 电话号码的字母组合
    /// </summary>
    public class question0017
    {
        /*
         * 给出数字到字母的映射如下（与电话按键相同）。注意 1 不对应任何字母。
         * 
         * 示例:
         * 输入："23"
         * 输出：["ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf"]
         * 
         * 说明:尽管上面的答案是按字典序排列的，但是你可以任意选择答案输出的顺序。
         */

        public static IList<string> LetterCombinations(string digits)
        {
            IList<string> result = new List<string>();

            if (digits == null || digits.Length <= 0) return result;

            Dictionary<char, string> dic = new Dictionary<char, string> { { '2', "abc" }, { '3', "def" }, { '4', "ghi" }, { '5', "jkl" }, { '6', "mno" }, { '7', "pqrs" }, { '8', "tuv" }, { '9', "wxyz" } };

            for (int i = 0; i < digits.Length; i++)
            {
                result = CombineLetters(result, dic[digits[i]]);
            }

            return result;
        }

        public static IList<string> CombineLetters(IList<string> letterList, string letters)
        {
            IList<string> result = new List<string>();
            foreach (var l in letters)
            {
                if (letterList.Count <= 0)
                    result.Add(l.ToString());
                else
                    foreach (var s in letterList)
                    {
                        result.Add(s + l);
                    }
            }

            return result;
        }

    }
}
