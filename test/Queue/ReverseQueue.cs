using System;
namespace test.Queue
{
	public class ReverseQueue
	{
        //static void Main()
        //{
        //    string[] input = Console.ReadLine().Split();
        //    int n = int.Parse(input[0]);
        //    int k = int.Parse(input[1]);

        //    int[] elements = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

        //    Queue<int> queue = new Queue<int>(elements);

        //    queue = ReverseKElements(queue, k);

        //    Console.WriteLine(string.Join(" ", queue));
        //}

        static Queue<int> ReverseKElements(Queue<int> queue, int k)
        {
            Stack<int> stack = new Stack<int>();

            // Dequeue the first 'k' elements from the queue and push them onto the stack
            for (int i = 0; i < k; i++)
            {
                stack.Push(queue.Dequeue());
            }

            // Enqueue the reversed elements back into the queue
            while (stack.Count > 0)
            {
                queue.Enqueue(stack.Pop());
            }

            // Move the remaining 'n-k' elements (those that were not reversed) to the back of the queue
            int remainingElements = queue.Count - k;
            for (int i = 0; i < remainingElements; i++)
            {
                queue.Enqueue(queue.Dequeue());
            }

            return queue;
        }
    }
}

