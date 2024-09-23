using System;
namespace test.LinkedList
{
    //public class ListNode
    //{
    //    public int val;
    //    public ListNode next;
    //    public ListNode(int val = 0, ListNode next = null)
    //    {
    //        this.val = val;
    //        this.next = next;
    //    }
    //}

    public class MiddleOfLinkedList
	{
        //static void Main()
        //{
        //    int n = int.Parse(Console.ReadLine());
        //    int[] array = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

        //    ListNode head = BuildList(array);

        //    ListNode middle = MiddleNode(head);

        //    Console.WriteLine(middle.val);
        //}

        static ListNode BuildList(int[] numbers)
        {
            ListNode dummyHead = new ListNode();
            ListNode current = dummyHead;

            foreach (int num in numbers)
            {
                current.next = new ListNode(num);
                current = current.next;
            }

            return dummyHead.next;
        }

        public static ListNode MiddleNode(ListNode head)
        {
            ListNode slow = head;
            ListNode fast = head;

            // Move slow one step and fast two steps until fast reaches the end
            while (fast != null && fast.next != null && fast.next.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }

            // Slow pointer will be at the middle
            return slow;
        }
    }
}

