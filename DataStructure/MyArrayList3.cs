using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHierarchyBasicExercises.DataStructure
{
    /// <summary>
    /// 循环队列使用的动态数组
    /// </summary>
    class MyArrayList3<T>
    {
        // 数据
        private T[] data;

        private int first;
        private int last;
        private int count;

        public int Count { get { return count; } }
        public bool IsEmpty { get { return count == 0; } }



        // 构造
        public MyArrayList3() : this(10) { }
        public MyArrayList3(int cap)
        {
            data = new T[cap];
            first = 0;
            last = 0;
            count = 0;
        }


        // 向数组末尾添加一个元素
        public void AddLast(T item)
        {
            // 扩容判断
            if (count == data.Length)
            {
                ResetCapacity(2 * data.Length);
            }

            // 数组末尾赋值
            data[last] = item;

            // 偏移Last的值
            // （last + 1）是因为每次添加一次，末尾下标需要向后偏移一位
            // % 总长度则是因为，如果后面没空间了而前面有空间，则需要循环偏移，取模 总长度即可做到这点
            last = (last + 1) % data.Length;

            // 数量++
            count++;
        }

        // 删除数组开头的元素
        public T RemoveFirst()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("数组为空");
            }

            T del = data[first];
            data[first] = default(T);

            first = (first + 1) % data.Length;

            count--;

            // 缩容判断
            if (count == data.Length/4)
            {
                ResetCapacity(data.Length/2);
            }

            return del;

        }

        // 扩容
        private void ResetCapacity(int newCapacity)
        {
            T[] newData = new T[newCapacity];

            for (int i = 0; i < count; i++)
            {
                // 循环数组的首位指向 + 1 同时 取模 数组长度
                newData[i] = data[(first + i) % data.Length];
            }
            data = newData;
            first = 0;
            last = count;
        }

        //
        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append("[");

            for (int i = 0; i < count; i++)
            {
                str.Append(data[(first + i) % data.Length]);

                // 判断是否是数组末尾，是末尾就不加逗号了
                if ((first + i + 1) % data.Length != last)
                    str.Append(",");
            }
            str.Append("]");
            return str.ToString();
        }
    }
}
