using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHierarchyBasicExercises.Algorithm
{
    /// <summary>
    /// 查找算法
    /// </summary>
    class Search
    {
        // 二分查找
        public static int BinarySearch(List<int> list, int target)
        {
            int left = 0;
            int right = list.Count - 1;

            while (left <= right)
            {
                int mid = (left + right) / 2;

                if (list[mid] == target)
                {
                    return mid;
                }
                else if (list[mid] > target)
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }

            return -1;
        }



        // 遍历查找
        public static int ErgodicSearch(List<int> list, int target)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Equals(target))
                {
                    return i;
                }
            }
            return -1;
        }


        // 系统自带
        public static int SystemSearch(List<int> list, int target)
        {
            return list.IndexOf(target);
        }
    }
}
