using System;
namespace test.LinkedList
{
    //public class DoublyLinkedListNode
    //{
    //    public DoublyLinkedListNode next;
    //    public DoublyLinkedListNode prev;
    //    public int val;
    //    public DoublyLinkedListNode(int val = 0, DoublyLinkedListNode next = null, DoublyLinkedListNode prev = null)
    //    {
    //        this.val = val;
    //        this.next = next;
    //        this.prev = prev;
    //    }
    //}

    public class RotateNodes
	{
        //static void Main()
        //{
        //    int n = int.Parse(Console.ReadLine());
        //    int[] arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

        //    int k = int.Parse(Console.ReadLine());

        //    DoublyLinkedListNode head = CreateList(arr);
        //    DoublyLinkedListNode newHead = RotateByK(head, k);
        //    PrintList(newHead);
        //}

        private static DoublyLinkedListNode RotateByK(DoublyLinkedListNode head, int k)
        {
            if (head == null || head.next == null || k == 0)
                return head;

            // Step 1: Count the number of nodes in the list
            int length = 1;
            DoublyLinkedListNode tail = head;
            while (tail.next != null)
            {
                tail = tail.next;
                length++;
            }

            // Step 2: Calculate effective rotations (K % length)
            k = k % length;
            if (k == 0)
                return head;  // No need to rotate if k is 0

            // Step 3: Find the new tail after rotation
            int newTailPos = length - k;  // Position of new tail (length - k)
            DoublyLinkedListNode newTail = head;
            for (int i = 1; i < newTailPos; i++)
            {
                newTail = newTail.next;
            }

            // Step 4: Set the new head and adjust pointers
            DoublyLinkedListNode newHead = newTail.next;
            newTail.next = null;
            newHead.prev = null;
            tail.next = head;
            head.prev = tail;

            return newHead;
        }

        private static DoublyLinkedListNode CreateList(int[] arr)
        {
            //DoublyLinkedListNode head = null;
            //DoublyLinkedListNode current = null;

            //foreach (int val in arr)
            //{
            //    DoublyLinkedListNode newNode = new DoublyLinkedListNode(val);

            //    if (head == null)
            //    {
            //        head = newNode;
            //        current = head;
            //    }
            //    else
            //    {
            //        current.next = newNode;
            //        current.prev = current;
            //        current = newNode;
            //    }
            //}
            //return head;

            DoublyLinkedListNode head = new DoublyLinkedListNode();
            DoublyLinkedListNode current = head;

            foreach (int val in arr)
            {
                DoublyLinkedListNode newNode = new DoublyLinkedListNode(val);
                current.next = newNode;
                current.prev = current;
                current = newNode;
            }
            return head.next;
        }

        static void PrintList(DoublyLinkedListNode head)
        {
            DoublyLinkedListNode current = head;
            while (current != null)
            {
                Console.Write(current.val + " ");
                current = current.next;
            }
            Console.WriteLine();
        }
    }
}

