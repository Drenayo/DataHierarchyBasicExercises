using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHierarchyBasicExercises.DataStructure
{
    class LinkedListQueue<T> : IQueue<T>
    {
        public LinkedListQ<T> list;
        public int Count { get { return list.Count; } }
        public bool IsEmpty { get { return list.IsEmpty; } }

        public LinkedListQueue()
        {
            list = new LinkedListQ<T>();
        }

        public void Clear()
        {
            //throw new NotImplementedException();
        }

        public T Dequeue()
        {
            if (list.IsEmpty)
                throw new InvalidOperationException("队列为空！");
            return list.RemoveFirst();
        }

        public void Enqueue(T item)
        {
            list.AddLast(item);
        }

        public override string ToString()
        {
            return list.ToString();
        }
    }

    class LinkedListQ<T>
    {
        private class Node
        {
            public T data;
            public Node next;

            public Node(T data, Node next)
            {
                this.data = data;
                this.next = next;
            }
            public Node(T data)
            {
                this.data = data;
            }

            public override string ToString()
            {
                if (data == null)
                {
                    return "null";
                }
                return data.ToString();
            }
        }
        private Node head;
        private Node tail;
        private int count;
        public int Count { get { return count; } }
        public bool IsEmpty { get { return count == 0; } }

        public LinkedListQ()
        {
            head = null;
            tail = null;
            count = 0;
        }
    
        // 尾部添加
        public void AddLast(T item)
        {
            Node node = new Node(item);

            if (IsEmpty)
            {
                head = node;
                tail = node;
            }
            else
            {
                // 尾指针的下一个节点指向新节点
                tail.next = node;
                tail = node;
            }
            count++;
        }

        // 首部删除
        public T RemoveFirst()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("链表为空！");
            }
            else
            {
                Node del = head;
                head = head.next;
                count--;

                if (head == null)
                    tail = null;
                return del.data;
            }
        }

        //TOSting

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            Node cur = head;
            while (cur != null)
            {
                str.Append(cur + "=>");
                cur = cur.next;
            }
            str.Append("nullEnd");
            return str.ToString();
        }
    }
}
