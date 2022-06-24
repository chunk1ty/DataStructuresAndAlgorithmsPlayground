using Stack;
using System;
using System.Collections;

namespace AvlTree;

internal class MyAvlTree : IEnumerable
{
    private MyAvlNode _root;

    public MyAvlTree()
    {
        _root = null;
    }

    public MyAvlNode Root => _root;

    /// <summary>
    /// Adds integer value to Avl tree
    /// </summary>
    /// <param name="value"></param>
    public void Insert(int value)
    {
        if (_root == null)
        {
            _root = new MyAvlNode(value);

        }
        else
        {
            _root = InsertNode(_root, value);
        }
    }

    private MyAvlNode InsertNode(MyAvlNode subTreeRoot, int newNodeValue)
    {
        // bottom of recursion
        if (subTreeRoot is null)
        {
            return new MyAvlNode(newNodeValue);
        }

        // Case 1: Go to the left (value is less than the current node value)
        if (newNodeValue < subTreeRoot.Value)
        {
            subTreeRoot.Left = InsertNode(subTreeRoot.Left, newNodeValue);
        }
        // Case 2: Go to the right (value is equal to or greater than the current value)
        else
        {
            subTreeRoot.Right = InsertNode(subTreeRoot.Right, newNodeValue);
        }

        subTreeRoot.Update();

        return Rebalance(subTreeRoot);
    }

    private MyAvlNode Rebalance(MyAvlNode subTreeRoot)
    {
        // left heavy 
        if (subTreeRoot.BalanceFactor == -2)
        {
            if (subTreeRoot.Right.BalanceFactor == -1 || subTreeRoot.Right.BalanceFactor == 0)
            {
                return RightRotation(subTreeRoot);
            }
            else if (subTreeRoot.Right.BalanceFactor == 1)
            {
                return RightLeftRotation(subTreeRoot);
            }
            else
            {
                throw new ArgumentException($"Incorrect balance factor: [{subTreeRoot.BalanceFactor}]");
            }
        }
        // right heavy
        else if (subTreeRoot.BalanceFactor == 2)
        {
            if (subTreeRoot.Left.BalanceFactor == -1)
            {
                return LeftRightRotation(subTreeRoot);
            }
            else if (subTreeRoot.Left.BalanceFactor == 0 || subTreeRoot.Left.BalanceFactor == 1)
            {
                return LeftRotation(subTreeRoot);
            }
            else
            {
                throw new ArgumentException($"Incorrect balance factor: [{subTreeRoot.BalanceFactor}]");
            }
        }

        return subTreeRoot;
    }

    //     c (this)
    //    /
    //   b
    //  /
    // a
    //
    // becomes
    //       b
    //      / \
    //     a   c
    private MyAvlNode LeftRotation(MyAvlNode oldSubtreeRoot)
    {
        // 1. Left child becomes the new root
        var newSubTreeRoot = oldSubtreeRoot.Left;

        // 2. Right child of the new root is assigned to left child of the old root
        oldSubtreeRoot.Left = newSubTreeRoot.Right;

        // 3. Previous root becomes the new root’s right child
        newSubTreeRoot.Right = oldSubtreeRoot;

        oldSubtreeRoot.Update();
        newSubTreeRoot.Update();
        return newSubTreeRoot;
    }

    //     c (this)
    //    /
    //   b
    //    \
    //     a
    //
    // becomes
    //       b
    //      / \
    //     a   c
    private MyAvlNode LeftRightRotation(MyAvlNode subtreeRoot)
    {
        // 1. Left rotate the left child 
        subtreeRoot.Left = RightRotation(subtreeRoot.Left);

        // 2. Right rotate the root
        return LeftRotation(subtreeRoot);
    }

    //     a
    //      \
    //       b
    //        \
    //         c
    //
    // becomes
    //       b
    //      / \
    //     a   c
    private MyAvlNode RightRotation(MyAvlNode oldSubTreeRoot)
    {
        // 1. Right child becomes the new root
        var newSubTreeRoot = oldSubTreeRoot.Right;

        // 2. Left child of the new root is assigned to right child of the old root 
        oldSubTreeRoot.Right = newSubTreeRoot.Left;

        // 3. Previous root becomes the new root’s left child
        newSubTreeRoot.Left = oldSubTreeRoot;

        oldSubTreeRoot.Update();
        newSubTreeRoot.Update();

        return newSubTreeRoot;
    }

    //     a
    //      \
    //       b
    //      /  
    //     c   
    //
    // becomes
    //       b
    //      / \
    //     a   c
    private MyAvlNode RightLeftRotation(MyAvlNode subtreeRoot)
    {
        // 1. Right rotate the right child
        subtreeRoot.Right = LeftRotation(subtreeRoot.Right);

        // 2. Left rotate the root
        return RightRotation(subtreeRoot);
    }

    public void Delete(int value)
    {
        _root = DeleteNode(_root, value);
    }

    private MyAvlNode DeleteNode(MyAvlNode subTreeRoot, int valueToBeDeleted)
    {
        // go to the left
        if (valueToBeDeleted < subTreeRoot.Value)
        {
            subTreeRoot.Left = DeleteNode(subTreeRoot.Left, valueToBeDeleted);
        }
        // go to the right
        else if (valueToBeDeleted > subTreeRoot.Value)
        {
            subTreeRoot.Right = DeleteNode(subTreeRoot.Right, valueToBeDeleted);
        }
        // we have a match! valueToBeDeleted = subTreeRoot.Value
        else
        {
            // Case 1: Node is leaf
            if (subTreeRoot.Left is null && subTreeRoot.Right is null)
            {
                subTreeRoot = null;
            }
            // Case 2: Node has 1 child - on the left
            else if (subTreeRoot.Left is not null && subTreeRoot.Right is null)
            {
                subTreeRoot = subTreeRoot.Left;
            }
            // Case 2: Node has 1 child - on the right
            else if (subTreeRoot.Left is null && subTreeRoot.Right is not null)
            {
                subTreeRoot = subTreeRoot.Right;
            }
            // Case 3: Node has 2 child
            else
            {
                // find new sub tree root
                var nodeWithLowestValue = FindNodeWithMinValue(subTreeRoot.Right);

                // replace node to be deleted value with lowest value from the right sub tree (in order to keep tree consistent)
                subTreeRoot.Value = nodeWithLowestValue.Value;

                subTreeRoot.Right = DeleteNode(subTreeRoot.Right, nodeWithLowestValue.Value);
            }
        }

        if (subTreeRoot is null)
        {
            return null;
        }

        subTreeRoot.Update();

        return Rebalance(subTreeRoot);
    }

    private MyAvlNode FindNodeWithMinValue(MyAvlNode node)
    {
        while (node.Left is not null)
        {
            node = node.Left;
        }

        return node;
    }

    public bool Contains(int value)
    {
        return Find(Root, value) != null;
    }

    private MyAvlNode Find(MyAvlNode subTreeRoot, int value)
    {
        if (subTreeRoot is null)
        {
            return null;
        }

        if (value == subTreeRoot.Value)
        {
            return subTreeRoot;
        }

        if (value < subTreeRoot.Value)
        {
            return Find(subTreeRoot.Left, value);
        }

        return Find(subTreeRoot.Right, value);
    }

    public IEnumerator GetEnumerator()
    {
        // store the nodes we've skipped in this stack
        MyStack<MyAvlNode> stack = new MyStack<MyAvlNode>();

        MyAvlNode current = Root;

        // we need to keep track of whether or not
        // we should be going to the left node or the right nodes next.
        bool goLeftNext = true;

        // start by pushing Root onto the stack
        stack.Push(current);

        while (stack.Count > 0)
        {
            if (goLeftNext)
            {
                // push everything but the left-most node to the stack
                // we'll yield the left-most after this block
                while (current.Left != null)
                {
                    stack.Push(current);
                    current = current.Left;
                }
            }

            // in-order is left->yield->right
            yield return current.Value;

            // if we can go right then do so
            if (current.Right != null)
            {
                current = current.Right;

                // once we've gone right once, we need to start
                // going left again.
                goLeftNext = true;
            }
            else
            {
                // if we can't go right then we need to pop off the parent node
                // so we can process it and then go to it's right node
                current = stack.Pop();
                goLeftNext = false;
            }
        }
    }
}
