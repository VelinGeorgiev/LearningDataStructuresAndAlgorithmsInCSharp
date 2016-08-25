namespace Learning.DataStructures
{
    /// <summary>
    /// Binary Search Tree.
    /// http://quiz.geeksforgeeks.org/binary-search-tree-set-1-search-and-insertion/
    /// </summary>
    public class BinarySearchTree: BinaryTree
    {
        public Node Search(Node node, int value)
        {
            // Base Cases: node is null or value is present at node
            if (node == null || node.data == value) return node;

            // Value is greater than node's value
            if (node.data > value) return Search(node.left, value);

            // Value is less than node's value
            return Search(node.right, value);
        }

        /* A recursive function to insert a new value in BST */
        public Node Insert(Node node, int value)
        {
            /* If the tree is empty, return a new node */
            if (node == null) return new Node(value);

            if (value < node.data)
                node.left = Insert(node.left, value);
            else if (value > node.data)
                node.right = Insert(node.right, value);

            return node;
        }

        // http://quiz.geeksforgeeks.org/binary-search-tree-set-2-delete/
        public Node Delete(Node node, int key)
        {
            if (node == null) return node;

            /* Otherwise, recur down the tree */
            if (key < node.data)
                node.left = Delete(node.left, key);
            else if (key > node.data)
                node.right = Delete(node.right, key);

            // If key is same as node's key, then This is the node  to be deleted
            else
            {
                // node with only one child or no child
                if (node.left == null) return node.right;
                if (node.right == null) return node.left;

                // node with two children: Get the inorder successor (smallest
                // in the right subtree)
                node.data = MinValue(node.right);

                // Delete the inorder successor
                node.right = Delete(node.right, node.data);
            }

            return node;
        }

        private int MinValue(Node node)
        {
            int minv = node.data;
            while (node.left != null)
            {
                minv = node.left.data;
                node = node.left;
            }
            return minv;
        }
    }
}
