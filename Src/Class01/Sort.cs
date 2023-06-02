using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHierarchyBasicExercises.Src.class01
{
    /// <summary>
    /// 排序算法相关练习
    /// </summary>
    class Sort
    {
        // 冒泡排序 第一种写法
        public static int[] BubbleSort(int[] arr)
        {
            int len = arr.Length;

            for (int i = len - 1; i >= 0; i--)
            {
                for (int s = 1; s <= i; s++)
                {
                    if (arr[s - 1] > arr[s])
                    {
                        Swap(arr, s - 1, s);
                    }
                }
            }
            return arr;
        }


        // 选择排序
        public static int[] SelectSort(int[] arr)
        {
            int len = arr.Length;

            for (int i = 0; i < len; i++)
            {
                int minValueIndex = i;
                for (int j = i + 1; j < len; j++)
                {
                    minValueIndex = arr[j] < arr[minValueIndex] ? j : minValueIndex;
                }
                Swap(arr, i, minValueIndex);
            }
            return arr;
        }


        // 插入排序 第一种写法
        public static int[] InsertSort1(int[] arr)
        {
            int len = arr.Length;

            for (int end = 1; end < len; end++)
            {
                for (int pre = end - 1; pre >= 0 && arr[pre] > arr[pre + 1]; pre--)
                {
                    Swap(arr, pre, pre + 1);
                }
            }

            return arr;
        }

        // 插入排序 第二种写法
        public static int[] InsertSort2(int[] arr)
        {
            int len = arr.Length;

            for (int end = 1; end < len; end++)
            {
                int newNumIndex = end;
                while (newNumIndex - 1 >= 0 && arr[newNumIndex - 1] > arr[newNumIndex])
                {
                    Swap(arr, newNumIndex - 1, newNumIndex);
                    newNumIndex--;
                }
            }

            return arr;
        }


        // 交互位置
        public static void Swap(int[] arr, int start, int end)
        {
            int temp = arr[start];
            arr[start] = arr[end];
            arr[end] = temp;
        }
    }


    class SortHelp
    {
        // 生成一个随机数组，用于测试
        public static int[] GetRandom(int length)
        {
            Random random = new Random();
            int[] arr = new int[length];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = random.Next(1, 100);
            }

            return arr;
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
