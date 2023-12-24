using System.Collections.Generic;
using System.Linq;

namespace BinarySearchTree;

internal partial class MyBinarySearchTree
{
    /// <summary>
    /// Left => Root => Right
    /// </summary>
    /// <returns></returns>
    public List<int> DfsInOrderRecursive()
    {
        List<int> items = new List<int>();
        InOrder(_root, items);
        return items;
        
        void InOrder(TreeNode root, List<int> items)
        {
            if (root is null)
            {
                return;
            }
        
            InOrder(root.Left, items);
            items.Add(root.Value);
            InOrder(root.Right, items);
        }
    }
    
    /// <summary>
    /// Left => Root => Right
    /// </summary>
    /// <returns></returns>
    public List<int> DfsInOrderIterative()
    {
        var stack = new Stack<TreeNode>();
        var items = new List<int>();
        TreeNode node = _root;
        
        while (node != null || stack.Any()) {
            while (node != null) {
                stack.Push(node);
                node = node.Left;
            }
            node = stack.Pop();
            items.Add(node.Value);
            node = node.Right;
        }
        return items;
    }
    
    /// <summary>
    /// Root => Left => Right
    /// </summary>
    /// <returns></returns>
    public List<int> DfsPreOrderRecursive()
    {
        List<int> items = new List<int>();
        InOrder(_root, items);
        return items;
        
        void InOrder(TreeNode root, List<int> items)
        {
            if (root is null)
            {
                return;
            }
        
            items.Add(root.Value);
            InOrder(root.Left, items);
            InOrder(root.Right, items);
        }
    }
    
    /// <summary>
    /// Root => Left => Right
    /// </summary>
    /// <returns></returns>
    public List<int> DfsPreOrderIterative()
    {
        var stack = new Stack<TreeNode>();
        var items = new List<int>();
        
        stack.Push(_root);
        while (stack.Any())
        {
            TreeNode node = stack.Pop();
            items.Add(node.Value);
            if (node.Right is not null)
            {
                stack.Push(node.Right);
            }

            if (node.Left is not null)
            {
                stack.Push(node.Left);
            }
        }

        return items;
    }
    
    /// <summary>
    /// Left => Right => Root
    /// </summary>
    /// <returns></returns>
    public List<int> DfsPostOrderRecursive()
    {
        List<int> items = new List<int>();
        InOrder(_root, items);
        return items;
        
        void InOrder(TreeNode root, List<int> items)
        {
            if (root is null)
            {
                return;
            }
        
            InOrder(root.Left, items);
            InOrder(root.Right, items);
            items.Add(root.Value);
        }
    }
    
    /// <summary>
    /// Root => Left => Right
    /// </summary>
    /// <returns></returns>
    public List<int> DfsPostOrderIterative()
    {
        var stack = new Stack<TreeNode>();
        var items = new LinkedList<int>();
        
        stack.Push(_root);
        while (stack.Any())
        {
            TreeNode node = stack.Pop();
            items.AddFirst(node.Value);
            if (node.Left is not null)
            {
                stack.Push(node.Left);
            }
            
            if (node.Right is not null)
            {
                stack.Push(node.Right);
            }
        }
    
        return items.ToList();
    }
    
    public List<List<int>> Bfs()
    {
        if (_root is null)
        {
            return new List<List<int>>();
        }
        var queue = new Queue<TreeNode>();
        queue.Enqueue(_root);

        var levels = new List<List<int>>();
        while (queue.Any())
        {
            int levelLength = queue.Count;
            var levelItems = new List<int>();
            for (int i = 0; i < levelLength; i++)
            {
                var current = queue.Dequeue();
                levelItems.Add(current.Value);
                if (current.Left is not null)
                {
                    queue.Enqueue(current.Left);
                }
            
                if (current.Right is not null)
                {
                    queue.Enqueue(current.Right);
                }
            }
            levels.Add(levelItems);
        }

        return levels;
    }
}