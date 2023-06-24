using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHierarchyBasicExercises.Training
{
    class 动态数组练习<T>
    {
        private T[] array;
        private int length;
        public int Length { get { return length; } }
        private int capacity;
        public int Capacity { get { return capacity; } }
        public 动态数组练习(int capacity)
        {
            array = new T[capacity];
            length = 0;
            this.capacity = capacity;
        }
        public 动态数组练习() : this(10) { }


        // 插入
        public void Insert(int index, T e)
        {
            if (index < 0 || index > capacity) throw new Exception("数组下标越界！");

            // 数组满了扩容
            if (length == capacity) return;
            ResetCapacity(capacity * 2);

            // 不满插入，index后面的统一向后移动一位
            for (int i = length - 1; i >= index; i++)
            {
                array[i + 1] = array[i];
            }
            array[index] = e;
            length++;
        }

        // 删除

        // 查询

        // 扩容
        public void ResetCapacity(int newCapacity)
        {
            T[] newArray = new T[newCapacity];

            for (int i = 0; i < length; i++)
                newArray[i] = array[i];

            array = newArray;// 指向
        }


    }
}

/*
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 */
