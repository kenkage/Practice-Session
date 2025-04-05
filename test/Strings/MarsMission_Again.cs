using System;
namespace test.Strings
{
	public class MarsMission_Again
	{
        // Helper function to check if a character is a vowel (a, e, i, o, u)
        private static bool IsVowel(char c)
        {
            // Assuming input is lowercase English letters as per typical problem constraints
            return c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u';
        }

        public static void Main(string[] args)
        {
            // Read the length of the string (optional, can use s.Length)
            int n;
            if (!int.TryParse(Console.ReadLine(), out n))
            {
                Console.WriteLine("Invalid length input.");
                return;
            }

            // Read the string itself
            string s = Console.ReadLine();

            // Validate input string length
            if (s == null || s.Length != n)
            {
                Console.WriteLine("Input string length does not match the provided length n or string is null.");
                return;
            }

            // Use a List<string> to store the syllables found
            List<string> syllables = new List<string>();
            int currentIndex = 0;

            // Iterate through the string to identify syllables
            while (currentIndex < s.Length)
            {
                // Syllables start CV...
                // We need to decide if it's CV or CVC.
                // Look ahead: check character at currentIndex + 2 (potential end C)
                // and character at currentIndex + 3 (potential start V of next syllable)

                // Default assumption is CV syllable (length 2)
                int currentSyllableLength = 2;

                // Check if there are enough characters for a potential CVC (i.e., check index i+2)
                if (currentIndex + 2 < s.Length)
                {
                    // Now, look at the character *after* the potential CVC (index i+3)
                    // If index i+3 exists AND the character at i+3 is a VOWEL,
                    // it means the character at i+2 must start the next syllable (as C V),
                    // so the current syllable MUST be CV.
                    if (currentIndex + 3 < s.Length && IsVowel(s[currentIndex + 3]))
                    {
                        currentSyllableLength = 2; // Keep it as CV
                    }
                    else
                    {
                        // Otherwise (either i+3 is out of bounds OR char at i+3 is a consonant),
                        // the character at i+2 can/must be the closing consonant of the current syllable.
                        // So, the current syllable is CVC.
                        currentSyllableLength = 3;
                    }
                }
                // If there are not enough characters for CVC (i+2 >= s.Length),
                // the syllable must be CV (length 2), which is already the default.

                // Extract the syllable using Substring(startIndex, length)
                string syllable = s.Substring(currentIndex, currentSyllableLength);
                syllables.Add(syllable);

                // Move the index forward by the length of the syllable found
                currentIndex += currentSyllableLength;
            }

            Console.WriteLine(string.Join(" ", syllables));
        }
    }
}

