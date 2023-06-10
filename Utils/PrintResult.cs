using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHierarchyBasicExercises.Utils
{
    /// <summary>
    /// 打印结果专用
    /// </summary>
    class PrintResult<T>
    {
        // 打印数组
        public static void PrintArray(T[] arr)
        {
            Console.WriteLine("打印数组:");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }

        // 打印列表
        public static void PrintList(List<T> list)
        {
            Console.WriteLine("打印列表:");
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write(list[i] + " ");
            }
            Console.WriteLine();
        }

        // 打印列表 填充信息，优化显示
        public static void PrintList(List<T> list,string info)
        {
            Console.WriteLine(info);
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write(list[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
