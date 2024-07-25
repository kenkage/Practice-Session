//public class Solution
//{
//    public IList<IList<int>> Generate(int numRows)
//    {
//        IList<IList<int>> triangle = new List<IList<int>>();

//        if (numRows == 0)
//        {
//            return triangle;
//        }

//        triangle.Add(new List<int> { 1 });

//        for (int i = 1; i < numRows; i++)
//        {
//            IList<int> prevRow = triangle[i - 1];
//            IList<int> row = new List<int>();
//            row.Add(1);

//            for (int j = 1; j < i; j++)
//            {
//                row.Add(prevRow[j - 1] + prevRow[j]);
//            }

//            row.Add(1);
//            triangle.Add(row);
//        }

//        return triangle;
//    }
//}

//// Example usage
//public class Program
//{
//    public static void Main()
//    {
//        Solution solution = new Solution();
//        int numRows = 5;
//        IList<IList<int>> result = solution.Generate(numRows);

//        foreach (var row in result)
//        {
//            Console.WriteLine(string.Join(" ", row));
//        }
//    }
//}