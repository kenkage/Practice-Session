using System;
namespace test.Queue
{
	public class FirstNonRepeating
	{
        static void Main()
        {
            string input = Console.ReadLine();
            string result = FirstNonRepeatingCharacter(input);
            Console.WriteLine(result);
        }

        static string FirstNonRepeatingCharacter(string str)
        {
            Queue<char> queue = new Queue<char>();
            Dictionary<char, int> frequencyMap = new Dictionary<char, int>();
            string outputStr = "";

            foreach (char ch in str)
            {
                // Add character to the queue and update its frequency
                if (!frequencyMap.ContainsKey(ch))
                    frequencyMap[ch] = 0;
                frequencyMap[ch]++;
                queue.Enqueue(ch);

                // Remove characters from the queue that have a frequency greater than 1
                while (queue.Count > 0 && frequencyMap[queue.Peek()] > 1)
                {
                    queue.Dequeue();
                }

                // Append the first non-repeating character or 'X' if none exist
                if (queue.Count > 0)
                    outputStr += queue.Peek();
                else
                    outputStr += 'X';
            }

            return outputStr;
        }
    }
}

