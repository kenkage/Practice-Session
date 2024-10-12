using System;
namespace test.Sets
{
	public class UniquePermutation
	{
        //static void Main(string[] args)
        //{
        //    string s = Console.ReadLine();

        //    UniquePermutations(s);
        //}

        // Function to generate unique permutations of a string
        static void UniquePermutations(string s)
        {
            var permutationsSet = new SortedSet<string>();

            GetPermutations(s.ToCharArray(), 0, s.Length - 1, permutationsSet);

            foreach (var perm in permutationsSet)
            {
                Console.WriteLine(perm);
            }
        }

        static void GetPermutations(char[] arr, int left, int right, SortedSet<string> permutationsSet)
        {
            if (left == right)
            {
                // Convert char array to string and add to the set (automatically avoids duplicates)
                permutationsSet.Add(new string(arr));
            }
            else
            {
                var usedChars = new HashSet<char>(); // To avoid swapping the same character multiple times
                for (int i = left; i <= right; i++)
                {
                    if (!usedChars.Contains(arr[i])) // Avoid duplicate swaps
                    {
                        usedChars.Add(arr[i]);
                        Swap(ref arr[left], ref arr[i]); // Swap
                        GetPermutations(arr, left + 1, right, permutationsSet); // Recurse
                        Swap(ref arr[left], ref arr[i]); // Backtrack
                    }
                }
            }
        }

        static void Swap(ref char a, ref char b)
        {
            char temp = a;
            a = b;
            b = temp;
        }
    }
}

