using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHierarchyBasicExercises.Problem
{
    /// <summary>
    /// 打印二进制，位操作相关练习
    /// </summary>
    class PrintBinary
    {
        // 打印一个数字的二进制
        public static void PrintNumberBinary(int num)
        {
            for (int i = 31; i >= 0; i--)
            {
                Console.Write((num & (1 << i)) == 0 ? '0' : '1');
            }
            Console.WriteLine();
        }
    }
}