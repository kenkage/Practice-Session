using System;
namespace test.Queue
{
	public class QueueFunc
	{
        //static void Main()
        //{
        //          string[] input = Console.ReadLine().Split();
        //          int n = int.Parse(input[0]);
        //          int k = int.Parse(input[1]);

        //	int[] arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

        //          Queue<int> queue = new Queue<int>();
        //          for (int i=0; i<n; i++)
        //	{
        //		//arr[i] = int.Parse(Console.ReadLine());
        //		queue.Enqueue(arr[i]);
        //	}

        //	queue.Dequeue();
        //	// Remove and print first element of queue
        //	Console.Write($"{queue.First()} ");

        //	Console.WriteLine(queue.Contains(k) ? "Yes " : "No ");

        //	foreach(var ele in queue)
        //	{
        //		Console.Write($"{ele} ");
        //	}
        //      }

        static void Main()
        {
            string[] firstLine = Console.ReadLine().Split();
            int n = int.Parse(firstLine[0]);
            int k = int.Parse(firstLine[1]);

            int[] elements = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

            Queue<int> queue = new Queue<int>(elements);

            // Remove the first element from the queue
            queue.Dequeue();

            // Print the first element of the queue
            Console.WriteLine(queue.Peek());

            // Check if 'k' exists in the queue
            if (queue.Contains(k))
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }

            // Print the remaining queue elements
            Console.WriteLine(string.Join(" ", queue));
        }
    }
}

