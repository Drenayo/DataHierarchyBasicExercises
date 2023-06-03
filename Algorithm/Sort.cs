using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHierarchyBasicExercises.Algorithm
{
    /// <summary>
    /// 排序算法相关练习 
    /// 排序算法的目的是提高数据的查找和访问效率，以及方便数据的处理和分析
    /// 排序算法都是通过比较和交互元素来实现排序的 
    /// </summary>
    class Sort
    {

        //从首位开始判断首位和首位-1的大小，谁大谁往后（交互），之后遍历这个操作
        //第一次遍历完成后，末尾为最大数一定被确定了，所以遍历范围-1
        //再往后的每次遍历，都会确定最后一个数，遍历范围-1
        //直到范围缩减到首位

        // 冒泡排序
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

        // 冒泡排序List
        public static List<int> BubbleSort(List<int> arr)
        {
            int len = arr.Count;

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

        public static List<int> SelectSort(List<int> arr)
        {
            int len = arr.Count;

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
        public static List<int> InsertSort2(List<int> arr)
        {
            int len = arr.Count;

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
        // 交互位置
        public static void Swap(List<int> arr, int start, int end)
        {
            int temp = arr[start];
            arr[start] = arr[end];
            arr[end] = temp;
        }
    }
}
