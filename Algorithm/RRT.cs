using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHierarchyBasicExercises.Algorithm
{
    class Graph
    {
        private int[,] adjMatrix;
        private int numVertices; // 行列数

        public Graph(int numVertices)
        {
            this.numVertices = numVertices;
            adjMatrix = new int[numVertices, numVertices];
        }

        // 添加边
        public void AddEdge(int i, int j)
        {
            adjMatrix[i, j] = 1;
            adjMatrix[j, i] = 1;
        }

        /// <summary>
        /// RRT核心算法
        /// </summary>
        /// <param name="start">起点编号</param>
        /// <param name="goal">终点编号</param>
        /// <param name="maxIterations">最大迭代次数（算法最大运行次数）</param>
        /// <param name="stepSize">每次迭代时，新节点与邻近节点之间的距离</param>
        /// <returns></returns>
        public List<int> RRT(int start, int goal, int maxIterations, double stepSize)
        {
            List<int> path = new List<int>();
            Random random = new Random();

            int[] q = new int[numVertices];
            q[start] = 1;

            for (int i = 0; i < maxIterations; i++)
            {
                int randNode = random.Next(numVertices);

                if (q[randNode] == 1)
                {
                    continue;
                }

                int nearestNode = FindNearestNode(q, randNode);

                if (nearestNode == -1)
                {
                    continue;
                }

                double distance = CalculateDistance(nearestNode, randNode);

                if (distance < stepSize)
                {
                    q[randNode] = 1;
                }
                else
                {
                    int newX = (int)(nearestNode + stepSize * (randNode - nearestNode) / distance);
                    int newY = (int)(nearestNode + stepSize * (randNode - nearestNode) / distance);

                    if (IsEdge(newX, newY))
                    {
                        q[newX] = 1;
                        q[newY] = 1;
                    }
                }

                if (q[goal] == 1)
                {
                    path = FindPath(q, start, goal);
                    break;
                }
            }

            return path;
        }

        // 找到最近的节点
        private int FindNearestNode(int[] q, int randNode)
        {
            int nearestNode = -1;
            double minDistance = double.MaxValue;

            for (int i = 0; i < numVertices; i++)
            {
                if (q[i] == 1)
                {
                    double distance = CalculateDistance(i, randNode);

                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        nearestNode = i;
                    }
                }
            }

            return nearestNode;
        }

        // 计算两个点之前的距离
        private double CalculateDistance(int i, int j)
        {
            int x1 = i / numVertices;
            int y1 = i % numVertices;
            int x2 = j / numVertices;
            int y2 = j % numVertices;

            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }

        // 查看该路线是否被定义
        private bool IsEdge(int i, int j)
        {
            return adjMatrix[i, j] == 1;
        }

        // 找到路径
        private List<int> FindPath(int[] q, int start, int goal)
        {
            List<int> path = new List<int>();
            int current = goal;

            while (current != start)
            {
                path.Add(current);
                current = FindNearestNode(q, current);
            }

            path.Add(start);
            path.Reverse();

            return path;
        }
    }
}
