using System;
namespace test.Stack
{
	public class Collisions
	{
        //static void Main()
        //{
        //    int n = int.Parse(Console.ReadLine());
        //    int[] asteroids = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

        //    int[] result = GetAsteroidState(asteroids);
        //    Console.WriteLine(result.Length == 0 ? "[]" : string.Join(" ", result));
        //}

        static int[] GetAsteroidState(int[] asteroids)
        {
            Stack<int> stack = new Stack<int>();

            foreach (int asteroid in asteroids)
            {
                bool exploded = false;

                while (stack.Count > 0 && asteroid < 0 && stack.Peek() > 0)
                {
                    int top = stack.Peek();
                    if (Math.Abs(asteroid) > top)
                    {
                        stack.Pop(); // top explodes
                    }
                    else if (Math.Abs(asteroid) == top)
                    {
                        stack.Pop(); // both explode
                        exploded = true;
                        break;
                    }
                    else
                    {
                        exploded = true; // current asteroid explodes
                        break;
                    }
                }

                if (!exploded)
                {
                    stack.Push(asteroid);
                }
            }

            int[] result = stack.ToArray();
            Array.Reverse(result);
            return result;
        }
    }
}

