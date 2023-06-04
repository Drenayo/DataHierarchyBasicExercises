using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHierarchyBasicExercises.DataStructure
{
    interface IQueue<T>
    {
        /// <summary>
        /// 在队列末尾添加一个元素
        /// </summary>
        /// <param name="item"></param>
        void Enqueue(T item);

        /// <summary>
        /// 清空队列
        /// </summary>
        void Clear();


        /// <summary>
        /// 移除队列开头的元素并返回
        /// </summary>
        /// <returns></returns>
        T Dequeue();


        int Count { get; }

        bool IsEmpty { get; }

    }
}
