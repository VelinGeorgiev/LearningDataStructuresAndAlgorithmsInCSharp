using System;
using System.Collections.Generic;
using System.Text;
using Learning.DataStructures;

namespace Learning.InterviewQuestions.Trees
{
    public class BasicTreeQuestions : BinaryTree
    {
        int Sum(Node node)
        {
            if (node == null)
                return 0;
            return Sum(node.left) + node.data + Sum(node.right);
        }

        // Time Complexity: O(n^2) in worst case. Worst case occurs for a skewed tree.
        public bool IsSumTree(Node node)
        {
            int ls, rs;

            /* If node is NULL or it's a leaf node then
               return true */
            if (node == null || (node.left == null && node.right == null))
                return true;

            /* Get sum of nodes in left and right subtrees */
            ls = Sum(node.left);
            rs = Sum(node.right);

            /* if the node and both of its children satisfy the
               property return 1 else 0*/
            if ((node.data == ls + rs) && IsSumTree(node.left) && IsSumTree(node.right))
                return true;

            return false;
        }

        // Write a Program to Find the Maximum Depth or Height of a Tree
        // Time Complexity: O(n)
        /* Compute the "maxDepth" of a tree -- the number of 
       nodes along the longest path from the root node 
       down to the farthest leaf node.*/
        public int MaxDepth(Node node)
        {
            if (node == null) return 0;
            
            /* compute the depth of each subtree */
            int l = MaxDepth(node.left);
            int r = MaxDepth(node.right);

            /* use the larger one */
            if (l > r) return l + 1;
            return r + 1;
        }

        //Check if two trees are Mirror in Time Complexity : O(n)
        /* Given two trees, return true if they are
       mirror of each other */
        public bool AreMirror(Node a, Node b)
        {
            /* Base case : Both empty */
            if (a == null && b == null)
                return true;

            // If only one is empty
            if (a == null || b == null)
                return false;

            /* Both non-empty, compare them recursively
               Note that in recursive calls, we pass left
               of one tree and right of other tree */
            return a.data == b.data
                    && AreMirror(a.left, b.right)
                    && AreMirror(a.right, b.left);
        }


        // This function stores a tree in a string
        public void Serialize(Node node, StringBuilder sb)
        {
            // If current node is NULL, store marker
            if (node == null)
            {
                sb.Append("# ");
                return;
            }

            sb.Append(node.data + " ");
            // Else, store current node and recur for its children
            Serialize(node.left, sb);
            Serialize(node.right, sb);
        }

        // This function constructs a tree from a file pointed by 'fp'
        public Node Deserialize(string s)
        {
            if (string.IsNullOrEmpty(s)) return null;
            string[] nodesArray = s.Split(' ');

            return Deserialize(nodesArray);
        }

        private int _startAt = 0;
        private Node Deserialize(string[] nodesArray)
        {
            if (nodesArray.Length < _startAt + 1) return null;
            string data = nodesArray[_startAt];
            _startAt++;

            if (data == "#") return null;

            var node = new Node(int.Parse(data));

            node.left = Deserialize(nodesArray);
            node.right = Deserialize(nodesArray);

            return node;
        }

        //http://www.geeksforgeeks.org/difference-between-sums-of-odd-and-even-levels/
        public int GetLevelDiff(Node node)
        {
            // Base case
            if (node == null)
                return 0;

            // Difference for root is root's data - difference for 
            // left subtree - difference for right subtree
            return node.data - GetLevelDiff(node.left) - GetLevelDiff(node.right);
        }

        // Iterative method to do level order traversal line by line
        //http://quiz.geeksforgeeks.org/print-level-order-traversal-line-line/
        // Time complexity of this method is O(n) where n is number of nodes in given binary tree.
        public Dictionary<string, IList<int>> PrintLevelOrderDictionary = new Dictionary<string, IList<int>>();
        public void PrintLevelOrder(Node node)
        {
            if (node == null) return;

            // Create an empty queue for level order tarversal
            Queue<Node> q = new Queue<Node>();

            // Enqueue Root and initialize height
            q.Enqueue(node);

            // This is not needed if you would not use dict to store results, but only console
            int i = 1;
            string defLevel = "level";
            string level = defLevel + i;

            while (true)
            {
                // nodeCount (queue size) indicates number of nodes
                // at current lelvel.
                int nodeCount = q.Count;
                if (nodeCount == 0) break;
                IList<int> list = new List<int>();

                // Dequeue all nodes of current level and Enqueue all
                // nodes of next level
                while (nodeCount > 0)
                {
                    Node nextNode = q.Dequeue();
                    Console.Write(nextNode.data + " ");
                    list.Add(nextNode.data);

                    if (nextNode.left != null)
                        q.Enqueue(nextNode.left);
                    if (nextNode.right != null)
                        q.Enqueue(nextNode.right);
                    nodeCount--;
                }
                Console.WriteLine();
                PrintLevelOrderDictionary.Add(level, list);
                i++;
                level = defLevel + i;
            }
        }

        // Root to leaf path sum equal to a given number
        // http://www.geeksforgeeks.org/root-to-leaf-path-sum-equal-to-a-given-number/
        // Time Complexity: O(n)
        /*
    Given a tree and a sum, return true if there is a path from the root
    down to a leaf, such that adding up all the values along the path
    equals the given sum.

    Strategy: subtract the node value from the sum when recurring down,
    and check to see if the sum is 0 when you run out of tree.
    */
        public bool IsRootToLeafPathSumEqualToGivenNumber(Node node, int sum)
        {
            if (node == null) return sum == 0;
        
            bool result = false;

            /* otherwise check both subtrees */
            sum -= node.data;
            if (sum == 0 && node.left == null && node.right == null) return true;

            if (node.left != null)
                result = IsRootToLeafPathSumEqualToGivenNumber(node.left, sum);

            if (node.right != null)
                result = result || IsRootToLeafPathSumEqualToGivenNumber(node.right, sum);

            return result;
        }
    }
}
