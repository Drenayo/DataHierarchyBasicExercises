using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHierarchyBasicExercises.Utils
{
    /// <summary>
    /// 生成测试数据
    /// </summary>
    class GenerateTestData
    {
        /// <summary>
        /// 生成一个固定长度的随机int数组
        /// </summary>
        public static int[] GetRandomLengthArray_Int(int size, int maxValue)
        {
            Random random = new Random();
            int[] arr = new int[size];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = random.Next(maxValue);
            }

            return arr;
        }


        /// <summary>
        /// 生成一个固定长度的随机List<int>
        /// </summary>
        public static List<int> GetRandomLengthList_Int(int size, int maxValue)
        {
            Random random = new Random();
            List<int> list = new List<int>();
            for (int i = 0; i < size; i++)
            {
                list.Add(random.Next(maxValue));
            }

            return list;
        }

        /// <summary>
        /// 生成一个固定长度的随机List string
        /// </summary>
        public static List<string> GetRandomLengthList_String(int size,int strLength)
        {
            const string validChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();
            List<string> list = new List<string>();

            for (int i = 0; i < size; i++)
            {
                StringBuilder str = new StringBuilder(strLength);
                for (int j = 0; j < strLength; j++)
                {
                    str.Append(validChars[random.Next(validChars.Length)]);
                }
                list.Add(str.ToString());
            }
            

            return list;
        }
    }
}
