using System.Collections.Generic;

namespace Learning.DataStructures
{
    /// <summary>
    /// Adapted from source: http://www.introprogramming.info/english-intro-csharp-book/
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Graph<T>
    {
        internal const int MaxNode = 1024;
        private readonly int[][] _childNodes;

        public Graph(int[][] childNodes)
        {
            _childNodes = childNodes;
        }

        public void BreadthFirstSearchTraversal(int node, IList<int> result)
        {
            bool[] visited = new bool[MaxNode];
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(node);
            visited[node] = true;
            while (queue.Count > 0)
            {
                int currentNode = queue.Dequeue();
                result.Add(currentNode);

                foreach (int childNode in _childNodes[currentNode])
                {
                    if (!visited[childNode])
                    {
                        queue.Enqueue(childNode);
                        visited[childNode] = true;
                    }
                }
            }
        }

        public void DepthFirstSearchTraversalWithStack(int node, IList<int> result)
        {
            bool[] visited = new bool[MaxNode];
            Stack<int> stack = new Stack<int>();
            stack.Push(node);
            visited[node] = true;
            while (stack.Count > 0)
            {
                int currentNode = stack.Pop();
                result.Add(currentNode);

                foreach (int childNode in _childNodes[currentNode])
                {
                    if (!visited[childNode])
                    {
                        stack.Push(childNode);
                        visited[childNode] = true;
                    }
                }
            }
        }

        public void DepthFirstSearchTraversal(int node, bool[] visited, IList<int> result)
        {
            if (!visited[node])
            {
                visited[node] = true;
                result.Add(node);

                foreach (int childNode in _childNodes[node])
                {
                    DepthFirstSearchTraversal(childNode, visited, result);
                }
            }
        }
    }
}
