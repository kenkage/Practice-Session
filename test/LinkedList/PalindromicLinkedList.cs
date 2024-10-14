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

    public class PalindromicLinkedList
	{
        //static void Main()
        //{
        //    int n = int.Parse(Console.ReadLine());
        //    int[] array = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

        //    ListNode head = BuildList(array);

        //    //ListNode reversedHead = ReverseList(head);

        //    bool isPalindrome = IsPalindrome(head);
        //    Console.WriteLine(isPalindrome.ToString().ToLower());
        //}

        static ListNode BuildList(int[] arr)
        {
            ListNode dummyhead = new ListNode();
            ListNode current = dummyhead;

            foreach(int num in arr)
            {
                current.next = new ListNode(num);
                current = current.next;
            }

            return dummyhead.next;
        }

        static ListNode ReverseList(ListNode head)
        {
            ListNode current = head, prev = null;

            while(current != null)
            {
                ListNode temp = current.next;
                current.next = prev;
                prev = current;
                current = temp;
            }
            return prev;
        }

        public static bool IsPalindrome(ListNode head)
        {
            if (head == null || head.next == null)
                return true;

            // Step 1: Find the middle of the linked list
            ListNode slow = head, fast = head;
            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }

            // Step 2: Reverse the second half of the list
            ListNode secondHalf = ReverseList(slow);

            // Step 3: Compare the first and second half
            ListNode firstHalf = head;
            while (secondHalf != null)
            {
                if (firstHalf.val != secondHalf.val)
                    return false;
                firstHalf = firstHalf.next;
                secondHalf = secondHalf.next;
            }

            return true;
        }
    }
}

