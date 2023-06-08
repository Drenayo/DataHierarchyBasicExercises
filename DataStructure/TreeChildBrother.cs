using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHierarchyBasicExercises.DataStructure
{
    /// <summary>
    /// 树的孩子兄弟表示法
    /// </summary>
    class TreeChildBrother<T>
    {
        public class Node
        {
            public T data;
            /// <summary>
            /// 第一个子节点
            /// </summary>
            public Node firstChild;
            /// <summary>
            /// 下一个兄弟节点
            /// </summary>
            public Node nextSibling;

            public Node(T data, Node firstChild, Node nextSibling)
            {
                this.data = data;
                this.firstChild = firstChild;
                this.nextSibling = nextSibling;
            }
            public Node(T data) : this(data, null, null) { }
            public Node(T data, Node firstChild) : this(data, firstChild, null) { }

            public override string ToString()
            {
                return $"[{data}]";
            }
        }
        private int count;
        private Node root;
        public int Count { get { return count; } }
        public bool IsEmpty { get { return count == 0; } }
        public Node Root { get { return root; } }
        // 构造
        public TreeChildBrother()
        {
            root = null;
            count = 0;
        }


        /// <summary>
        /// 添加方法，保持普通树结构，同时转为二叉树结构
        /// </summary>
        /// <param name="item"></param>
        public void Add(T item, Node parent)
        {
            Node newNode = new Node(item);
            // 若树空，则设根节点
            if (IsEmpty)
            {
                root = newNode;
                count++;
                return;
            }

            // 是否可以找到父节点
            if (!IsNodeExist(parent))
                return;

            // 如果父节点没有子节点，则作为第一个子节点插入
            if (parent.firstChild == null)
            {
                parent.firstChild = newNode;
                count++;
            }
            // 若有，则插入最后一个子节点的兄弟节点中
            else
            {
                Node siblingNode = parent.firstChild;

                // while向后遍历到最后一个子节点的兄弟节点
                while (siblingNode.nextSibling != null)
                    siblingNode = siblingNode.nextSibling;

                // 插入
                siblingNode.nextSibling = newNode;
                count++;
            }

        }

        /// <summary>
        /// 查找某个节点是否存在
        /// </summary>
        public bool IsNodeExist(Node node)
        {
            if (IsEmpty || node == null) return false;
            if (root.Equals(node)) return true;

            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                Node current = queue.Dequeue();

                if (current.firstChild != null && current.firstChild.Equals(node))
                    return true;
                else if (current.nextSibling != null && current.nextSibling.Equals(node))
                    return true;
                else if (current.firstChild != null)
                    queue.Enqueue(current.firstChild);
                else if (current.nextSibling != null)
                    queue.Enqueue(current.nextSibling);
            }

            return false;
        }


        ///// <summary>
        ///// 查找一个Node并返回
        ///// </summary>
        ///// <param name="item"></param>
        ///// <returns></returns>
        //public Node FindNode(Node item)
        //{
        //    return FindNode_(root, item);
        //}
        //private Node FindNode_(Node root,Node item)
        //{
        //    if (IsEmpty || root == null) return null;

        //    if (root.Equals(item)) return root;

        //    if (root.firstChild != null)
        //        PreOrderTraversal(root.firstChild);
        //    if (root.nextSibling != null)
        //        PreOrderTraversal(root.nextSibling);

        //    return null;
        //}

        ///// <summary>
        /////  根据数据查找Node并返回
        ///// </summary>
        ///// <param name="data"></param>
        ///// <returns></returns>
        //public Node FindNodeByData(T data)
        //{
        //    Node n = FindNodeByData_(root, data);
        //    Console.WriteLine(n.data);
        //    return n;
        //}
        //public Node FindNodeByData_(Node root, T data)
        //{
        //    if (IsEmpty || root == null) return null;

        //    if (root.data.Equals(data))
        //    {
        //        Console.WriteLine(root);
        //        return root;
        //    }
                


        //    if (root.firstChild != null)
        //        FindNodeByData_(root.firstChild,data);
        //    if (root.nextSibling != null)
        //        FindNodeByData_(root.nextSibling,data);

        //    return null;
        //}

        /// <summary>
        /// 完全二叉树的添加方法，普通树使用这种方法，转化的二叉树会变成完全二叉树，无法恢复普通树结构
        /// </summary>
        public void Add_C(T item)
        {
            Node newNode = new Node(item);

            // 若根空则设为根节点
            if (IsEmpty)
                root = newNode;

            // 使用队列来遍历树 找到第一个空位置插入
            // 我们将根节点入队，然后在循环中，每次出队一个节点并检查它的左右子节点。
            // 若左空，则入左，右空插右，插入后结束后续执行代码
            // 否则，如果左右子节点都不为空，我们将它们都入队，以便在后续迭代中继续检查。
            else
            {
                Queue<Node> queue = new Queue<Node>();
                queue.Enqueue(root);
                while (queue.Count > 0)
                {
                    Node current = queue.Dequeue();

                    if (current.firstChild == null)
                    {
                        current.firstChild = newNode;
                        return;
                    }
                    else if (current.nextSibling == null)
                    {
                        current.nextSibling = newNode;
                        return;
                    }
                    else
                    {
                        queue.Enqueue(current.firstChild);
                        queue.Enqueue(current.nextSibling);
                    }
                }
            }
        }

        // 前序遍历
        public void PreOrderTraversal(Node root)
        {
            if (IsEmpty) return;

            Console.Write(root.data);
            if (root.firstChild != null)
                PreOrderTraversal(root.firstChild);
            if (root.nextSibling != null)
                PreOrderTraversal(root.nextSibling);
        }

        // 中序遍历
        public void InOrderTraversal(Node root)
        {
            if (IsEmpty) return;

            if (root.firstChild != null)
                InOrderTraversal(root.firstChild);

            Console.Write(root.data);

            if (root.nextSibling != null)
                InOrderTraversal(root.nextSibling);
        }
        // 后序遍历
        public void PostOrderTraversal(Node root)
        {
            if (IsEmpty) return;

            if (root.firstChild != null)
                PostOrderTraversal(root.firstChild);
            if (root.nextSibling != null)
                PostOrderTraversal(root.nextSibling);

            Console.Write(root.data);
        }

        // 层序遍历 

        // 排序操作

        // 创建二叉树，按照什么顺序，先序，中序，后序
        // TODO 层序遍历、删除、查找、堆排序、求深度、叶子节点数、

    }
}
