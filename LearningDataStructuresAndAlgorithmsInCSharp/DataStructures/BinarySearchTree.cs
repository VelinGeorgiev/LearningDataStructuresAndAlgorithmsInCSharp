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
    }
}
