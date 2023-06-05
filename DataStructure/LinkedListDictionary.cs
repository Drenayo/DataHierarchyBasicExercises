using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHierarchyBasicExercises.DataStructure
{
    /// <summary>
    /// 链表实现的字典
    /// </summary>
    class LinkedListDictionary<Key, Value> : IDictionary<Key, Value>
    {

        private LinkedListD<Key, Value> list;
        public LinkedListDictionary()
        {
            list = new LinkedListD<Key, Value>();
        }
        public int Count { get { return list.Count; } }
        public bool IsEmpty { get { return list.IsEmpty; } }

        public void Add(Key key, Value value)
        {
            list.Add(key, value);
        }

        public bool ContainsKey(Key key)
        {
            return list.ContainsKey(key);
        }

        public Value GetValue(Key key)
        {
            return list.GetValue(key);
        }

        public void Remove(Key key)
        {
            list.Remove(key);
        }

        public void SetValue(Key key, Value newValue)
        {
            list.SetValue(key, newValue);
        }
    }
    /// <summary>
    /// 私有链表结构
    /// </summary>
    class LinkedListD<Key, Value>
    {
        private class Node
        {
            public Key key;
            public Value value;
            public Node next;
            public Node(Key key, Value value, Node next)
            {
                this.key = key;
                this.value = value;
                this.next = next;
            }

            public override string ToString()
            {
                return $"[{key.ToString()}|{value.ToString()}]";
            }
        }

        private Node head;
        private int count;
        public int Count { get { return count; } }
        public bool IsEmpty { get { return count == 0; } }
        public LinkedListD()
        {
            head = null;
            count = 0;
        }

        // 基础功能
        private Node GetNode(Key key)
        {
            Node cur = head;
            while (cur != null)
            {
                if (cur.key.Equals(key))
                {
                    return cur;
                }
                cur = cur.next;
            }
            return null;
        }

        // 添加
        public void Add(Key key, Value value)
        {
            if (!ContainsKey(key)) // 字典中没有这个值，可以添加
            {
                head = new Node(key, value, head);
                count++;
            }
            else
            {
                throw new ArgumentException("字典不允许重复添加！");
            }
        }

        // 删除
        public void Remove(Key key)
        {
            Node cur = head;
            Node pre = null;

            while (cur != null)
            {
                if (cur.key.Equals(key))
                {
                    // 如果删除的是头节点 则将头节点指向下一个节点
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

        // 查找Key
        public bool ContainsKey(Key key)
        {
            return GetNode(key) != null;
        }

        // 获取
        public Value GetValue(Key key)
        {
            Node node = GetNode(key);
            return node != null ? node.value : throw new ArgumentException("键不存在！");
        }

        // 修改
        public void SetValue(Key key, Value value)
        {
            Node node = GetNode(key);
            if (node != null)
                node.value = value;
            else
                throw new ArgumentException("键不存在！");
        }
    }
}