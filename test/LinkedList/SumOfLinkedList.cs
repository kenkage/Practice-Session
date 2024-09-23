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

    public class SumOfLinkedList
	{
        //public static void Main()
        //{
        //    // Read input for the number of nodes in both lists
        //    string[] lengths = Console.ReadLine().Split(' ');
        //    int l1 = int.Parse(lengths[0]);
        //    int l2 = int.Parse(lengths[1]);

        //    // Read digits for the first list
        //    int[] digits1 = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

        //    // Read digits for the second list
        //    int[] digits2 = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

        //    // Build linked lists from the input digits
        //    ListNode list1 = BuildList(digits1);
        //    ListNode list2 = BuildList(digits2);

        //    ListNode result = AddTwoNumbers(list1, list2);

        //    // Print the result linked list
        //    PrintList(result);
        //}

        public static ListNode Reverse(ListNode head)
        {
            ListNode prev = null, curr = head;
            while (curr != null)
            {
                ListNode nextTemp = curr.next;
                curr.next = prev;
                prev = curr;
                curr = nextTemp;
            }
            return prev;
        }

        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            // Reverse both lists to add them easily from least significant digit
            l1 = Reverse(l1);
            l2 = Reverse(l2);

            ListNode dummyHead = new ListNode();
            ListNode current = dummyHead;
            int carry = 0;

            // Add the numbers while either list has digits remaining or there's a carry
            while (l1 != null || l2 != null || carry > 0)
            {
                int sum = carry;
                if (l1 != null)
                {
                    sum += l1.val;
                    l1 = l1.next;
                }
                if (l2 != null)
                {
                    sum += l2.val;
                    l2 = l2.next;
                }

                carry = sum / 10;
                current.next = new ListNode(sum % 10);
                current = current.next;
            }

            // Reverse the result list back to original order
            return Reverse(dummyHead.next);
        }

        public static ListNode BuildList(int[] numbers)
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

        public static void PrintList(ListNode head)
        {
            while (head != null)
            {
                Console.Write(head.val);
                //if (head.next != null) Console.Write(" -> ");
                head = head.next;
            }
            Console.WriteLine();
        }
    }
}