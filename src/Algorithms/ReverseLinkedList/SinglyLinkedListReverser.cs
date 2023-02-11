namespace ReverseLinkedList;

public class SinglyLinkedListReverser
{
    /// <summary>
    /// Reverse the list.
    /// </summary>
    /// <param name="head"></param>
    /// <returns></returns>
    public Node Reverse(Node head)
    {
        Node next = null;
        Node prev = null;

        // 1 -> 2 -> 3 -> null
        // ^
        // |
        // head
        while (head != null)
        {
            // next -> 2
            next = head.Next;
            // null <- 1  
            head.Next = prev;
            // prev -> 1
            prev = head;
            // head -> 2
            head = next;
            
            // 1 iteration                    2 iteration                        3 iteration
            // null <- 1 -> 2 -> 3 -> null    null <- 1 <- 2 -> 3 -> null        null <- 1 <- 2 <- 3 -> null                                  
            //         ^    ^                              ^    ^                                  ^    ^                     
            //         |    |                              |    |                                  |    |                     
            //       prev  head & next                   prev  head & next                       prev  head & next                              
        }

        return prev;
    }
}

public class Node
{
    public Node(int value = 0, Node next = null)
    {
        Value = value;
        Next = next;
    }
    
    public int Value { get; }
    
    public Node Next { get; set; }

    public override string ToString()
    {
        return Value.ToString();
    }
}