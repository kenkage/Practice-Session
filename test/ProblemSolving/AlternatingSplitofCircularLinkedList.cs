using System;

/* https://www.youtube.com/watch?v=4vzXy8jVK38
    Take reference from this link.
    However, the solution in this link is not making the final list as cyclic linked list.
 */
class Node
{
    public int Data;
    public Node Next;
    public Node(int data)
    {
        Data = data;
        Next = null;
    }
}

class CircularLinkedList
{
    public Node Head;

    public void Append(int data)
    {
        Node newNode = new Node(data);
        if (Head == null)
        {
            Head = newNode;
            Head.Next = Head;
            return;
        }

        Node temp = Head;
        while (temp.Next != Head)
            temp = temp.Next;

        temp.Next = newNode;
        newNode.Next = Head;
    }

    public (Node, Node) AlternatingSplit()
    {
        if (Head == null || Head.Next == Head)
            return (Head, null);

        Node first = Head;
        Node second = Head.Next;
        Node firstTail = first, secondTail = second;
        Node current = second.Next;
        bool isFirst = true;

        while (current != Head)
        {
            if (isFirst)
            {
                firstTail.Next = current;
                firstTail = current;
            }
            else
            {
                secondTail.Next = current;
                secondTail = current;
            }
            isFirst = !isFirst;
            current = current.Next;
        }
        // For making first and second linked list circular.
        firstTail.Next = first;
        if (second != null) secondTail.Next = second;

        return (first, second);
    }

    public static void PrintList(Node head)
    {
        if (head == null) return;

        Node temp = head;
        while (true)
        {
            Console.Write(temp.Data + " ");
            temp = temp.Next;
            if (temp == head) break;
        }
        Console.WriteLine();
    }

    //static void Main()
    //{
    //    int n = int.Parse(Console.ReadLine());
    //    int[] values = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

    //    CircularLinkedList list = new CircularLinkedList();
    //    foreach (int value in values)
    //        list.Append(value);

    //    (Node first, Node second) = list.AlternatingSplit();
    //    PrintList(first);
    //    PrintList(second);
    //}
}
