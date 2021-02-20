using System;
using System.Collections.Generic;

namespace MatrixRotate
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Matrix Related Methods");

            int size = 3;
            var dataMatrix = new List<List<int>>();
            var identityMatrix = new List<List<int>>();
            var resultMatrix = new List<List<int>>();

            // Create a matrix of size size and rotate 90 degrees. 
            CreateDataMatrix(dataMatrix, size, 10);
            ListMatrix(dataMatrix, size, "Data Matrix");
            MatrixRotate_90(dataMatrix, size);
            ListMatrix(dataMatrix, size, "Data matrix rotate 90 degree clockwise");

            // Apply a matrix multiply operation with an identity matrix.
            ListMatrix(dataMatrix, size, "Using Data Matrix");
            CreateIdentityMatrix(identityMatrix, size);
            ListMatrix(identityMatrix, size, "Multiply by Identity Matrix");
            MatrixMultiply(resultMatrix, dataMatrix, size);
            ListMatrix(resultMatrix, size, "Resulting Data Matrix");

            Console.ReadKey();
        }

        private static void CreateDataMatrix (List<List<int>> dataMatrix, int size, int seed)
        {
            for (int i = 0; i < size; i++)
            {
                var vi = new List<int>();

                for (int j = 0; j < size; j++)
                {
                    vi.Insert(j, seed);
                    seed++;
                }

                dataMatrix.Insert(i, vi);
            }
        }

       private static int MatrixRotate_90(List<List<int>> matrix, int size)
        {
            int tail;

            for (int box =0; box<size/2; box++)
                for (int runner=box; runner < size-box-1; runner++)
                {
                    tail = matrix[box][runner];
                    matrix[box][runner]               = matrix[size-runner-1][box];        //TL
                    matrix[size-runner-1][box]        = matrix[size-box-1][size-runner-1]; //BL
                    matrix[size-box-1][size-runner-1] = matrix[runner][size-box-1];        //BR
                    matrix[runner][size-box-1]        = tail;                              //TR
                }

            return 0;
        }

        private static void ListMatrix(List<List<int>> matrix, int size, string msg)
        {
            Console.WriteLine();
            Console.WriteLine(msg);

            for (int i = 0; i < size; i++)
            { 
                for (int j = 0; j < size; j++)
                    Console.Write(matrix[i][j].ToString() + " ");
                Console.WriteLine();
            }
        }

        private static void CreateIdentityMatrix(List<List<int>> matrix, int size)
        {
            int cnt;
            for (int i = 0; i < size; i++)
            {
                var vi = new List<int>();
                cnt = 0;

                for (int j=0; j<size; j++)
                {
                   if (cnt < i+1) {
                        vi.Insert(j, 1);
                        cnt++;
                   }
                   else      
                        vi.Insert(j, 0);
                }

                matrix.Insert(i, vi);
            }
        }

        private static void MatrixMultiply(List<List<int>> resultMatrix, List<List<int>> srcMatrix, int size)
        {
            var identityMatrix = new List<List<int>>();
            CreateIdentityMatrix(identityMatrix, size);

            for (int i = 0; i < size; i++)
            {
                var row = new List<int>();
                for (int j = 0; j < size; j++)
                {
                    int tmp = 0;

                    for (int r = 0; r < size; r++)
                        tmp += srcMatrix[i][r] * identityMatrix[r][j];

                    row.Insert(j, tmp);
                }
                resultMatrix.Insert(i, row);
            }
        }
    }
}
