using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHierarchyBasicExercises.DataStructure
{
    class ArrayStack<T> : IStack<T>
    {
        // 直接使用之前写好的动态数组来作为数据存放
        private MyArrayList2<T> arr;
        public int Count { get { return arr.Count; } }
        public bool IsEmpty { get { return arr.Count == 0; } }

        public ArrayStack(int capacity)
        {
            arr = new MyArrayList2<T>(capacity);
        }
        public ArrayStack()
        {
            arr = new MyArrayList2<T>();
        }

        // 添加一个元素到栈中
        public void Push(T item)
        {
            arr.Add(item);
        }

        // 获取栈顶元素
        public T Peek()
        {
            return arr.GetValue(Count - 1);
        }

        // 删除栈顶元素
        public T Pop()
        {
            return arr.RemoveAt(Count - 1);
        }

        public override string ToString()
        {
            return arr.ToString();
        }
    }
}
