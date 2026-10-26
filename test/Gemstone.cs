using System;
namespace test
{
	public class GemstoneSolution
    {
        public static int Gemstones(string[] arr)
        {
            HashSet<char> gemstones = new HashSet<char>(arr[0]);

            foreach (string rock in arr)
            {
                Console.WriteLine(rock);
                gemstones.IntersectWith(rock);
            }
            
            return gemstones.Count;
        }
    }

	public class Gemstone
    {
        public static void Run()
        {
            string[] rocks = new string[] { "abcdde", "baccd", "eeabg" };
            int result = GemstoneSolution.Gemstones(rocks);
            Console.WriteLine(result);  // Output: 2
        }
    }
}

