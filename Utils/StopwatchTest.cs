using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataHierarchyBasicExercises.Algorithm;
using DataHierarchyBasicExercises.DataStructure;
using DataHierarchyBasicExercises.Utils;
using System.Diagnostics;

namespace DataHierarchyBasicExercises.Utils
{
    public enum SortType
    {
        冒泡,
        归并,
        选择,
        插入
    }
    public enum SearchType
    {
        遍历,
        二分,
        系统
    }



    /// <summary>
    /// 算法测速
    /// </summary>
    class StopwatchTest
    {
        // 查找算法测试
        public static void SerachSpeedTest(int size, int maxValue, int numTimes, SearchType searchType, int target)
        {
            Stopwatch t1 = new Stopwatch();
            List<int> list = GenerateTestData.GetRandomLengthList_Int(size, maxValue);

            t1.Start();
            for (int i = 0; i < numTimes; i++)
            {
                switch (searchType)
                {
                    case SearchType.遍历:
                        Search<int>.LinearSearch(list, target);
                        break;
                    case SearchType.二分:
                        Search<int>.BinarySearch(list, target);
                        break;
                    case SearchType.系统:
                        Search<int>.ListSearch(list, target);
                        break;
                    default:
                        break;
                }
            }
            t1.Stop();

            Console.WriteLine($"{searchType}的排序速度：{t1.ElapsedMilliseconds}ms");
        }

        // 排序算法测试
        public static void SortSpeedTest(int size, int maxValue, SortType sortType)
        {
            Stopwatch t1 = new Stopwatch();
            List<int> list = GenerateTestData.GetRandomLengthList_Int(size, maxValue);

            t1.Start();
            switch (sortType)
            {
                case SortType.冒泡:
                    Sort.BubbleSort(list);
                    break;
                case SortType.归并:
                    Sort.MergeSrot(list);
                    break;
                case SortType.选择:
                    Sort.SelectSort(list);
                    break;
                case SortType.插入:
                    Sort.InsertSort1(list);
                    break;
                default:
                    break;
            }
            t1.Stop();

            Console.WriteLine($"{sortType}的排序速度：{t1.ElapsedMilliseconds}ms");
        }
    }
}
