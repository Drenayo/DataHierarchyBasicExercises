using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHierarchyBasicExercises.Src.class01
{
    /// <summary>
    /// 对数器 测试算法使用
    /// 对数器可以自动化检测算法的正确性，性能
    /// 人为测试无法覆盖所有边界，无法大规模测试
    /// </summary>
    class AlgorithmTester
    {
        // 随机生成测试数组
        public static int[] GenerateRandomArray(int maxSize, int maxValue)
        {
            Random random = new Random();
            int[] arr = new int[random.Next(maxSize)];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = random.Next(maxValue);
            }
            return arr;
        }

        // 对比两个数组是否一致
        public static bool IsEqual(int[] arr1, int[] arr2)
        {
            // 有一个为空
            if ((arr1 == null && arr2 != null) || arr1 != null && arr2 == null)
                return false;

            // 俩都空，相等
            if (arr1 == null && arr2 == null)
                return true;

            // 长度都不一样，没必要比了
            if (arr1.Length != arr2.Length)
                return false;

            // 最终遍历对比
            for (int i = 0; i < arr1.Length; i++)
            {
                if (arr1[i] != arr2[i])
                    return false;
            }

            return true;
        }


        // 测试算法是否可靠
        public static bool Testor(int testNumber)
        {

            int maxSize = 10;
            int maxValue = 100;
            bool succeed = true;
            for (int i = 0; i < testNumber; i++)
            {
                // 生成测试数据
                int[] arr1 = GenerateRandomArray(maxSize, maxValue);
                int[] arr2 = new int[arr1.Length];
                arr1.CopyTo(arr2, 0);

                // 这里调用自己的算法
                Sort.InsertSort1(arr1);
                // 系统的算法，用于对比
                Array.Sort(arr2);

                if (!IsEqual(arr1, arr2))
                {
                    succeed = false;

                    // 打印出来错误的排序结果
                    Console.WriteLine("自己的算法：");
                    PrintArray(arr1);
                    Console.WriteLine("系统的算法：");
                    PrintArray(arr2);

                    break;
                }
            }


            Console.WriteLine(succeed ? $"测试成功！" : $"测试失败！");
            return succeed;
        }

        // 打印数组
        public static void PrintArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                //Console.WriteLine(arr[i] + "");
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
