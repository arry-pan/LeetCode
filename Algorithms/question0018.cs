using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    /// <summary>
    /// 18. 四数之和
    /// </summary>
    public class question0018
    {
        /*
         * 给定一个包含 n 个整数的数组 nums 和一个目标值 target，判断 nums 中是否存在四个元素 a，b，c 和 d ，使得 a + b + c + d 的值与 target 相等？找出所有满足条件且不重复的四元组。
         * 
         * 注意：答案中不可以包含重复的四元组。
         * 
         * 示例：给定数组 nums = [1, 0, -1, 0, -2, 2]，和 target = 0。
         * 
         * 满足要求的四元组集合为：
         *   [
         *     [-1,  0, 0, 1],
         *     [-2, -1, 1, 2],
         *     [-2,  0, 0, 2]
         *   ]
         */

        public static IList<IList<int>> FourSum(int[] nums, int target)
        {
            var list = new List<IList<int>>();
            if (nums == null || nums.Length < 4) return list;

            Array.Sort(nums);

            int l, r;
            for (int i = 0; i < nums.Length - 3; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1]) continue;

                /*获取当前最小值，如果最小值比目标值大，说明后面越来越大的值根本没戏，可退出全部循环*/
                int min1 = nums[i] + nums[i + 1] + nums[i + 2] + nums[i + 3];
                if (min1 > target)
                {
                    break;
                }
                /*获取当前最大值，如果最大值比目标值小，说明后面越来越小的值根本没戏，忽略当前i值*/
                int max1 = nums[i] + nums[nums.Length - 1] + nums[nums.Length - 2] + nums[nums.Length - 3];
                if (max1 < target)
                {
                    continue;
                }

                for (int j = i + 1; j < nums.Length - 2; j++)
                {
                    
                    if (j > i+1 && nums[j] == nums[j - 1]) continue;

                    l = j + 1; r = nums.Length - 1;

                    /*获取当前最小值，如果最小值比目标值大，说明后面越来越大的值根本没戏*/
                    int min2 = nums[i] + nums[j] + nums[l] + nums[l + 1];
                    if (min2 > target)
                    {
                        break;
                    }
                    /*获取当前最大值，如果最大值比目标值小，后面越来越小的值根本没戏，忽略*/
                    int max2 = nums[i] + nums[j] + nums[r-1] + nums[r];
                    if (max2 < target)
                    {
                        continue;
                    }
                    
                    while (l < r)
                    {
                        int sum = nums[i] + nums[j] + nums[l] + nums[r];
                        if (sum == target)
                        {
                            list.Add(new int[4] { nums[i], nums[j], nums[l], nums[r] });

                            //去重
                            while (l < r && nums[l] == nums[l + 1]) l++;
                            while (l < r && nums[r] == nums[r - 1]) r--;
                            l++;
                            r--;
                        }
                        else if (sum < target)
                        {
                            l++;
                        }
                        else if (sum > target)
                        {
                            r--;
                        }
                    }

                }

            }

            return list;
        }

    }
}
