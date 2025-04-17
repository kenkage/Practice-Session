using System;
// ref: https://www.youtube.com/watch?v=Z0hwjftStI4
namespace test.BinaryTrees
{
	public class BookAllocationProblem
	{
        static bool IsPossible(int[] books, int m, int maxPages)
        {
            int studentCount = 1;
            int currentPages = 0;

            foreach (int pages in books)
            {
                if (pages > maxPages) return false;

                if (currentPages + pages > maxPages)
                {
                    studentCount++;
                    currentPages = pages;
                    if (studentCount > m)
                        return false;
                }
                else
                {
                    currentPages += pages;
                }
            }

            return true;
        }

        public static int FindMinimumPages(int[] books, int m)
        {
            int n = books.Length;
            if (m > n) return -1;

            int low = 0, high = 0;
            foreach (int pages in books)
            {
                low = Math.Max(low, pages);
                high += pages;
            }

            int result = -1;
            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                if (IsPossible(books, m, mid))
                {
                    result = mid;
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }

            return result;
        }
        
        //static void Main()
        //{
        //    int n = int.Parse(Console.ReadLine());
        //    string[] inputs = Console.ReadLine().Split();
        //    int[] books = Array.ConvertAll(inputs, int.Parse);
        //    int m = int.Parse(Console.ReadLine());

        //    Console.WriteLine(FindMinimumPages(books, m));
        //}
    }
}

