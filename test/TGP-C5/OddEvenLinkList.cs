/*

Odd Even Linked List
Given the head of a singly linked list, reorder the list such that all nodes at odd positions are grouped together followed by the nodes at even positions.
The first node is considered at position 1 (odd), the second node at position 2 (even), and so on. It is essential that the relative order within the odd and
even groups is maintained as per the original list.

Input Format:

The first line contains a single integer, n, representing the size of the linked list.
The second line consists of n space-separated integers representing the elements of the linked list.
Output Format:

The output should be the elements of the reordered linked list, with each node's value separated by a space, in the same order as they appear in the final reordered list.
Example:

Input:

5
1 2 3 4 5
Output:

1 3 5 2 4
Constraints:

The number of nodes in the linked list is in the range 0 < n < 10000.
Node values are within the range -10^6 <= Node.val <= 10^6.`
The solution must achieve O(n)time complexity andO(1)extra space complexity, wheren is the size of the linked list.

Explanation:
In the given linked list, the nodes at odd positions are [1, 3, 5], and the nodes at even positions are [2, 4].R
eordering these nodes so that all odd nodes come before even nodes, while maintaining their relative order, gives us [1, 3, 5, 2, 4] as the result.

 */


using System;
namespace test.TGPC5
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

    public class OddEvenLinkList
	{
        public ListNode OddEvenList(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }

            ListNode odd = head;
            ListNode even = head.next;
            ListNode evenHead = even;

            while (even != null && even.next != null)
            {
                odd.next = even.next;
                odd = odd.next;
                even.next = odd.next;
                even = even.next;
            }

            odd.next = evenHead;
            return head;
        }

        //public static void Main(string[] args)
        //{
        //    // Read input size
        //    int n = int.Parse(Console.ReadLine());
        //    if (n == 0)
        //    {
        //        return;
        //    }

        //    // Read linked list elements
        //    string[] elements = Console.ReadLine().Split();
        //    ListNode head = new ListNode(int.Parse(elements[0]));
        //    ListNode current = head;

        //    for (int i = 1; i < n; i++)
        //    {
        //        current.next = new ListNode(int.Parse(elements[i]));
        //        current = current.next;
        //    }

        //    // Process the list
        //    OddEvenLinkList solution = new OddEvenLinkList();
        //    ListNode result = solution.OddEvenList(head);

        //    // Print result
        //    while (result != null)
        //    {
        //        Console.Write(result.val + " ");
        //        result = result.next;
        //    }
        //}
    }
}

