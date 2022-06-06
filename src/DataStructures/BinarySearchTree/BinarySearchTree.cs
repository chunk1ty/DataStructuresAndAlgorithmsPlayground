using System.Collections.Generic;

namespace BinarySearchTree;

internal class BinarySearchTree
{
    private Node _root;

    public BinarySearchTree()
    {
        _root = null;
    }

    public Node Root => _root;

    /// <summary>
    /// Adds integer value to binary search tree
    /// </summary>
    /// <param name="value"></param>
    public void Insert(int value)
    {
        if (_root == null)
        {
            _root = new Node(value);
        }
        else
        {
            InsertNode(_root, value);
        }
    }

    // Recursive add algorithm
    private void InsertNode(Node node, int value)
    {
        // Case 1: Go to lef (value is less than the current node value)
        if (value < node.Value)
        {
            // if there is no left child make this the new leaf
            if (node.Left is null)
            {
                node.Left = new Node(value);
                return;
            }

            InsertNode(node.Left, value);
        }
        // Case 2: Value is equal to or greater than the current value
        else
        {
            // if there is no right child make this the new leaf
            if (node.Right is null)
            {
                node.Right = new Node(value);
                return;
            }

            InsertNode(node.Right, value);
        }
    }

    public List<int> TraverseInOrder()
    {
        List<int> items = new List<int>();
        InOrder(_root, items);
        return items;
    }

    private void InOrder(Node currentNode, List<int> items)
    {
        if (currentNode is not null)
        {
            InOrder(currentNode.Left, items);
            items.Add(currentNode.Value);
            InOrder(currentNode.Right, items);
        }
    }

    /// <summary>
    /// Determines if the specified value exists in the binary tree.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public bool Contains(int value)
    {
        var node = HasNode(_root, value);

        return node is null ? false : true;
    }

    private Node HasNode(Node currentNode, int value)
    {
        // we don't we a match :( (bottom of recursion)
        if (currentNode is null)
        {
            return null;
        }

        // we have a match! (bottom of recursion)
        if (currentNode.Value == value)
        {
            return currentNode;
        }

        // if value is less than current node value go to the left
        if (value < currentNode.Value)
        {
            return HasNode(currentNode.Left, value);
        }

        // if value is greater or equal to current node value go to the right
        return HasNode(currentNode.Right, value);
    }
}
