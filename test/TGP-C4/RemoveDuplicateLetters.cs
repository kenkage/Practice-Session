using System;
namespace test.TGPC4
{
	public class RemoveDuplicateLetters
	{
        static void Main()
        {
            Console.WriteLine("Enter a string"); 
            string s = Console.ReadLine();

            string result = RemoveDuplicate(s);
            Console.WriteLine($"{result}");
        }

        static string RemoveDuplicate(string str)
        {
            List<char> charList = new List<char>();

            foreach (char st in str)
            {
                if (!charList.Contains(st))
                {
                    charList.Add(st);
                }
            }

            charList.Sort();

            return new string(charList.ToArray());
        }

    }
}

