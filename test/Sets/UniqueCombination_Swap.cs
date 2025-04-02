using System;
using System.Collections.Generic;
using System.Linq;
// https://www.youtube.com/watch?v=GuTPwotSdYw
class UniquePermutations_Swap
{
    // Function to generate and return unique permutations of a string
    static void UniquePermutations(string s)
    {
        var permutationsSet = new HashSet<string>();

        GetPermutations(s.ToCharArray(), 0, s.Length - 1, permutationsSet);

        // Convert the HashSet to a list and sort it lexicographically
        var sortedPermutations = permutationsSet.ToList();

        var updaetd = sortedPermutations.ToArray<string>().Order();

        foreach (var perm in updaetd)
        {
            Console.Write($"{perm} ");
        }
        Console.WriteLine(permutationsSet.Count());
    }

    static void GetPermutations(char[] arr, int left, int right, HashSet<string> permutationsSet)
    {
        if (left == right)
        {
            permutationsSet.Add(new string(arr));
        }
        else
        {
            for (int i = left; i <= right; i++)
            {
                Swap(ref arr[left], ref arr[i]); // Swap
                GetPermutations(arr, left + 1, right, permutationsSet); // Recurse
                Swap(ref arr[left], ref arr[i]); // Backtrack
            }
        }
    }

    static void Swap(ref char a, ref char b)
    {
        char temp = a;
        a = b;
        b = temp;
    }

    //static void Main(string[] args)
    //{
    //    string s = Console.ReadLine();

    //    UniquePermutations(s);
    //}
}