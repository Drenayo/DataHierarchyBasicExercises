using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHierarchyBasicExercises.Algorithm
{
    /// <summary>
    /// 查找算法 在有序的数据集合中进行，目的是快速找到目标元素
    /// 遍历、二分、插值、哈希、斐波那契查找
    /// </summary>
    class Search<T>
    {
        // 二分查找
        public static int BinarySearch(List<T> list, T target)
        {
            int left = 0;
            int right = list.Count - 1;

            while (left <= right)
            {
                int mid = (left + right) / 2;

                if (list[mid].Equals(target))
                {
                    return mid;
                }
                else if (list[mid].Equals(target))
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
        public static int LinearSearch(List<T> list, T target)
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
        public static int ListSearch(List<T> list, T target)
        {
            return list.IndexOf(target);
        }
    }
}
