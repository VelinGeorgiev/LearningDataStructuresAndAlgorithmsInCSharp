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

    }
}
