using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    /// <summary>
    /// 11. 盛最多水的容器
    /// </summary>
    public class question0011
    {
        /*
         * 给定 n 个非负整数 a1，a2，...，an，每个数代表坐标中的一个点 (i, ai) 。在坐标内画 n 条垂直线，垂直线 i 的两个端点分别为 (i, ai) 和 (i, 0)。找出其中的两条线，使得它们与 x 轴共同构成的容器可以容纳最多的水。
         * 
         * 说明：你不能倾斜容器，且 n 的值至少为 2。
         * 
         * 图中垂直线代表输入数组 [1,8,6,2,5,4,8,3,7]。在此情况下，容器能够容纳水（表示为蓝色部分）的最大值为 49。
         * 示例:输入: [1,8,6,2,5,4,8,3,7]
         * 输出: 49
         */
        
        public static int MaxArea(int[] height)
        {
            int maxArea = 0;
            for (int i = 0; i < height.Length; i++)
            {
                for (int j = i + 1; j < height.Length; j++)
                {
                    int h = Math.Min(height[i], height[j]);

                    if (maxArea < h * (j - i))
                        maxArea = h * (j - i);
                }
            }

            return maxArea;
        }

        public static int MaxArea2(int[] height)
        {
            int maxArea = 0;
            for (int i = 0; i < height.Length; i++)
            {
                for (int j = height.Length - 1; j > i; j--)
                {
                    if (height[i] * (j - i) < maxArea) break;

                    int h = Math.Min(height[i], height[j]);

                    if (maxArea < h * (j - i))
                        maxArea = h * (j - i);
                }
            }

            return maxArea;
        }


        public static int MaxArea3(int[] height)
        {
            int maxArea = 0, maxHeight = 0;
            int l = 0, r = height.Length - 1;

            while (l < r)
            {
                if (height[l] <= maxHeight)
                {
                    l++;
                    continue;
                }
                if (height[r] <= maxHeight)
                {
                    r--;
                    continue;
                }
                maxHeight = Math.Min(height[l], height[r]);
                int curArea = maxHeight * (r - l);
                if (curArea > maxArea)
                {
                    maxArea = curArea;                    
                    if (height[l] < height[r])
                        l++;
                    else
                        r--;
                }
            }

            return maxArea;
        }

    }
}
