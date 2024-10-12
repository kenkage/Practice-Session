using System;
namespace test.Queue
{
	public class PetrolPump
	{
        //static void Main()
        //{
        //    int n = int.Parse(Console.ReadLine());

        //    int[] petrol = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

        //    int[] distance = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

        //    int result = CircularTour(petrol, distance, n);

        //    Console.WriteLine(result);
        //}

        static int CircularTour(int[] petrol, int[] distance, int n)
        {
            int totalPetrol = 0, totalDistance = 0;
            int start = 0, balance = 0;

            for (int i = 0; i < n; i++)
            {
                totalPetrol += petrol[i];
                totalDistance += distance[i];

                // Add the net balance for this petrol pump
                balance += petrol[i] - distance[i];

                // If balance goes negative, we can't start from the current or any previous pump
                if (balance < 0)
                {
                    // Reset starting point to the next pump
                    start = i + 1;
                    // Reset balance to 0 as we start from a new point
                    balance = 0;
                }
            }

            // If total petrol is greater than or equal to total distance, return the starting point
            // Otherwise, return -1 as no valid starting point exists
            return totalPetrol >= totalDistance ? start : -1;
        }
    }
}

