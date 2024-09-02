/*
 * New Matrix
Tuntun is very creative. She is thinking of a new way to modify the matrix but she is very weak in coding so help her to do so. You are given a n x m integer matrix matrix, if an element is 0, set its entire row and column to 0's.
You must do it in place.

Input Format
- The first line contains two space-separated integers ‘N’ and ‘M’, denoting the no. of the rows and columns of the matrix.

- The next 'N' lines will contain ‘M’ space separated integers representing the elements of the matrix.



Output Format:
print the modified grid in a separate line.


Example
1 1 1                  1 0 1
1 0 1     =>        0 0 0
1 1 1                  1 0 1
 */

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

