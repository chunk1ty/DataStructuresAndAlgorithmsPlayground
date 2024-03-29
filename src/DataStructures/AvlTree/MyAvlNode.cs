﻿using System;

namespace AvlTree;

internal class MyAvlNode
{
    public MyAvlNode(int value)
    {
        Value = value;
        Height = 1;
        BalanceFactor = 0;
        Left = null;
        Right = null;
    }

    public int Value { get; set; }

    public int Height { get; private set; }

    public int BalanceFactor { get; private set; }

    public MyAvlNode Right { get; set; }

    public MyAvlNode Left { get; set; }

    public void Update()
    {
        int leftChildHeight = GetHeight(Left);
        int rightChildHeight = GetHeight(Right);
        
        Height = Math.Max(leftChildHeight, rightChildHeight) + 1;
        BalanceFactor = leftChildHeight - rightChildHeight;
    }    

    private int GetHeight(MyAvlNode node)
    {
        return node == null ? 0 : node.Height;
    }

    public override string ToString()
    {
        return $"[{Value}] H: {Height} BF: {BalanceFactor}";
    }
}