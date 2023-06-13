using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHierarchyBasicExercises.Training
{
    // 使用二叉树的存储结构来存储N叉树，但是N叉树的层深、叶子节点个数和前序遍历等结果仍然是基于N叉树的树形结构计算得出的
    class NaryTree<T>
    {
        public class Node
        {
            public T data;
            public Node firstChild;
            public Node nextSibling;

            public Node(T data)
            {
                this.data = data;
            }
            public override string ToString()
            {
                return $"[{data.ToString()}]";
            }
        }
        private int count;
        public int Count { get { return count; } }
        public bool IsEmpty { get { return count == 0; } }
        private Node root;
        public Node Root { get { return root; } }

        public NaryTree()
        {
            root = null;
            count = 0;
        }

        public NaryTree(T data)
        {
            root = new Node(data);
            count = 1;
        }

        // 前序顺序创建
        public void CreateTree(string treeStr)
        {

        }

        // 添加节点
        public void Add(T data, Node parent)
        {
            Node newNode = new Node(data);
            if (IsEmpty)
            {
                root = newNode;
                count++;
                return;
            }
            if (!IsExists(parent)) throw new Exception("父节点不存在！");

            if (parent.firstChild == null)
                parent.firstChild = newNode;
            else
            {
                Node next = parent.firstChild;
                while (next.nextSibling != null)
                    next = next.nextSibling;

                next.nextSibling = newNode;
            }
            count++;
        }

        // 判断节点是否存在
        public bool IsExists(Node node)
        {
            if (node == null) return false;
            if (IsEmpty) return false;
            if (root.Equals(node)) return true;

            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                Node del = queue.Dequeue();
                if (del.firstChild != null)
                {
                    if (del.firstChild.Equals(node))
                        return true;
                    else
                        queue.Enqueue(del.firstChild);
                }

                if (del.nextSibling != null)
                {
                    if (del.nextSibling.Equals(node))
                        return true;
                    else
                        queue.Enqueue(del.nextSibling);
                }
            }
            return false;
        }

        // 根据值查找节点
        public Node FindNodeByData(T data)
        {
            if (IsEmpty) return null;
            if (root.data.Equals(data)) return root;

            Queue<Node> quene = new Queue<Node>();
            quene.Enqueue(root);

            while (quene.Count > 0)
            {
                Node del = quene.Dequeue();
                if (del.firstChild != null)
                {
                    if (del.firstChild.data.Equals(data))
                        return del.firstChild;
                    else
                        quene.Enqueue(del.firstChild);
                }
                if (del.nextSibling != null)
                {
                    if (del.nextSibling.data.Equals(data))
                        return del.nextSibling;
                    else
                        quene.Enqueue(del.nextSibling);
                }
            }
            return null;
        }

        // 递归前序 二叉树N叉树都符合
        public void PreOrderTraversal(Node node)
        {
            if (IsEmpty) return;
            if (node == null) return;
            Console.Write(node.data);
            PreOrderTraversal(node.firstChild);
            PreOrderTraversal(node.nextSibling);
        }

        // 递归后序 N叉树符合
        public void PostOrderTraversal(Node node)
        {

            if (IsEmpty) return;
            if (node == null) return;
            PostOrderTraversal(node.firstChild);
            PostOrderTraversal(node.nextSibling);
            Console.Write(node.data);
        }

        // 栈前序
        public void PreOrder_N(Node node)
        {
            if (IsEmpty) return;
            if (node == null) return;

            Stack<Node> stack = new Stack<Node>();
            stack.Push(node);

            while (stack.Count > 0)
            {
                Node del = stack.Pop();
                Console.Write(del.data);

                if (del.nextSibling != null)
                    stack.Push(del.nextSibling);
                if (del.firstChild != null)
                    stack.Push(del.firstChild);
            }

        }

        // 栈后序
        public void PostOrder_N(Node node)
        {
            if (IsEmpty) return;
            if (node == null) return;

            Stack<Node> stack = new Stack<Node>();
            Node vist = null;

            while (stack.Count != 0 || node != null)
            {
                if (node != null)
                {
                    stack.Push(node);
                    node = node.firstChild;
                }
                else
                {
                    Node peekNode = stack.Peek();
                    if (peekNode.nextSibling != null && vist != peekNode.nextSibling)
                        node = peekNode.nextSibling;
                    else
                    {
                        Console.Write(peekNode.data);
                        vist = stack.Pop();
                    }
                }
            }
        }

        // 队列层序 二叉树符合
        public void LevelOrderTraversal_2()
        {
            if (IsEmpty) return;
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                Node del = queue.Dequeue();
                Console.Write(del.data);

                if (del.firstChild != null)
                {
                    queue.Enqueue(del.firstChild);
                }

                if (del.nextSibling != null)
                    queue.Enqueue(del.nextSibling);
            }
        }

        // 队列层序 N叉树遍历
        public void LevelOrderTraversal_N()
        {
            if (IsEmpty) return;

            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                Node node = queue.Dequeue();
                Console.Write(node.data);

                Node childNode = node.firstChild;
                while (childNode != null)
                {
                    queue.Enqueue(childNode);
                    childNode = childNode.nextSibling;
                }
            }
        }

        // 按照多叉树结构打印节点
        public void PrintNaryTree()
        {
            // 拿到层深、叶子节点数、末尾层叶子节点数、每层节点数、所有节点数
        }

        // 获取层深**********N叉树的层深
        public int GetDepth(Node node)
        {
            if (IsEmpty) return 0;
            int depth = 0;

            Node childNode = node.firstChild;

            while (childNode != null)
            {
                int childDepth = GetDepth(childNode);
                if (childDepth > depth)
                    depth = childDepth;

                childNode = childNode.nextSibling;
            }
            return depth + 1;
        }
        // 获取层深 第二种写法
        public int GetDepth2(Node node)
        {
            if (node == null) return 0;
            else
            {
                int h1, h2;
                h1 = GetDepth2(node.firstChild) + 1;
                h2 = GetDepth2(node.nextSibling);
                return Math.Max(h1, h2);
            }
        }

        // 获取叶子节点个数 
        public int GetLeafNodeNumber_2(Node node)
        {
            if (node == null)
                return 0;
            else if (node.firstChild == null)
                return 1 + GetLeafNodeNumber_2(node.firstChild);
            else
                return GetLeafNodeNumber_2(node.firstChild) + GetLeafNodeNumber_2(node.nextSibling);
        }

        // 获取N叉树的叶子节点个数
        public int GetLeafNodeNumber_N(Node node)
        {
            if (node == null) return 0;
            else if (node.firstChild == null)
                return 1;
            else
            {
                int count = 0;
                Node child = node.firstChild;
                while (child != null)
                {
                    count += GetLeafNodeNumber_N(child);
                    child = child.nextSibling;
                }
                return count;
            }
        }
    }
}

/*
 1
/ \
 2   3
    / \
   4   5

*/