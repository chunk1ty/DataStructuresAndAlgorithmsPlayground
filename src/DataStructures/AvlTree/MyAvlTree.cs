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

    private MyAvlNode InsertNode(MyAvlNode node, int value)
    {
        // bottom of recursion
        if (node is null)
        {
            return new MyAvlNode(value);
        }

        // Case 1: Go to the left (value is less than the current node value)
        if (value < node.Value)
        {
            node.Left = InsertNode(node.Left, value);
        }
        // Case 2: Go to the right (value is equal to or greater than the current value)
        else
        {
            node.Right = InsertNode(node.Right, value);
        }

        node.Update();

        if (node.BalanceFactor == 2 && node.Left.BalanceFactor == 1)
        {            
            node = RightRotation(node);
        }
        else if (node.BalanceFactor == 2 && node.Left.BalanceFactor == -1)
        {
            node = LeftRightRotation(node);
        }
        else if (node.BalanceFactor == -2 && node.Right.BalanceFactor == 1)
        {
            node = RightLeftRotation(node);
        }
        else if (node.BalanceFactor == -2 && node.Right.BalanceFactor == -1)
        {
            node = LeftRotation(node);
        }

        return node;
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
    private MyAvlNode RightRotation(MyAvlNode parent)
    {
        var pivot = parent.Left;
        parent.Left = pivot.Right;
        pivot.Right = parent;

        parent.Update();
        pivot.Update();
        return pivot;
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
    private MyAvlNode LeftRightRotation(MyAvlNode parent)
    {        
        parent.Left = LeftRotation(parent.Left);
        return RightRotation(parent);
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
    private MyAvlNode LeftRotation(MyAvlNode parent)
    {
        var pivot = parent.Right;
        parent.Right = pivot.Left;
        pivot.Left = parent;

        parent.Update();
        pivot.Update();
        return pivot;
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
    private MyAvlNode RightLeftRotation(MyAvlNode parent)
    {
        parent.Right = RightRotation(parent.Right);
        return LeftRotation(parent);
    }
}
