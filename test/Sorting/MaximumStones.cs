using System;
namespace test.Sorting
{
	public class MaximumStones
	{
        static int MaxStonesForVivek(int[] piles)
        {
            Array.Sort(piles);
            int n = piles.Length;
            int vivekStones = 0;

            // Step 2: Vivek picks second largest from every group of 3
            for (int i = n / 3; i < n; i += 2)
            {
                vivekStones += piles[i]; // Vivek gets the second-largest in every triplet
            }

            return vivekStones;
        }

        //public static void MaxStones(int[] piles)
        //{
        //    Array.Sort(piles);  // Step 1: Sort the array in ascending order
        //    int n = piles.Length;
        //    int anishTotal = 0, vivekTotal = 0, binishTotal = 0;

        //    // Step 2: Assign stones in rounds of 3
        //    for (int i = 0; i < piles.Length; i += 3)
        //    {
        //        if (i < piles.Length) anishTotal += piles[i];       // Anish picks max
        //        if (i + 1 < piles.Length) vivekTotal += piles[i + 1]; // Vivek picks second max
        //        if (i + 2 < piles.Length) binishTotal += piles[i + 2]; // Binish picks third max
        //    }

        //    // Print results
        //    Console.WriteLine($"Anish: {anishTotal}");
        //    Console.WriteLine($"Vivek: {vivekTotal}");
        //    Console.WriteLine($"Binish: {binishTotal}");
        //}

        //public static void Main()
        //{
        //    int n = int.Parse(Console.ReadLine());
        //    int[] piles = Console.ReadLine().Split().Select(int.Parse).ToArray();

        //    Console.WriteLine(MaxStonesForVivek(piles));
        //    //MaxStones(piles);
        //}
    }
}
// 0  1  2  3  4  5
// 2  2  4  8  9  11


