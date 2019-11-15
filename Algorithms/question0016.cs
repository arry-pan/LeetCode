using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    /// <summary>
    /// 16. 最接近的三数之和
    /// </summary>
    public class question0016
    {
        /*
         * 给定一个包括 n 个整数的数组 nums 和 一个目标值 target。找出 nums 中的三个整数，使得它们的和与 target 最接近。返回这三个数的和。假定每组输入只存在唯一答案。

         * 例如，给定数组 nums = [-1，2，1，-4], 和 target = 1.

         * 与 target 最接近的三个数的和为 2. (-1 + 2 + 1 = 2). 
         */

        public static int ThreeSumClosest(int[] nums, int target)
        {
            if (nums == null || nums.Length < 3) return 0;
            Array.Sort(nums);

            int result = nums[0] + nums[1] + nums[2];
            int diff = Math.Abs(result - target);
            int l, r;
            for (int i = 0; i < nums.Length; i++)
            {
                //if (nums[i] - target > diff) break;
                //if (i > 0 && nums[i] == nums[i - 1]) continue;

                l = i + 1; r = nums.Length - 1;
                while (l < r)
                {
                    int temp = nums[i] + nums[l] + nums[r];
                    //与目标值相等
                    if (temp == target) return temp;

                    if (diff > Math.Abs(temp - target))
                    {
                        result = temp;
                        diff = Math.Abs(temp - target);                       
                    }

                    if (temp - target <= 0)
                    {
                        l++;
                        //解决左侧数字重复
                        while (l != r && nums[l] == nums[l - 1]) l++;
                    }
                    else if (temp - target > 0)
                    {
                        r--;
                        //解决右侧数字重复
                        while (l != r && nums[r] == nums[r + 1]) r--;
                    }
                }

                // 解决nums[i]重复
                while (i < nums.Length - 2 && nums[i] == nums[i + 1])
                    i++;

            }
            
            return result;
        }
    }
}
