using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHierarchyBasicExercises.DataStructure
{
    class LinkedListStack<T> : IStack<T>
    {
        private List<T> list;
        public LinkedListStack()
        {
            list = new List<T>();
        }
        public int Count { get { return list.Count; } }
        public bool IsEmpty { get { return list.Count != 0; } }

        // 获取栈顶
        public T Peek()
        {
            return list[Count-1];
        }

        // 删除栈顶
        public T Pop()
        {
            T temp = Peek();
            list.RemoveAt(Count - 1);
            return temp;   
        }

        // 向栈中添加元素
        public void Push(T item)
        {
            list.Add(item);
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();

            for (int i = 0; i < list.Count; i++)
            {
                str.Append(list[i] + " ");
            }

            return str.ToString();
        }
    }
}
