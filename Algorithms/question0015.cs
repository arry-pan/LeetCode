using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    /// <summary>
    /// 15. 三数之和
    /// </summary>
    public class question0015
    {
        /*
         * 给定一个包含 n 个整数的数组 nums，判断 nums 中是否存在三个元素 a，b，c ，使得 a + b + c = 0 ？找出所有满足条件且不重复的三元组。
         * 
         * 注意：答案中不可以包含重复的三元组。
         * 
         * 例如, 给定数组 nums = [-1, 0, 1, 2, -1, -4]，
         * 满足要求的三元组集合为：
         * [
         *  [-1, 0, 1],
         *  [-1, -1, 2]
         * ]
         * 
         */
        public static IList<IList<int>> ThreeSum(int[] nums)
        {            
            var list = new List<IList<int>>();
            if (nums == null || nums.Length < 3) return list;

            Array.Sort(nums);

            int l, r;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > 0) break;
                if (i > 0 && nums[i] == nums[i - 1]) continue;

                l = i + 1; r = nums.Length - 1;
                while (l < r)
                {
                    int sum = nums[i] + nums[l] + nums[r];
                    if (sum == 0)
                    {
                        list.Add(new int[3] { nums[i], nums[l], nums[r] });
                        
                        //去重
                        while (l < r && nums[l] == nums[l + 1]) l++;
                        while (l < r && nums[r] == nums[r - 1]) r--;
                        l++;
                        r--;
                    }
                    else if (sum < 0)
                    {
                        l++;
                    }
                    else if (sum > 0)
                    {
                        r--;
                     }
                }
            }

            return list;
        }

        /// <summary>
        /// 判断是否包含重复的数组
        /// </summary>
        /// <param name="l"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool CompareArray(List<int[]> l, int[] a)
        {
            if (l.Count < 1) return false;

            for (int i = l.Count -1 ; i >= 0; i--)
            {
                if (l[i][0] < a[0]) return false;

                int sc = 0;
                for (int j = 0; j < 3; j++)
                {
                    if (l[i][j] == a[j])
                        sc++;
                    else
                        break;
                }
                if (sc == 3)
                    return true;
            }
            return false;
        }

    }
}
