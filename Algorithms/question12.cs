using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    /// <summary>
    /// 12. 整数转罗马数字
    /// </summary>
    public class question12
    {
        public static string IntToRoman(int num)
        {
            string res = "";

            int temp = num;

            //转换个位
            switch (temp % 10)
            {
                case 1: res = "I" + res; break;
                case 2: res = "II" + res; break;
                case 3: res = "III" + res; break;
                case 4: res = "IV" + res; break;
                case 5: res = "V" + res; break;
                case 6: res = "VI" + res; break;
                case 7: res = "VII" + res; break;
                case 8: res = "VIII" + res; break;
                case 9: res = "IX" + res; break;
                default: break;
            }
            if (num < 10) return res;

            //转换十位
            temp = temp / 10;
            switch (temp % 10)
            {
                case 1: res = "X" + res; break;
                case 2: res = "XX" + res; break;
                case 3: res = "XXX" + res; break;
                case 4: res = "XL" + res; break;
                case 5: res = "L" + res; break;
                case 6: res = "LX" + res; break;
                case 7: res = "LXX" + res; break;
                case 8: res = "LXXX" + res; break;
                case 9: res = "XC" + res; break;
                default: break;
            }
            if (num < 100) return res;

            //转换百位
            temp = temp / 10;
            switch (temp % 10)
            {
                case 1: res = "C" + res; break;
                case 2: res = "CC" + res; break;
                case 3: res = "CCC" + res; break;
                case 4: res = "CD" + res; break;
                case 5: res = "D" + res; break;
                case 6: res = "DC" + res; break;
                case 7: res = "DCC" + res; break;
                case 8: res = "DCCC" + res; break;
                case 9: res = "CM" + res; break;
                default: break;
            }
            if (num < 1000) return res;

            //转换千位
            temp = temp / 10;
            switch (temp % 10)
            {
                case 1: res = "M" + res; break;
                case 2: res = "MM" + res; break;
                case 3: res = "MMM" + res; break;
                default: break;
            }

            return res;
        }


        public static string IntToRoman2(int num)
        {
            StringBuilder res = new StringBuilder();
            int temp = num;

            //转换千位
            if (temp >= 1000)
            {
                switch (temp / 1000)
                {
                    case 1: res.Append("M"); break;
                    case 2: res.Append("MM"); break;
                    case 3: res.Append("MMM"); break;
                    default: break;
                }
                temp = temp % 1000;
            }

            //转换百位
            if (temp >= 100)
            {
                switch (temp / 100)
                {
                    case 1: res.Append("C"); break;
                    case 2: res.Append("CC"); break;
                    case 3: res.Append("CCC"); break;
                    case 4: res.Append("CD"); break;
                    case 5: res.Append("D"); break;
                    case 6: res.Append("DC"); break;
                    case 7: res.Append("DCC"); break;
                    case 8: res.Append("DCCC"); break;
                    case 9: res.Append("CM"); break;
                    default: break;
                }
                temp = temp % 100;
            }

            //转换十位
            if (temp >= 10)
            {                
                switch (temp / 10)
                {
                    case 1: res.Append("X"); break;
                    case 2: res.Append("XX"); break;
                    case 3: res.Append("XXX"); break;
                    case 4: res.Append("XL"); break;
                    case 5: res.Append("L"); break;
                    case 6: res.Append("LX"); break;
                    case 7: res.Append("LXX"); break;
                    case 8: res.Append("LXXX"); break;
                    case 9: res.Append("XC"); break;
                    default: break;
                }
                temp = temp % 10;
            }


            //转换个位
            if (temp > 0)
            {
                switch (temp)
                {
                    case 1: res.Append("I"); break;
                    case 2: res.Append("II"); break;
                    case 3: res.Append("III"); break;
                    case 4: res.Append("IV"); break;
                    case 5: res.Append("V"); break;
                    case 6: res.Append("VI"); break;
                    case 7: res.Append("VII"); break;
                    case 8: res.Append("VIII"); break;
                    case 9: res.Append("IX"); break;
                    default: break;
                }
            }

            return res.ToString();
        }

    }
}
