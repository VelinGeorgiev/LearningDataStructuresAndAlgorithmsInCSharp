using Learning.DataStructures;

namespace Learning.InterviewQuestions.Trees
{
    public class BinaryTreeLowestCommonAncestor : BinaryTree
    {
        // This function returns pointer to LCA of two given
        // values n1 and n2. This function assumes that n1 and
        // n2 are present in Binary Tree
        // Time Complexity: Time complexity of the above solution is O(n) as the method does a simple tree traversal in bottom up fashion.
        // http://www.geeksforgeeks.org/lowest-common-ancestor-binary-tree-set-1/
        // TODO: We can extend this method to handle all cases by passing two boolean variables v1 and v2. v1 is set as true when n1 is present in tree and v2 is set as true if n2 is present in tree.
        public Node FindLca(Node node, int n1, int n2)
        {
            if (node == null) return null;

            // If either n1 or n2 matches with root's key, report
            // the presence by returning root (Note that if a key is
            // ancestor of other, then the ancestor key becomes LCA
            if (node.data == n1 || node.data == n2) return node;

            // Look for keys in left and right subtrees
            Node leftLca = FindLca(node.left, n1, n2);
            Node rightLca = FindLca(node.right, n1, n2);

            // If both of the above calls return Non-NULL, then one key
            // is present in once subtree and other is present in other,
            // So this node is the LCA
            if (leftLca != null && rightLca != null) return node;

            // Otherwise check if left subtree or right subtree is LCA
            return (leftLca != null) ? leftLca : rightLca;
        }

        bool _v1, _v2;

        // This function returns pointer to LCA of two given
        // values n1 and n2.
        // v1 is set as true by this function if n1 is found
        // v2 is set as true by this function if n2 is found
        Node FindLcaUtil(Node node, int n1, int n2)
        {
            if (node == null) return null;

            // If either n1 or n2 matches with root's key, report the presence
            // by setting v1 or v2 as true and return root (Note that if a key
            // is ancestor of other, then the ancestor key becomes LCA)
            if (node.data == n1)
            {
                _v1 = true;
                return node;
            }
            if (node.data == n2)
            {
                _v2 = true;
                return node;
            }

            // Look for keys in left and right subtrees
            Node leftLca = FindLcaUtil(node.left, n1, n2);
            Node rightLca = FindLcaUtil(node.right, n1, n2);

            // If both of the above calls return Non-NULL, then one key
            // is present in once subtree and other is present in other,
            // So this node is the LCA
            if (leftLca != null && rightLca != null) return node;

            // Otherwise check if left subtree or right subtree is LCA
            return (leftLca != null) ? leftLca : rightLca;
        }

        // Finds lca of n1 and n2 under the subtree rooted with 'node'
        public Node FindLca(int n1, int n2)
        {
            // Initialize n1 and n2 as not visited
            _v1 = false;
            _v2 = false;

            // Find lca of n1 and n2 using the technique discussed above
            Node lca = FindLcaUtil(root, n1, n2);

            // Return LCA only if both n1 and n2 are present in tree
            if (_v1 && _v2) return lca;

            // Else return NULL
            return null;
        }

        // Finds lca of n1 and n2 under the subtree rooted with 'node'
        public Node FindLcainBst(Node node, int n1, int n2)
        {
            if (node == null) return null;

            // If both n1 and n2 are smaller than root, then LCA lies in left
            if (node.data > n1 && node.data > n2)
                return FindLcainBst(node.left, n1, n2);

            // If both n1 and n2 are greater than root, then LCA lies in right
            if (node.data < n1 && node.data < n2)
                return FindLcainBst(node.right, n1, n2);

            return node;
        }
    }
}
