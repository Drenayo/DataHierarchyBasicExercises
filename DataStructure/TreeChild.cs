using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHierarchyBasicExercises.DataStructure
{
    /// <summary>
    /// 普通树实现 孩子表示法  子节点链  多叉树
    /// </summary>
    class TreeChild<T>
    {
        public class SonNode
        {
            // 节点在数组中的索引
            public int pos;
            // 下一个节点
            public SonNode next;

            public SonNode(int pos, SonNode next)
            {
                this.pos = pos;
                this.next = next;
            }
        }
        public class Node
        {
            public T data;
            /// <summary>
            /// 第一个子节点的指向
            /// </summary>
            public SonNode first;
            public Node(T data)
            {
                this.data = data;
                this.first = null;
            }

            public override string ToString()
            {
                return $"[{data}]";
                //if (first != null)
                //    return $"[{data}|{first.pos}]";
                //else
                //    return $"[{data}|null]";
            }
        }

        private int treeSize = 0;
        private Node[] nodes;
        private int nodeNums;
        public bool IsEmpty { get { return nodeNums == 0; } }
        public Node Root { get { return nodes[0]; } }

        // 构造
        public TreeChild(T data, int treeSize)
        {
            this.treeSize = treeSize;
            nodes = new Node[treeSize];
            nodes[0] = new Node(data);
            nodeNums++;
        }
        public TreeChild(T data) : this(data, 100) { }


        // 为指定节点添加子节点
        public Node AddNode(T data, Node parent)
        {
            for (int i = 0; i < treeSize; i++)
            {
                if (nodes[i] == null)
                {
                    nodes[i] = new Node(data);

                    // 如果该节点的子节点列表为空，则加入
                    if (parent.first == null)
                        parent.first = new SonNode(i, null);
                    // 如果该节点已经有子节点了，则加入到子节点链的末尾处
                    else
                    {
                        SonNode next = parent.first;
                        // 链表不断遍历查找，直到找到最后一个子节点，跳出遍历，把新节点添加到子节点链末尾
                        while (next.next != null)
                            next = next.next;

                        next.next = new SonNode(i, null);
                    }
                    nodeNums++;
                    return nodes[i];
                }
            }
            throw new Exception("该树已经满了，无法添加新的节点");
        }

        // 根据值获取某个子节点
        public Node GetNodeByData(T data)
        {
            for (int i = 0; i < treeSize; i++)
            {
                if (nodes[i].data.Equals(data))
                    return nodes[i];
            }
            return null;
        }

        // 获取某个节点的索引值
        public int GetNodeIndex(Node node)
        {
            for (int i = 0; i < treeSize; i++)
            {
                if (nodes[i].Equals(node))
                {
                    return i;
                }
            }
            return -1;
        }

        // 返回指定节点的所有子节点
        public List<Node> GetChildren(Node parent)
        {
            List<Node> list = new List<Node>();

            // 获取指定节点的第一个子节点
            SonNode next = parent.first;
            // 判空 异常
            if (next == null) throw new Exception("叶子节点无子节点");

            while (next != null)
            {
                list.Add(nodes[next.pos]);
                next = next.next;
            }
            return list;
        }

        // 返回指定节点的第index个子节点
        public Node GetChild(Node parent, int index)
        {
            // 获取指定节点的第一个子节点
            SonNode next = parent.first;
            // 判空 异常
            if (next == null) throw new Exception("叶子节点无子节点");

            for (int i = 0; next != null; i++)
            {
                // i负责计数，拿到当前子节点链的第N个子节点
                if (index == i)
                    return nodes[next.pos];
                // 链表继续一直向前遍历该节点的子节点链
                next = next.next;
            }
            return null;
        }

        // 得到树的深度
        public int GetDeep()
        {
            return deep(Root);
        }

        private int deep(Node node)
        {
            if (node.first == null) return 1;

            int max = 0;
            SonNode next = node.first;

            // 沿着子节点链不断向下
            while (next != null)
            {
                // 递归 每次向下迭代一层，返回max+1，直到next==null,结束递归，同时返回最大深度
                int tmp = deep(nodes[next.pos]);

                if (tmp > max)
                    max = tmp;
                next = next.next;
            }
            return max + 1;
        }

        // 线性打印
        public void PrintArray()
        {
            Console.WriteLine("线性遍历:");
            for (int i = 0; i < treeSize && nodes[i] != null; i++)
            {
                Console.Write(nodes[i]);
            }
            Console.WriteLine();
        }


        // 前序遍历
        public void PreOrderTraversal(Node node)
        {
            if (node != null)
            {
                Console.Write(node);
                if (node.first != null)
                {
                    foreach (Node child in GetChildren(node))
                    {
                        PreOrderTraversal(child);
                    }
                }
            }
        }

        // 后序遍历
        public void PostOrderTraversal(Node node)
        {
            if (node != null)
            {
                
                if (node.first != null)
                {
                    foreach (Node child in GetChildren(node))
                    {
                        PostOrderTraversal(child);
                    }
                }
                Console.Write(node);
            }
        }

        // 层序遍历
        public void LevelOrderTraversal(Node root)
        {
            if (root == null) return;
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);


            while (queue.Count > 0)
            {
                int levelSize = queue.Count;
                for (int i = 0; i < levelSize; i++)
                {
                    Node node = queue.Dequeue();
                    Console.Write(node + "  ");
                    if (node.first != null)
                        foreach (Node child in GetChildren(node))
                        {
                            queue.Enqueue(child);
                        }
                }
                Console.WriteLine();
            }
        }
    }
}
