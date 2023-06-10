using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHierarchyBasicExercises.Algorithm
{
    class Sort
    {
        // 冒泡排序 交换类排序
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

        // 快速排序 交换类排序  分治思想 不稳定排序  验证不稳定排序
        public static void QuickSort(List<int> arr)
        {
            QuickSortFunc(arr, 0, arr.Count - 1);
        }

        private static void QuickSortFunc(List<int> arr, int low, int high)
        {
            if (low < high)
            {
                int pivotIndex = QuickSortPartition(arr, low, high);
                QuickSortFunc(arr, low, pivotIndex - 1);
                QuickSortFunc(arr, pivotIndex + 1, high);
            }
        }

        private static int QuickSortPartition(List<int> arr, int low, int high)
        {
            int pivotValue = arr[low];
            int leftPointer = low + 1;
            int rightPointer = high;

            while (true)
            {
                while (leftPointer <= rightPointer && arr[leftPointer] <= pivotValue)
                {
                    leftPointer++;
                }

                while (leftPointer <= rightPointer && arr[rightPointer] >= pivotValue)
                {
                    rightPointer--;
                }

                if (leftPointer > rightPointer)
                {
                    break;
                }
                else
                {
                    int temp = arr[leftPointer];
                    arr[leftPointer] = arr[rightPointer];
                    arr[rightPointer] = temp;
                }
            }

            // 枢纽值与判断用的指针交换位置
            int temp2 = arr[low];
            arr[low] = arr[rightPointer];
            arr[rightPointer] = temp2;

            return rightPointer;
        }






        // 选择排序 选择类排序
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

        // 堆排序 选择类排序*







        // 简单插入排序1 插入类
        public static List<int> InsertSort1(List<int> arr)
        {
            int len = arr.Count;

            for (int end = 1; end < len; end++)
            {
                for (int pre = end - 1; pre >= 0 && arr[pre] > arr[pre + 1]; pre--)
                {
                    Swap(arr, pre, pre + 1);
                }
            }
            return arr;
        }

        // 简单插入排序2 插入类
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

        // 希尔排序 插入类*





        // 基于分治思想

        // 归并排序 归并类  // 不断划分子块到单独元素，不断归并（划分和归并顺序相同），归并过程中保持子块有序
        public static void MergeSrot(List<int> arr)
        {
            MergeSrotFunc(arr, 0, arr.Count - 1);
        }
        private static void MergeSrotFunc(List<int> arr, int left, int right)
        {
            int mid = (left + right) / 2;

            // left和right代表最左侧和最右侧下标，满足条件才会继续递归划分，若相同则表示已经划分到最小单位了
            if (left < right)
            {
                // 递归划分左侧
                MergeSrotFunc(arr, left, mid);
                // 递归划分右侧
                MergeSrotFunc(arr, mid + 1, right);
                // 执行排序与合并
                Merge(arr, left, mid, right);
            }
        }
        private static void Merge(List<int> arr, int left, int mid, int right)
        {
            int[] temp = new int[arr.Count];
            // 左半区 第一个未排序元素下标
            int lPos = left;
            // 右半区 第一个未排序元素下标
            int rPos = mid + 1;
            // 临时list下标
            int tempPos = left;

            // 如果左右都还有未合并元素，不断比较左右大小，不断放入临时数组，直到while条件不满足
            while (lPos <= mid && rPos <= right)
            {
                // 左边更小，放入临时数组，左边下标++
                if (arr[lPos] < arr[rPos])
                    temp[tempPos++] = arr[lPos++];

                // 右边更小，放入临时数组，右边下标++
                else //if (arr[lPos] > arr[rPos])
                    temp[tempPos++] = arr[rPos++];
            }

            // 如果左侧还有未合并元素，则直接放入临时数组
            while (lPos <= mid)
                temp[tempPos++] = arr[lPos++];

            // 如果右侧还有未合并元素，则直接放入临时数组
            while (rPos <= right)
                temp[tempPos++] = arr[rPos++];

            // 临时数组拷贝到原数组中
            while (left <= right)
            {
                arr[left] = temp[left];
                left++;
            }
        }

        // 二路归并

        // 多路归并







        // 桶排序 非比较类排序 
        // 桶排序
        // 计数排序
        // 基数排序







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
