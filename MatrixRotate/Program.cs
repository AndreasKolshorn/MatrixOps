using System;
using System.Collections.Generic;

namespace MatrixOps
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Matrix Related Methods");

            var matrix = new MatrixOps();

            int size = 3;
            var dataMatrix = new List<List<int>>();
            var identityMatrix = new List<List<int>>();
            var resultMatrix = new List<List<int>>();

            // Create a matrix of size and rotate 90 degrees. 
            CreateDataMatrix(dataMatrix, size, 10);
            matrix.List(dataMatrix, size, "Data Matrix");
            matrix.Rotate_90(dataMatrix, size);
            matrix.List(dataMatrix, size, "Data matrix rotate 90 degree clockwise");

            // Multiply two maticies.
            matrix.List(dataMatrix, size, "Multiply data matrix by identity Matrix");
            identityMatrix = matrix.MakeLeftOnes(size);
            matrix.List(identityMatrix, size, "");
            resultMatrix = matrix.Multiply(dataMatrix, matrix.MakeLeftOnes(size), size);
            matrix.List(resultMatrix, size, "for result ");

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




       




    }
}
