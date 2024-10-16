using System;
namespace test.LinkedList
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public class MergeSortedList
	{
		//static void Main()
  //      {
  //          int n1 = int.Parse(Console.ReadLine());

  //          string[] input1 = Console.ReadLine().Split();
  //          int[] list1Values = Array.ConvertAll(input1, int.Parse);

  //          int n2 = int.Parse(Console.ReadLine());

  //          string[] input2 = Console.ReadLine().Split();
  //          int[] list2Values = Array.ConvertAll(input2, int.Parse);

  //          ListNode list1 = CreateList(list1Values);
  //          ListNode list2 = CreateList(list2Values);

  //          ListNode mergedList = MergeTwoLists(list1, list2);

  //          PrintList(mergedList);
  //      }

        public static void PrintList(ListNode head)
        {
            ListNode current = head;
            while (current != null)
            {
                Console.Write(current.val + " ");
                current = current.next;
            }
            Console.WriteLine();
        }

        public static ListNode CreateList(int[] values)
        {
            ListNode head = null;
            ListNode current = null;

            foreach (int val in values)
            {
                ListNode newNode = new ListNode(val);
                if (head == null)
                {
                    head = newNode;
                    current = head;
                }
                else
                {
                    current.next = newNode;
                    current = newNode;
                }
            }

            return head;
        }

        public static ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            // Create a dummy node to simplify the merging process
            ListNode dummy = new ListNode();
            ListNode current = dummy;

            // Traverse both lists and merge them in sorted order
            while (list1 != null && list2 != null)
            {
                if (list1.val <= list2.val)
                {
                    current.next = list1;
                    list1 = list1.next;
                }
                else
                {
                    current.next = list2;
                    list2 = list2.next;
                }
                current = current.next;
            }

            // If there are remaining elements in list1 or list2, attach them
            if (list1 != null)
            {
                current.next = list1;
            }
            else if (list2 != null)
            {
                current.next = list2;
            }

            // Return the merged list starting from dummy.next (skipping dummy node)
            return dummy.next;
        }
    }
}

