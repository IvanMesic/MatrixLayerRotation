using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Result
{
    public static void matrixRotation(List<List<int>> matrix, int r)
    {
        if (!ValidateConstraints(matrix, r)) return;

        int rows = matrix.Count;
        int columns = matrix[0].Count;

        if (IsMatrixUniform(matrix))
        {
            PrintMatrix(matrix, rows, columns);
            return;
        }

        int layers = Math.Min(rows, columns) / 2;
        int[,] result = new int[rows, columns];

        for (int layer = 0; layer < layers; layer++)
        {
            var coords = GetLayerCoordinates(layer, rows - 1 - layer, layer, columns - 1 - layer);
            int len = coords.Count;
            int rot = r % len;

            for (int i = 0; i < len; i++)
            {
                var target = coords[i];
                var source = coords[(i + rot) % len];
                result[target.r, target.c] = matrix[source.r][source.c];
            }
        }

        PrintMatrix(result, rows, columns);
    }

    private static bool IsMatrixUniform(List<List<int>> matrix)
    {
        int firstValue = matrix[0][0];
        int rows = matrix.Count;
        int columns = matrix[0].Count;

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                if (matrix[i][j] != firstValue)
                {
                    return false;
                }
            }
        }

        return true;
    }

    private static List<(int r, int c)> GetLayerCoordinates(int top, int bottom, int left, int right)
    {
        var coords = new List<(int r, int c)>();

        for (int j = left; j <= right; j++) coords.Add((top, j));
        for (int i = top + 1; i <= bottom; i++) coords.Add((i, right));
        for (int j = right - 1; j >= left; j--) coords.Add((bottom, j));
        for (int i = bottom - 1; i > top; i--) coords.Add((i, left));

        return coords;
    }

    private static bool ValidateConstraints(List<List<int>> matrix, int r)
    {
        int rows = matrix.Count;
        int columns = matrix[0].Count;

        if (rows < 2 || rows > 300 || columns < 2 || columns > 300)
        {
            Console.WriteLine($"Constraint broken: 2 <= m, n <= 300. Provided m={rows}, n={columns}.");
            return false;
        }

        if (r < 1 || r > 1000000000)
        {
            Console.WriteLine($"Constraint broken: 1 <= r <= 10^9. Provided r={r}.");
            return false;
        }

        if (Math.Min(rows, columns) % 2 != 0)
        {
            Console.WriteLine($"Constraint broken: min(m, n) % 2 = 0. Provided m={rows}, n={columns}.");
            return false;
        }

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                if (matrix[i][j] < 1 || matrix[i][j] > 100000000)
                {
                    Console.WriteLine($"Constraint broken: 1 <= matrix[i][j] <= 10^8. Provided matrix[{i}][{j}]={matrix[i][j]}.");
                    return false;
                }
            }
        }

        return true;
    }

    private static void PrintMatrix(int[,] matrix, int rows, int columns)
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                sb.Append(matrix[i, j]);
                if (j < columns - 1) sb.Append(" ");
            }
            sb.AppendLine();
        }

        Console.Write("\nResult of the Rotation:\n");
        Console.Write(sb.ToString());
    }

    private static void PrintMatrix(List<List<int>> matrix, int rows, int columns)
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                sb.Append(matrix[i][j]);
                if (j < columns - 1) sb.Append(" ");
            }
            sb.AppendLine();
        }
        Console.Write("\nAll numbers in the matrix are the same, output is the same as input:\n \n");
        Console.Write(sb.ToString());
    }
}



class Solution
{
    public static void Main(string[] args)
    {
        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int m = Convert.ToInt32(firstMultipleInput[0]);

        int n = Convert.ToInt32(firstMultipleInput[1]);

        int r = Convert.ToInt32(firstMultipleInput[2]);

        List<List<int>> matrix = new List<List<int>>();

        for (int i = 0; i < m; i++)
        {
            matrix.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(matrixTemp => Convert.ToInt32(matrixTemp)).ToList());
        }

        Result.matrixRotation(matrix, r);
    }
}
