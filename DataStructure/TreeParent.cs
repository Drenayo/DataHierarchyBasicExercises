using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHierarchyBasicExercises.DataStructure
{
    /// <summary>
    /// 普通树实现 父节点表示法
    /// </summary>
    class TreeParent<T>
    {
        public class Node
        {
            T data;
            public int parent;

            public T Data { get { return data; } }

            public Node() { }
            public Node(T value)
            {
                data = value;
            }
            public Node(T value, int parent)
            {
                this.data = value;
                this.parent = parent;
            }

            public override string ToString()
            {
                return $"[Data={data.ToString()},ParentIndex={parent.ToString()}]";
            }
            public string Print()
            {
                return $"[{data}|{parent}]";
            }
        }

        // 节点数组
        private Node[] nodes;
        // 记录节点数量
        private int nodeNums;
        // 树大小
        private int treeSize = 0;

        public bool IsEmpty { get { return nodeNums == 0; } }
        public Node Root { get { return nodes[0]; } }

        // 构造 指定根节点
        public TreeParent(T data) : this(data, 100) { }

        // 构造 指定根节点 指定size
        public TreeParent(T data, int size)
        {
            treeSize = size;
            nodes = new Node[treeSize];
            nodes[0] = new Node(data, -1);
            nodeNums++;
        }

        // 获取某个节点的父节点
        public Node GetParent(Node node)
        {
            if (node.parent == -1)
                throw new Exception("非根节点才有父节点！");
            return nodes[node.parent];
        }

        // 通过值获取节点
        public Node GetNodeByData(T data)
        {
            for (int i = 0; i < treeSize; i++)
            {
                if (nodes[i].Data.Equals(data))
                {
                    return nodes[i];
                }
            }
            return null;
        }

        // 获取某个节点的索引值
        public int GetNodeIndex(Node node)
        {
            for (int i = 0; i < treeSize; i++)
            {
                if (nodes[i].Equals(node))
                    return i;
            }
            return -1;
        }


        // 为指定节点添加子节点
        public void addNode(T data, Node parent)
        {
            for (int i = 0; i < treeSize; i++)
            {
                // 遍历，找到空的地方添加
                if (nodes[i] == null)
                {
                    nodes[i] = new Node(data, GetNodeIndex(parent));
                    nodeNums++;
                    return;
                }
            }
        }

        // 返回指定节点的所有子节点
        public List<Node> GetChildren(Node parent)
        {
            List<Node> list = new List<Node>();
            for (int i = 0; i < treeSize; i++)
            {
                if (nodes[i] != null && nodes[i].parent == GetNodeIndex(parent))
                    list.Add(nodes[i]);
            }
            return list;
        }

        // 返回树的深度
        public int GetDeep()
        {
            int max = 0;
            // 从下标0开始向上遍历查找父节点
            for (int i = 0; i < treeSize && nodes[i] != null; i++)
            {
                // 初始化节点深度
                int def = 1;
                // 当前节点的父节点的索引
                int m = nodes[i].parent;

                while (m != -1 && nodes[m] != null)
                {
                    m = nodes[m].parent;
                    def++;
                }
                if (max < def) max = def;
            }
            return max;
        }

        // 线性打印
        public void PrintArray()
        {
            Console.WriteLine("线性遍历:");
            for (int i = 0; i < treeSize && nodes[i] != null; i++)
            {
                Console.Write(nodes[i].Print());
            }
            Console.WriteLine();
        }

        // 层次打印
        public void LevelPrintArray()
        {
        //    if (IsEmpty) return;

        }

    }
}
