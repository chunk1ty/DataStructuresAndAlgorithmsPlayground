namespace AvlTree;

internal class MyAvlTree
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

        // right heavy 
        if (subTreeRoot.BalanceFactor == 2 && subTreeRoot.Left.BalanceFactor == 1)
        {            
            subTreeRoot = RightRotation(subTreeRoot);
        }
        // right heavy 
        else if (subTreeRoot.BalanceFactor == 2 && subTreeRoot.Left.BalanceFactor == -1)
        {
            subTreeRoot = RightLeftRotation(subTreeRoot);
        }
        // left heavy
        else if (subTreeRoot.BalanceFactor == -2 && subTreeRoot.Right.BalanceFactor == 1)
        {
            subTreeRoot = LeftRightRotation(subTreeRoot);
        }
        // left heavy 
        else if (subTreeRoot.BalanceFactor == -2 && subTreeRoot.Right.BalanceFactor == -1)
        {
            subTreeRoot = LeftRotation(subTreeRoot);
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
    private MyAvlNode RightRotation(MyAvlNode oldSubtreeRoot)
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
    private MyAvlNode RightLeftRotation(MyAvlNode subtreeRoot)
    {
        // 1. Left rotate the left child 
        subtreeRoot.Left = LeftRotation(subtreeRoot.Left);

        // 2. Right rotate the root
        return RightRotation(subtreeRoot);
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
    private MyAvlNode LeftRotation(MyAvlNode oldSubTreeRoot)
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
    private MyAvlNode LeftRightRotation(MyAvlNode subtreeRoot)
    {
        // 1. Right rotate the right child
        subtreeRoot.Right = RightRotation(subtreeRoot.Right);

        // 2. Left rotate the root
        return LeftRotation(subtreeRoot);
    }

    public void Delete(int value)
    {
        _root = DeleteNode(_root, value);
    }

    private MyAvlNode DeleteNode(MyAvlNode nodeToBeDeleted, int value)
    {
        // go to the left
        if (value < nodeToBeDeleted.Value)
        {
            nodeToBeDeleted.Left = DeleteNode(nodeToBeDeleted.Left, value);
        }
        // go to the right
        else if(value > nodeToBeDeleted.Value)
        {
            nodeToBeDeleted.Right = DeleteNode(nodeToBeDeleted.Right, value);
        }
        // we have a match!
        else
        {
            // node is leaf
            if (nodeToBeDeleted.Left is null && nodeToBeDeleted.Right is null)
            {
                nodeToBeDeleted = null;
            }
            // node has 1 child - on the left
            else if(nodeToBeDeleted.Left is not null && nodeToBeDeleted.Right is null)
            {
                nodeToBeDeleted = nodeToBeDeleted.Left;
            }
            // node has 1 child - on the right
            else if (nodeToBeDeleted.Left is null && nodeToBeDeleted.Right is not null)
            {
                nodeToBeDeleted = nodeToBeDeleted.Right;
            }
            // node has 2 child
            else
            {
                // find new sub tree root
                var nodeWithLowestValue = FindNodeWithMinValue(nodeToBeDeleted.Right);
                     
                // replace node to be deleted value with lowest value from the right sub tree (in order to keep tree consistent)
                nodeToBeDeleted.Value = nodeWithLowestValue.Value;

                nodeToBeDeleted.Right = DeleteNode(nodeToBeDeleted.Right, nodeWithLowestValue.Value);
            }
        }

        return nodeToBeDeleted;
    }

    private MyAvlNode FindNodeWithMinValue(MyAvlNode node)
    {
        while(node.Left is not null)
        {
            node = node.Left;
        }

        return node;
    }
}
