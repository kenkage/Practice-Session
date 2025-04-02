using System;
using System.Runtime.InteropServices;

namespace test.Sets
{
	public class UniquePermutation
	{
        static List<string> finalRes = new List<string>(); // use Hashset to aviod duplicates.

        static void PrintPermutation(string ques, string asf)
        {
            if (ques.Length == 0)
            {
                Console.WriteLine(asf);
                finalRes.Add(asf);
                return;
            }

            for (int i = 0; i < ques.Length; i++)
            {
                char ch = ques[i];
                string lPart = ques.Substring(0, i); 
                string rPart = ques.Substring(i + 1);
                string roq = lPart + rPart;
                PrintPermutation(roq, asf + ch);     
            }
        }

        //static void Main()
        //{
        //    // Read input string
        //    string s = Console.ReadLine().Trim();
        //    PrintPermutation(s, "");
        //    Console.WriteLine(finalRes.Count());
        //}
    }
}