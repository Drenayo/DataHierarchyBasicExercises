using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHierarchyBasicExercises.DataStructure
{
    /// <summary>
    /// 自定义字符串  各种操作实现 KMP
    /// </summary>
    class MyString
    {
        private char[] chars;
        private int length;
        public int Length { get { return length; } }

        public MyString(string str)
        {
            chars = str.ToArray();
            length = chars.Length;
        }

        // 索引器
        public char this[int i]
        {
            get { return chars[i]; }
        }

        public override string ToString()
        {
            return new string(chars);
        }

        // 相互比较 比较的是单个字符的排序
        // 相同0，1大返回1，2大返回-1
        public static int Compare(MyString str1, MyString str2)
        {
            if (str1.Equals(str2)) return 0;

            if (str1 == null) return -1;
            if (str2 == null) return 1;

            for (int i = 0; i < str1.Length && i < str2.Length; i++)
            {
                // char-char得到 两者编码顺序的插值，若相同则零
                int diff = str1[i] - str2[i];
                if (diff != 0)
                    return diff;
            }

            return str1.length - str2.length;
        }

        // 创建一个具有相同值的新对象
        public MyString Copy()
        {
            return new MyString(this.ToString());
        }

        // 拼接字符串
        public static MyString Concat(MyString s1, MyString s2)
        {
            return new MyString(s1.ToString() + s2.ToString());
        }


        // 查找匹配字串 算法 BF BM KMP Sunday

        // BF算法 暴力匹配
        public int IndexOf_BF(string str)
        {
            string mainStr = this.ToString();
            string subStr = str;
            int mainLen = mainStr.Length;
            int subLen = subStr.Length;

            // 意外情况首先排除
            if (mainLen == 0 || subLen == 0 || subLen > mainLen)
                return -1;

            // 通过一个循环遍历主串中的每个可能的起始位置，即从第一个字符到倒数第二个字符
            for (int i = 0; i < mainLen - subLen + 1; i++)
            {
                int j = 0; // 记录已经匹配字串的长度
                // 从第i个开始遍历，往后遍历j 匹配则j++
                while (j < subLen && mainStr[i + j] == subStr[j])
                {
                    j++;
                }
                if (j == subLen)
                    return i;
            }
            return -1;
        }

        public int IndexOf_KMP(string str)
        {

        }
    }
}
