using System;
using System.Collections.Generic;

namespace MatrixRotate
{
    class Program
    {

       private static int Matrix_rotation90(List<List<int>> matrix, int size)
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

        private static void CreateIdentityMatrix( int size, List<List<int>> matrix)
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

        private static void MatrixMultiply(int size, List<List<int>> resultMatrix, List<List<int>> srcMatrix)
        {
            var identityMatrix = new List<List<int>>();
            CreateIdentityMatrix(size, identityMatrix);
            int tmp=0;

            for (int i = 0; i < size; i++)
            {
                var row = new List<int>();
                for (int j = 0; j < size; j++)
                {

                    for (int r = 0; r < size; r++)
                        tmp += srcMatrix[i][r] * identityMatrix[r][j];
                    row.Insert(j, tmp);
                    tmp = 0;
                }

                resultMatrix.Insert(i, row);
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            int val = 2, size = 5;
            var dataMatrix = new List<List<int>>();
            var identityMatrix = new List<List<int>>();
            var resultMatrix = new List<List<int>>();
            CreateIdentityMatrix(size, identityMatrix);

            for (int i = 0; i < size; i++)
            {
                var vi = new List<int>();

                for (int j = 0; j < size; j++)
                {
                   
                    vi.Insert(j, val);
                    val++;
                }
                dataMatrix.Insert(i, vi);
            }

            ListMatrix(dataMatrix, size, "DataMatrix");

            ListMatrix(identityMatrix, size, "IdentityMatrix");

            MatrixMultiply(size, resultMatrix, dataMatrix);

            Matrix_rotation90(dataMatrix, size);

            ListMatrix(resultMatrix, size, "ResultMatrix");

            ListMatrix(dataMatrix, size, "DataMatrix");

            Console.WriteLine("\nMatrix after rotating 90 degrees\n");

            Console.ReadKey();
       }
    }
}
