using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHierarchyBasicExercises.DataStructure
{
    class ArrayQueue<T> : IQueue<T>
    {
        private MyArrayList2<T> arr;
        public ArrayQueue()
        {
            arr = new MyArrayList2<T>();
        }
        public ArrayQueue(int capacity)
        {
            arr = new MyArrayList2<T>(capacity);
        }
        public int Count { get { return arr.Count; } }
        public bool IsEmpty { get { return arr.Count == 0; } }

        public void Clear()
        {
            arr.Clear();
        }

        public T Dequeue()
        {
            return arr.RemoveAt(0);
        }

        public void Enqueue(T item)
        {
            arr.Add(item);
        }

        public override string ToString()
        {
            return arr.ToString();
        }
    }
}
