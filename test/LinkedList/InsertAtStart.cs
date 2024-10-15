using System;
namespace test.LinkedList
{
    public class DoublyLinkedListNode
    {
        public int val;
        public DoublyLinkedListNode prev;
        public DoublyLinkedListNode next;
        public DoublyLinkedListNode(int val = 0, DoublyLinkedListNode prev = null, DoublyLinkedListNode next = null)
        {
            this.val = val;
            this.prev = prev;
            this.next = next;
        }
    }

    public class InsertAtStart
	{
        //static void Main()
        //{
        //    string[] input = Console.ReadLine().Split();
        //    int[] values = Array.ConvertAll(input, int.Parse);

        //    int val = int.Parse(Console.ReadLine());

        //    DoublyLinkedListNode head = CreateList(values);

        //    // Perform the insertions
        //    head = AddVal(head, val);

        //    PrintList(head);
        //}

        public static DoublyLinkedListNode CreateList(int[] values)
        {
            DoublyLinkedListNode head = null;
            DoublyLinkedListNode current = null;

            foreach(int val in values)
            {
                if (val == -1)
                    break;

                DoublyLinkedListNode newNode = new DoublyLinkedListNode(val);

                if(head == null)
                {
                    head = newNode;
                    current = head;
                }
                else
                {
                    current.next = newNode;
                    current.prev = current;
                    current = newNode;
                }
            }
            return head;
        }

        static DoublyLinkedListNode AddVal(DoublyLinkedListNode head, int val)
        {
            // Insert at the beginning
            DoublyLinkedListNode newNode = new DoublyLinkedListNode(val);
            if (head != null)
            {
                newNode.next = head;
                head.prev = newNode;
            }
            head = newNode;

            // Find the middle node
            DoublyLinkedListNode slow = head;
            DoublyLinkedListNode fast = head;
            while (fast != null && fast.next != null && fast.next.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }

            // Insert at the middle (after the midpoint)
            DoublyLinkedListNode middleNode = new DoublyLinkedListNode(val);
            if (slow.next != null)
            {
                middleNode.next = slow.next;
                slow.next.prev = middleNode;
            }
            slow.next = middleNode;
            middleNode.prev = slow;

            // Insert at the end
            DoublyLinkedListNode current = head;
            while (current.next != null)
            {
                current = current.next;
            }
            DoublyLinkedListNode endNode = new DoublyLinkedListNode(val);
            current.next = endNode;
            endNode.prev = current;

            return head;
        }

        static void PrintList(DoublyLinkedListNode head)
        {
            DoublyLinkedListNode current = head;
            while(current != null)
            {
                Console.Write(current.val + " ");
                current = current.next;
            }
            Console.WriteLine();
        }
    }
}

