using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHierarchyBasicExercises.DataStructure
{
    /// <summary>
    /// 自定义 ArrayList
    /// 第一版，有关查找都是遍历实现的
    /// 类型只能支持int
    /// MyArrayList2 第二版使用泛型
    /// </summary>
    class MyArrayList2<T>
    {
        private T[] data;
        /// <summary>
        /// 实际包含的元素数量 NNNNNNN
        /// </summary>
        private int count;

        // 可包含的元素个数
        public int Capacity { get { return data.Length; } }
        // 实际元素个数
        public int Count { get { return count; } }
        // 是否为空
        public bool IsEmpty { get { return count == 0; } }


        // 构造
        public MyArrayList2(int capacity)
        {
            data = new T[capacity];
            count = 0;
        }
        //构造函数重载和构造函数链式调用
        public MyArrayList2() : this(10) { }

        // 重置数组容量方法
        private void ResetCapacity(int newCapacity)
        {
            // 创建新数组，将数据复制到新数组，并且指向新数组
            T[] newData = new T[newCapacity];
            for (int i = 0; i < count; i++)
            {
                newData[i] = data[i];
            }
            data = newData;
        }

        // 判断索引是否有效，是否会引发异常，是否会越界
        private bool IsIndexValid(int index)
        {
            bool isIndexValid = true;

            // 索引不能等于-1   索引不能大于等于实际容量，因为下标从零开始
            if (index < 0 || index >= count)
            {
                isIndexValid = false;
                throw new ArgumentException("数组索引越界！");
            }

            return isIndexValid;
        }

        // 根据索引得到值
        public T GetValue(int index)
        {
            IsIndexValid(index);

            return data[index];
        }

        // 根据索引设置值
        public void SetValue(int index, T e)
        {
            IsIndexValid(index);

            data[index] = e;
        }

        // 在数组末尾添加一个值
        public void Add(T e)
        {
            Insert(count, e);
        }

        // 移除所有元素
        public void Clear()
        {
            for (int i = 0; i < count; i++)
            {
                data[i] = default(T);
            }
            count = 0;
            // 删除完毕判断是否需要缩小数组容量
        }

        // 判断某个元素是否在数组中
        public bool Contains(T e)
        {
            for (int i = 0; i < count; i++)
            {
                if (data[i].Equals(e))
                    return true;
            }
            return false;
        }

        // 返回某个值在数组中第一次出现的索引值
        public int IndexOf(int e)
        {
            for (int i = 0; i < count; i++)
            {
                if (data[i].Equals(e))
                    return i;
            }
            return -1;
        }

        // 删除第一次出现的指定值
        public void Remove(T e)
        {
            for (int i = 0; i < count; i++)
            {
                if (data[i].Equals(e))
                    RemoveAt(i);
            }
        }

        // 删除指定索引处的元素
        public T RemoveAt(int index)
        {
            IsIndexValid(index);
            T del = data[index];
            for (int i = index + 1; i <= count - 1; i++)
            {
                data[i - 1] = data[i];
            }
            count--;
            data[count] = default(T);

            // 数组删除了 则缩小到4/1时，缩小一半
            if (count == Capacity / 4)
                ResetCapacity(Capacity / 2);

            return del;
        }

        // 在指定索引处插入一个元素
        public void Insert(int index, T e)
        {
            if (index < 0 || index > count)
            {
                throw new ArgumentException("数组索引越界！");
            }

            // 数组满了 则扩容
            if (count == Capacity)
                ResetCapacity(Capacity * 2);

            for (int i = count - 1; i >= index; i++)
            {
                data[i + 1] = data[i];
            }
            data[index] = e;
            count++;
        }

        //public void Sort()
        //{
        //    int len = data.Length;

        //    for (int end = 1; end < len; end++)
        //    {
        //        T temp = 0;
        //        int newNumIndex = end;
        //        while (newNumIndex - 1 >= 0 && data[newNumIndex - 1] > data[newNumIndex])
        //        {
        //            temp = data[newNumIndex - 1];
        //            data[newNumIndex - 1] = data[newNumIndex];
        //            data[newNumIndex] = temp;
        //            newNumIndex--;
        //        }
        //    }
        //}

        // 设置容量为元素的实际个数，适合数量量变化不大，不频繁
        public void TrimToSize()
        {
            ResetCapacity(count);
        }

        // 重写ToString
        public override string ToString()
        {
            StringBuilder res = new StringBuilder();
            //res.Append(string.Format($"[元素数量:{count},数组容量:{data.Length}]\n"));
            res.Append(string.Format("["));

            for (int i = 0; i < count; i++)
            {
                res.Append(data[i]);
                if (i != count - 1)
                    res.Append(", ");
            }

            res.Append(string.Format("]"));
            return res.ToString();
        }
    }
}