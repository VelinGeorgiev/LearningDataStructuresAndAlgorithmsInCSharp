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
        // And returns Max path sum going through Root.
        int FindMaxUtil(Node node)
        {
            if (node == null) return 0;

            // l and r store Maximum path sum going through left and
            // Right child of Root respectively
            int l = FindMaxUtil(node.Left);
            int r = FindMaxUtil(node.Right);

            // Max path for parent call of Root. This path must
            // include at-most one child of Root
            int maxSingle = Math.Max(Math.Max(l, r) + node.Data, node.Data);

            // Max Top represents the sum when the Node under
            // consideration is the Root of the Maxsum path and no
            // ancestors of Root are there in Max sum path
            int maxTop = Math.Max(maxSingle, l + r + node.Data);

            // Store the Maximum Result.
            _result = Math.Max(_result, maxTop);

            return maxSingle;
        }

        // Returns Maximum path sum in tree with given Root
        public int FindMaxSum(Node node)
        {
            // Initialize result
            _result = node.Data;

            // Compute and return result
            FindMaxUtil(node);
            return _result;
        }
    }

}
