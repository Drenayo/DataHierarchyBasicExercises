using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHierarchyBasicExercises.DataStructure
{
    /// <summary>
    /// 邻接表 实现 无向图 & 有向图
    /// </summary>
    class AdjacencyListGraph<T>
    {
        public int vexNum, edgeNum;// 无向图一条边算两条，有向图的边等于所有顶点的出度之和，或者入度之和
        List<Vertex> vertexList;

        public AdjacencyListGraph()
        {
            vexNum = 0;
            edgeNum = 0;
            vertexList = new List<Vertex>();
        }

        // 顶点
        public class Vertex
        { 
            public T data;             // 数据区
            public EdgeNode firstEdge;   // 指向下一个边节点
            public Vertex(T value)     // 构造
            {
                data = value;
            }

            public override string ToString()
            {
                return data.ToString();
            }
        }

        // 节点 可以理解为存储的逻辑线段的连接
        public class EdgeNode
        {
            public int adjvex;        // 边的另一端在数组中的下标
            public EdgeNode next;         // 指向下一个节点
            public EdgeNode(int index)     // 构造
            {
                adjvex = index;
            }
        }

        // 根据数据查找指定项
        public Vertex Find(T data)
        {
            foreach (Vertex v in vertexList)
            {
                if (v.data.Equals(data))
                {
                    return v;
                }
            }
            return null;
        }
        
        // 判断顶点是否在数组中
        private bool Contains(Vertex v)
        {
            return Find(v.data) != null;
        }
        
        // 返回顶点在数组中的下标
        private int GetIndex(Vertex vertex)
        {
            for (int i = 0; i < vertexList.Count; i++)
            {
                if (vertexList[i].Equals(vertex))
                    return i;
            }
            return -1;
        }

        // 添加 顶点数据
        public void AddVertex(T data)
        {
            Vertex v = new Vertex(data);
            if (!Contains(v))
            {
                vertexList.Add(v);
                vexNum++;
            }
            else
                throw new Exception("不能添加重复节点，值相同的节点");
        }

        // 添加无向边
        public void AddEdge(Vertex Ver1, Vertex Ver2)
        {
            if (!Contains(Ver1) && !Contains(Ver2))
                throw new Exception("某顶点不存在");

            // 有向边添加函数添加的是单向边，无向边就添加两次即可，理论上来讲这里应该分成两个类来书写，分别实现邻接表无向图，邻接表有向图
            AddDirectEdge(Ver1, Ver2);
            AddDirectEdge(Ver2, Ver1);
        }

        // 添加有向边
        public void AddDirectEdge(Vertex fromVer, Vertex toVer)
        {
            if (!Contains(fromVer) && !Contains(toVer))
                throw new Exception("某顶点不存在");

            EdgeNode edgeNode = new EdgeNode(GetIndex(toVer));



            // 顶点已经有指向的情况
            if (fromVer.firstEdge != null)
            {
                EdgeNode next = fromVer.firstEdge;
                // 遍历到链表结尾
                while (next.next != null)
                {
                    // 考虑到边已经存在的情况
                    if (next.adjvex == GetIndex(toVer))
                        throw new Exception("边已经添加了，禁止重复添加");
                    next = next.next;
                }
                // 添加到链表结尾
                next.next = edgeNode;
                
            }
            // 顶点无指向的情况
            else
            {
                fromVer.firstEdge = edgeNode;
            }
            edgeNum++;
        }

        ///这里的EdgeNode链表实现太麻烦，可以直接使用list,其实这里的原理类似于树的子节点链表示法
        /* public Vertex DelVertex(T data)
         {
             Vertex del = Find(data);
             if (del != null)
             {
                 // 删除节点本身、删除和节点相关的所有边（别处指向自己的，自己指向别人的）
                 // 指向索引也要修改
                 if (del.firstEdge != null)
                 {
                     EdgeNode next = del.firstEdge;
                     while (next != null)
                     {
                         DelEdge(vertexList[next.adjvex], del);
                         next = next.next;
                     }
                 }
             }
             else
                 throw new Exception("找不到要删除的节点");
             vertexList.Remove(del);
             return del;
         }
         public void DelEdge(Vertex endVer, Vertex selfVer)
         {
             // (我指向别人的可以不用管，因为把我自己表头删掉了，后续就被垃圾回收了，只需要遍历别人指向我自己的就行，从我的链表处拿到别人，删完再删我自己)
             // 删除边之后，还要把 后续 边的链表 指向 向前移动

             if (endVer.firstEdge != null)
             {
                 EdgeNode prev = endVer.firstEdge;
                 EdgeNode next = endVer.firstEdge;
                 while (next != null)
                 {
                     // 是否是要删除的链表节点（边）
                     if (next.adjvex == GetIndex(selfVer))
                     {
                         prev.next = next.next;
                         return;
                     }
                     prev = next;
                     next = next.next;
                 }
             }
         }*/

        // 求一个节点的度
        public int GetVertexDegree(Vertex vertex)
        {


            return -1;
        }

        // 返回某个节点所有的边

        // 深度搜索遍历

        // 广度搜索遍历

        // 打印图
        public void Print()
        {
            foreach (Vertex v in vertexList)
            {
                Console.Write($"[{v.data}|{GetIndex(v)}] : ");

                // 顶点有指向
                if (v.firstEdge != null)
                {
                    EdgeNode next = v.firstEdge;
                    while (next != null)
                    {
                        Console.Write($"[{vertexList[next.adjvex]}|{next.adjvex}]->");
                        next = next.next;
                    }
                }
                Console.WriteLine("");
            }
        }
    }
}