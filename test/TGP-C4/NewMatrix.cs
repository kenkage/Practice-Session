using System;
namespace test.TGPC4
{
	public class NewMatrix
	{
        //static void Main()
        //{
        //    var dimensions = Console.ReadLine().Split(' ');
        //    int n = int.Parse(dimensions[0]);
        //    int m = int.Parse(dimensions[1]);

        //    // Input the matrix
        //    int[,] matrix = new int[n, m];
        //    for (int i = 0; i < n; i++)
        //    {
        //        var row = Console.ReadLine().Split(' ');
        //        for (int j = 0; j < m; j++)
        //        {
        //            matrix[i, j] = int.Parse(row[j]);
        //        }
        //    }

        //    // Modify the matrix in place
        //    SetZeroes(matrix);

        //    // Output the modified matrix
        //    for (int i = 0; i < n; i++)
        //    {
        //        for (int j = 0; j < m; j++)
        //        {
        //            Console.Write(matrix[i, j] + " ");
        //        }
        //        Console.WriteLine();
        //    }
        //}

        static void SetZeroes(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            bool firstRowZero = false;
            bool firstColZero = false;

            // Check if first row has any zeros
            for (int j = 0; j < m; j++)
            {
                if (matrix[0, j] == 0)
                {
                    firstRowZero = true;
                    break;
                }
            }

            // Check if first column has any zeros
            for (int i = 0; i < n; i++)
            {
                if (matrix[i, 0] == 0)
                {
                    firstColZero = true;
                    break;
                }
            }

            // Use first row and first column as markers
            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < m; j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        matrix[i, 0] = 0;
                        matrix[0, j] = 0;
                    }
                    if (matrix[i, 0] == 0 || matrix[0, j] == 0)
                    {
                        matrix[i, j] = 0;
                    }
                }
            }

            // Zero out cells based on markers in first row and column
            //for (int i = 1; i < n; i++)
            //{
            //    for (int j = 1; j < m; j++)
            //    {
            //        if (matrix[i, 0] == 0 || matrix[0, j] == 0)
            //        {
            //            matrix[i, j] = 0;
            //        }
            //    }
            //}

            // Handle the first row
            if (firstRowZero)
            {
                for (int j = 0; j < m; j++)
                {
                    matrix[0, j] = 0;
                }
            }

            // Handle the first column
            if (firstColZero)
            {
                for (int i = 0; i < n; i++)
                {
                    matrix[i, 0] = 0;
                }
            }
        }
	}
}

