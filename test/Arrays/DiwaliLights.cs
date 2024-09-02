using System;
namespace test.Arrays
{
	public class DiwaliLights
	{
		//static void Main()
		//{
  //          string[] parts = Console.ReadLine().Split(' ');
  //          int N = int.Parse(parts[0]);
  //          int K = int.Parse(parts[1]);

		//	string S = Console.ReadLine();

  //          int result = LongestWorkingLightsSubstring(N, K, S);
  //          Console.WriteLine("The length of the longest substring with all working lights: " + result);
  //      }

        public static int LongestWorkingLightsSubstring(int N, int K, string S)
        {
            int left = 0, maxLen = 0, damagedLights = 0;

            for (int right = 0; right < N; right++)
            {
                // If we encounter a damaged light, increment the count
                if (S[right] == '.')
                {
                    damagedLights++;
                }

                // If the number of damaged lights exceeds K, move the left pointer to the right
                while (damagedLights > K)
                {
                    if (S[left] == '.')
                    {
                        damagedLights--;
                    }
                    left++;
                }

                // Calculate the length of the current valid window
                maxLen = Math.Max(maxLen, right - left + 1);
            }

            return maxLen;
        }
    }
}

