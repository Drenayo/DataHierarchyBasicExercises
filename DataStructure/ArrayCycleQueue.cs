using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHierarchyBasicExercises.DataStructure
{
    /// <summary>
    /// 循环数组队列
    /// </summary>
    class ArrayCycleQueue<T>
    {
        private MyArrayList3<T> arr;
        public ArrayCycleQueue()
        {
            arr = new MyArrayList3<T>();
        }
        public ArrayCycleQueue(int capacity)
        {
            arr = new MyArrayList3<T>(capacity);
        }
        public int Count { get { return arr.Count; } }
        public bool IsEmpty { get { return arr.Count == 0; } }

        public T Dequeue()
        {
            if (arr.IsEmpty)
                throw new InvalidOperationException("队列为空！");
            return arr.RemoveFirst();
        }

        public void Enqueue(T item)
        {
            arr.AddLast(item);
        }

        public override string ToString()
        {
            return arr.ToString();
        }
    }
}
