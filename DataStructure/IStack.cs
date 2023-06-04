using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHierarchyBasicExercises.DataStructure
{
    interface IStack<T>
    {
        int Count { get; }
        bool IsEmpty { get; }
        void Push(T item);
        T Pop();
        T Peek();
    }
}
