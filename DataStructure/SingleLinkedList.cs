using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHierarchyBasicExercises.DataStructure
{
    /// <summary>
    /// 单链表
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class SingleLinkedList<T>
    {
        // 节点类
        private class Node
        {
            // 节点值
            public T data;
            // 节点指向的下一个节点
            public Node next;

            // 构造 同时赋值当前节点和下一个节点
            public Node(T node, Node next)
            {
                this.data = node;
                this.next = next;
            }

            // 构造 只赋值当前节点
            public Node(T node)
            {
                this.data = node;
                this.next = null;
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

        // 头节点永远指向第一个节点
        private Node head;
        // 当前链表节点数量
        private int count;
        public int Count { get { return count; } }
        public bool IsEmpty { get { return count == 0; } }

        // 链表构造
        public SingleLinkedList()
        {
            head = null;
            count = 0;
        }

        // -----------------------------------------

        /// <summary>
        /// 索引下标是否越界查询
        /// 插入索引和查询索引的判定条件不一样
        /// 因为插入可以插入到与count相同的位置，查询不能越界因为count比索引小一位
        /// </summary>
        private void IsIndexValid(int index)
        {
            if (index < 0 || index >= count)
                throw new ArgumentOutOfRangeException("数组下标越界异常_List");
        }

        // 链表是否包含此元素
        public bool Contains(T item)
        {
            // 验证一下------------------------------------------------------
            //Node cur = head;
            //for (int i = 0; i < count; i++)
            //{
            //    if (cur != null && cur.node.Equals(item))  // 可能导致异常  cur.node可能为空   count
            //    {
            //        return true;
            //    }
            //    cur = cur.next;
            //}

            //return false;

            // ------------

            Node cur = head;
            while (cur != null)
            {
                if (cur.data != null && cur.data.Equals(item))
                    return true;
                cur = cur.next;
            }
            return false;
        }

        // 将元素添加到指定索引处
        public void Insert(int index, T item)
        {
            if (index < 0 || index > count)
            {
                throw new ArgumentOutOfRangeException("数组下标越界异常_List");
            }

            // 1.插入头节点 - 链表为空情况下
            // new一个新节点，新节点的下一个节点指向头节点（链表为空，头节点也为空）
            // 头节点指向新节点
            // 新节点就成了链表唯一点击，新的头节点

            // 2.插入头节点 - 链表不为空
            // new一个新节点，新节点下一个节点指向原来的头节点
            // head在指向新节点，这样原来的头节点就成了新节点的下一个节点
            if (index == 0)
            {
                Node node = new Node(item);
                node.next = head;
                head = node;

                // 简写 head = new Node(item,head);
            }
            // 头节点不为空的情况下
            else
            {
                // 将头节点复制一份给pre，pre用来从头节点遍历到索引位置，临时变量
                Node pre = head;

                // 从头开始遍历到插入索引-1处
                // i 每次+1，pre就自动指向下一个next，直到遍历到插入所以的前一个节点为止
                for (int i = 0; i < index - 1; i++)
                    pre = pre.next;


                // pre当前属于待插入的前一个节点，next指向的是索引处原来的节点
                // new的新节点的next指向原索引处节点，索引前节点next指向新节点

                // 将pre节点的next指针指向新节点，同时将新节点的next指针指向原来pre节点的后继节点
                pre.next = new Node(item, pre.next);
            }
            count++;
        }

        // 根据索引得到值
        public T GetValue(int index)
        {
            IsIndexValid(index);

            Node cur = head;
            for (int i = 0; i < index; i++)
                cur = cur.next;

            return cur.data;
        }

        // 根据索引修改值 
        public void SetValue(int index, T item)
        {
            IsIndexValid(index);

            Node cur = head;
            for (int i = 0; i < index; i++)
                cur = cur.next;

            cur.data = item;
        }

        // 将元素添加到链表末尾处
        public void Add(T item)
        {
            Insert(count, item);
        }

        // 删除指定索引处的节点
        public T RemoveAt(int index)
        {
            IsIndexValid(index);

            if (index == 0)
            {
                Node del = head;
                head = head.next;
                count--;
                return del.data;
            }

            // 找到索引前置节点
            Node pre = head;
            for (int i = 0; i < index - 1; i++)
            {
                pre = pre.next;
            }

            // 获取前置节点next指向的节点
            Node delNode = pre.next;
            // 将前置节点next指向后后节点
            pre.next = delNode.next;

            count--;
            return delNode.data;

        }

        // 删除指定元素在链表的第一个匹配项
        public void Remove(T item)
        {
            // 第一种写法 while循环匹配元素，记录下标，调用RemoveAt删除
            //Node cur = head;
            //int index = 0;
            //while (cur != null)
            //{
            //    if (cur.data != null && cur.data.Equals(item))
            //    {
            //        RemoveAt(index);
            //        return;
            //    }
            //    index++;
            //    cur = cur.next;
            //}



            // 第二种写法 while循环匹配元素，同时记录前向节点
            Node cur = head;
            Node pre = null;
            while (cur != null)
            {
                if (cur.data != null && cur.data.Equals(item))
                {
                    if (head == cur)
                    {
                        head = head.next;
                    }
                    else
                    {
                        pre.next = cur.next;
                    }
                    count--;
                    return;
                }
                pre = cur;
                cur = cur.next;
            }
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            Node cur = head;
            while (cur != null)
            {
                str.Append(cur + "->");
                cur = cur.next;
            }
            str.Append("End(Null)");
            return str.ToString();
        }
    }
}
