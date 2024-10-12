using System;
namespace test.Queue
{
	public class ImplementQueues
	{
        //static void Main()
        //{
        //    int n = int.Parse(Console.ReadLine());

        //    int[] elements = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

        //    // Create a queue and enqueue the elements
        //    Queue<int> queue = ImplementQueue(n, elements);

        //    // Output the elements of the queue in the same order
        //    Console.WriteLine(string.Join(" ", queue));
        //}

        static Queue<int> ImplementQueue(int n, int[] elements)
        {
            // Initialize the queue
            Queue<int> queue = new Queue<int>();

            // Enqueue all the elements into the queue
            for (int i = 0; i < n; i++)
            {
                queue.Enqueue(elements[i]);
            }

            return queue;
        }
    }
}

