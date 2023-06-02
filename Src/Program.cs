using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataHierarchyBasicExercises.Src.class01;

namespace DataHierarchyBasicExercises
{
    class Program
    {
        static void Main(string[] args)
        {



            AlgorithmTester.Testor(100);

            //int[] arr = AlgorithmTester.GenerateRandomArray(39,1000);

            //Console.WriteLine("插入测试 原数组");
            //SortHelp.PrintArray(arr);

            //Console.WriteLine("插入测试 排序后");

            //Sort.InsertSort2(arr);
            //SortHelp.PrintArray(arr);


            #region 二进制与位操作测试

            /*
            int aNumber = 50;
            int bNumber = 340;

            Console.Write("原始值A打印       ");
            PrintBinary.PrintNumberBinary(aNumber);
            Console.Write("原始值B打印       ");
            PrintBinary.PrintNumberBinary(bNumber);

            Console.Write("AB 按位与 & 打印  ");
            PrintBinary.PrintNumberBinary(aNumber & bNumber);

            Console.Write("AB 按位或 | 打印：");
            PrintBinary.PrintNumberBinary(aNumber | bNumber);

            Console.Write("AB 按位异或 ^ 打印");
            PrintBinary.PrintNumberBinary(aNumber ^ bNumber);

            Console.Write("A 按位取反 ~ 打印 ");
            PrintBinary.PrintNumberBinary(aNumber<<1);

            Console.Write("A 按位右移   打印 ");
            PrintBinary.PrintNumberBinary(aNumber>>1);*/
            #endregion



            #region 测试排序算法
            /* int[] arr = SortHelp.GetRandom(10);

             Console.WriteLine("冒泡测试 原数组");
             SortHelp.PrintArray(arr);

             Console.WriteLine("冒泡测试 排序后");

             Sort.InsertSort2(arr);
             SortHelp.PrintArray(arr);*/
            #endregion


            Console.ReadKey();
        }
    }
}
