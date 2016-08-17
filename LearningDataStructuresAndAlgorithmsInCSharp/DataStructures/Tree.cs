using System;
using System.Collections.Generic;

namespace Learning.DataStructures
{
    /// <summary>
    /// Adapted from source: http://www.introprogramming.info/english-intro-csharp-book/
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class TreeNode<T>
    {
        private bool _hasParent;
        private readonly IList<TreeNode<T>> _children;

        public TreeNode(T value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));
            Value = value;
            _children = new List<TreeNode<T>>();
        }

        public T Value { get; set; }

        public int ChildrenCount => _children.Count;

        public void AddChild(TreeNode<T> child)
        {
            if (child == null)
                throw new ArgumentNullException(nameof(child));
            if (child._hasParent)
                throw new ArgumentException(nameof(_hasParent));

            child._hasParent = true;
            _children.Add(child);
        }

        public TreeNode<T> GetChild(int index)
        {
            return _children[index];
        }
    }

    public class Tree<T>
    {
        private readonly TreeNode<T> _root;
        public TreeNode<T> Root => _root;

        public Tree(T value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));
            _root = new TreeNode<T>(value);
        }

        public Tree(T value, params Tree<T>[] children) : this(value)
        {
            foreach (Tree<T> child in children)
            {
                _root.AddChild(child._root);
            }
        }

        public void BreadthFirstSearchTraversal(IList<T> result)
        {
            Queue<TreeNode<T>> queue = new Queue<TreeNode<T>>();
            queue.Enqueue(_root);
            while (queue.Count > 0)
            {
                TreeNode<T> currentNode = queue.Dequeue();
                result.Add(currentNode.Value);

                for (int i = 0; i < currentNode.ChildrenCount; i++)
                {
                    TreeNode<T> childNode = currentNode.GetChild(i);
                    queue.Enqueue(childNode);
                }
            }
        }

        public void DepthFirstSearchTraversal(TreeNode<T> root, IList<T> result)
        {
            if (_root == null) return;
            result.Add(root.Value);

            TreeNode<T> child = null;
            for (int i = 0; i < root.ChildrenCount; i++)
            {
                child = root.GetChild(i);
                DepthFirstSearchTraversal(child, result);
            }
        }

        public void DepthFirstSearchTraversalWithStack(IList<T> result)
        {
            Stack<TreeNode<T>> stack = new Stack<TreeNode<T>>();
            stack.Push(_root);
            while (stack.Count > 0)
            {
                TreeNode<T> currentNode = stack.Pop();
                result.Add(currentNode.Value);

                for (int i = 0; i < currentNode.ChildrenCount; i++)
                {
                    TreeNode<T> childNode = currentNode.GetChild(i);
                    stack.Push(childNode);
                }
            }
        }
    }
}
