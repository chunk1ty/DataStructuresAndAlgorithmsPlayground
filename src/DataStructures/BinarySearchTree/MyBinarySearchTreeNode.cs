namespace BinarySearchTree;

internal class MyBinarySearchTreeNode
{
    public MyBinarySearchTreeNode(int value)
    {
        Left = null;
        Right = null;
        Value = value;
    }

    public MyBinarySearchTreeNode Left { get; set; }

    public MyBinarySearchTreeNode Right { get; set; }

    public int Value { get; set; }
}
