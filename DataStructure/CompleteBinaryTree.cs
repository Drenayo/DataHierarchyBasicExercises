using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHierarchyBasicExercises.DataStructure
{
    /// <summary>
    /// 二叉树
    /// 顺序存储实现完全二叉树，同时实现前中后层序遍历，同时实现增删改查操作
    /// </summary>
    class CompleteBinaryTree<T>
    {
        private T[] arr;
        private int count;
        public int Count { get { return count; } }
        public bool IsEmpty { get { return count == 0; } }

        public CompleteBinaryTree(int capacity)
        {
            arr = new T[capacity];
            count = 0;
        }
        public CompleteBinaryTree() : this(10) { }

        // 遍历操作  因为使用数组存储的完全二叉树，又因为完全二叉树的严格特性
        // 所以可以直接通过下标计算出一个节点的父节点、左子节点、右子节点的下标

        // 前序遍历 根节点，左子树，右子树*************
        public void PreorderTraversal()
        {
            Console.Write("前序遍历：");
            PreorderTraversal(0);
            Console.Write("\n");
        }
        private void PreorderTraversal(int index)
        {
            // 越界检测
            if (index >= arr.Length) return;
            // 判空检测
            if (arr[index] == null)
                return;


            // 得到左子节点的编号
            int leftNumber = index * 2 + 1;
            // 得到右子节点的编号
            int rightNumber = index * 2 + 2;

            // 递归实现遍历
            Console.Write(arr[index] + " ");
            PreorderTraversal(leftNumber);
            PreorderTraversal(rightNumber);
        }

        // 中序遍历 左子树，根节点，右子树********************
        public void InorderTraversal()
        {
            Console.Write("中序遍历：");
            InorderTraversal(0);
            Console.Write("\n");
        }
        private void InorderTraversal(int index)
        {
            if (index >= arr.Length || arr[index] == null) return;

            // 得到左子节点的编号
            int leftNumber = index * 2 + 1;
            // 得到右子节点的编号
            int rightNumber = index * 2 + 2;

            // 递归实现遍历
            InorderTraversal(leftNumber);
            Console.Write(arr[index] + " ");
            InorderTraversal(rightNumber);
        }

        // 后序遍历 左子树，右子树，根节点********************
        public void PostorderTraversal()
        {
            Console.Write("后序遍历：");
            PostorderTraversal(0);
            Console.Write("\n");
        }
        private void PostorderTraversal(int index)
        {
            if (index >= arr.Length || arr[index] == null) return;

            // 得到左子节点的编号
            int leftNumber = index * 2 + 1;
            // 得到右子节点的编号
            int rightNumber = index * 2 + 2;

            // 递归实现遍历
            PostorderTraversal(leftNumber);
            PostorderTraversal(rightNumber);
            Console.Write(arr[index] + " ");
        }

        // 层序遍历 ********************************
        public void LevelOrderTraversal_()
        {
            // 线性输出-----------------
            Console.Write("层序遍历：");
            for (int i = 0; i < count; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }

        // 队列实现 层序遍历输出 *********************
        public void LevelOrderTraversal()
        {
            if (IsEmpty) return;

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(0);
            Console.WriteLine("层序遍历：");
            while (queue.Count > 0)
            {
                int levelSize = queue.Count;
                for (int i = 0; i < levelSize; i++)
                {
                    int index = queue.Dequeue();
                    Console.Write(arr[index] + " ");

                    // 如果下标越界，则跳出当前循环剩余语句  目前是防止index走到最后一个下标会越界
                    if (index * 2 + 2 > count)
                        continue;

                    if (arr[index * 2 + 1] != null)
                        queue.Enqueue(index * 2 + 1);
                    if (arr[index * 2 + 2] != null)
                        queue.Enqueue(index * 2 + 2);
                }
                Console.WriteLine();
            }
        }


        // 转为数组
        //public T[] ToArray()
        //{
        //    T[] newArr = new T[Count];
        //    for (int i = 0; i < count; i++)
        //    {
        //        newArr[i] = arr[i];
        //    }
        //    return newArr;
        //}

        // 添加操作
        public void Add(T item)
        {
            if (count >= arr.Length)
                throw new IndexOutOfRangeException("数组已满!");

            arr[count] = item;
            count++;
        }


        // 把堆顶元素交换到后面，再次维护堆结构，循环直到排序完成
        // 堆排序*******************
        public void HeapSort(int[] arr, int n)
        {
            // 建堆
            BuildMaxHeap(arr, n);

            // 排序
            // 从堆末尾开始
            for (int i = n - 1; i > 0; i--)
            {
                int temp = arr[i];
                arr[i] = arr[0];
                arr[0] = temp;
                Heapify(arr, i, 0);
            }
        }


        // 构建大顶堆
        private void BuildMaxHeap(int[] arr, int n)
        {
            // 从底部开始，下标小于等于0结束
            for (int i = n / 2 - 1; i >= 0; i--)
            {
                Heapify(arr, n, i);
            }
        }

        /// <summary>
        /// 维护堆的性质
        /// </summary>
        /// <param name="arr">数组</param>
        /// <param name="n">数组长度</param>
        /// <param name="index">待维护节点的下标</param>
        private void Heapify(int[] arr, int n, int index)
        {
            int largest = index;//初始化最大值为当前节点
            int left = index * 2 + 1;
            int right = index * 2 + 2;

            // 找出最大值
            // 范围判定 && 将左子节点与当前节点比较，大则交换
            if (left < n && arr[left] > arr[largest])
                largest = left;
            // 将右子节点与当前节点比较，大则交换
            if (right < n && arr[right] > arr[largest])
                largest = right;

            // 如果下标发生了交换，则对应值也交换，意味着堆中最大值已经被交换到了父节点
            if (largest != index)
            {
                int temp = arr[largest];
                arr[largest] = arr[index];
                arr[index] = temp;

                // 是否还有后续节点，递归继续查左右子节点是否有子子节点大于的情况
                Heapify(arr, n, largest);
            }
        }
    }


}
