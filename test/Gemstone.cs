using System;
namespace test
{
	public class Gemstone
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

	public class Program2
	{
        //public static void Main(string[] args)
        //{
        //    string[] rocks = new string[] { "abcdde", "baccd", "eeabg" };
        //    int result = Gemstone.Gemstones(rocks);
        //    Console.WriteLine(result);  // Output: 2
        //}
    }
}

