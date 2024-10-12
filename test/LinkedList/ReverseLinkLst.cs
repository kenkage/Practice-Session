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

    public class ReverseLinkLst
	{
		//static void Main()
  //      {
  //          int n = int.Parse(Console.ReadLine());
  //          int[] array = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

  //          ListNode head = BuildList(array);

  //          ListNode reversedHead = ReverseList(head);

  //          PrintList(reversedHead);
  //      }

		static ListNode BuildList(int[] arr)
		{
			ListNode dummyHead = new ListNode();
			ListNode currentNode = dummyHead;

			foreach(int num in arr)
			{
				currentNode.next = new ListNode(num);
				currentNode = currentNode.next;
			}
			return dummyHead.next;	
		}

		static ListNode ReverseList(ListNode head)
		{
			ListNode prev = null, current = head;
			while(current != null)
			{
				ListNode next = current.next;
				current.next = prev;
				prev = current;
				current = next;
			}
			return prev;
		}

		static void PrintList(ListNode head)
		{
			ListNode curr = head;
			while(curr != null)
			{
				Console.Write(curr.val + " ");
				curr = curr.next;
			}
			Console.WriteLine();
		}
    }
}

