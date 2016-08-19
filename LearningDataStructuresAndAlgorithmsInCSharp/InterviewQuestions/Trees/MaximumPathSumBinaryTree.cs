using System;
using Learning.DataStructures;

namespace Learning.InterviewQuestions.Trees
{
    /// <summary>
    /// Source: http://www.geeksforgeeks.org/find-maximum-path-sum-in-a-binary-tree/
    /// See more: https://gist.github.com/daifu/5297440
    /// </summary>
    public class MaximumPathSumBinaryTree : BinaryTree
    {
        private int _result;

        // This function returns overall Maximum path sum in 'res'
        // And returns Max path sum going through root.
        int FindMaxUtil(Node node)
        {
            if (node == null) return 0;

            // l and r store Maximum path sum going through left and
            // right child of root respectively
            int l = FindMaxUtil(node.left);
            int r = FindMaxUtil(node.right);

            // Max path for parent call of root. This path must
            // include at-most one child of root
            int maxSingle = Math.Max(Math.Max(l, r) + node.data, node.data);

            // Max Top represents the sum when the Node under
            // consideration is the root of the Maxsum path and no
            // ancestors of root are there in Max sum path
            int maxTop = Math.Max(maxSingle, l + r + node.data);

            // Store the Maximum Result.
            _result = Math.Max(_result, maxTop);

            return maxSingle;
        }

        // Returns Maximum path sum in tree with given root
        public int FindMaxSum(Node node)
        {
            // Initialize result
            _result = node.data;

            // Compute and return result
            FindMaxUtil(node);
            return _result;
        }
    }

}
