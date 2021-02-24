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

            int size = 4;
            var dataMatrix = new List<List<int>>();
            List<List<int>> identityMatrix;
            List<List<int>> lowerLeft;
            List<List<int>> resultMatrix;
            List<int> simpleList;

            Console.WriteLine("");
            simpleList = matrix.NewSimpleList(size);
            for (int i=0; i< size; i++)
            {
                Console.Write($" {simpleList[i]}");
            }
            Console.WriteLine("");

            simpleList.Sort(new SortIntDescending());

            for (int i = 0; i < size; i++)
            {
                Console.Write($" {simpleList[i]}");
            }
            Console.WriteLine("");

            // Create a matrix and rotate 90 degrees. 
            CreateDataMatrix(dataMatrix, size, 10);
            matrix.List(dataMatrix, size, "Data Matrix");
            matrix.Rotate_90(dataMatrix, size);
            matrix.List(dataMatrix, size, "Data matrix rotate 90 degree clockwise");

            // Multiply two matricies.
            matrix.List(dataMatrix, size, "Multiply data matrix by identity Matrix");
            lowerLeft = matrix.NewLowerLeft(size);
            matrix.List(lowerLeft, size, "");
            resultMatrix = matrix.MultiplySqr(dataMatrix, matrix.NewLowerLeft(size), size);
            matrix.List(resultMatrix, size, "for result ");

            //Identity Matrix
            identityMatrix = matrix.NewIdentity(size);
            matrix.List(identityMatrix, size, "Identity matrix is:");

            matrix.List(dataMatrix, size, "Input Matrix");
            //resultMatrix.Clear();
            resultMatrix = matrix.MultiplySqr(dataMatrix, identityMatrix, size);
            matrix.List(resultMatrix, size, "input*identity:");


            Console.WriteLine($"size {dataMatrix.Count}");
            Console.WriteLine($"capacity= {dataMatrix.Capacity}");

            dataMatrix[1][0] = 99;
            Console.WriteLine($"Value {dataMatrix[1][0]}");

            dataMatrix[1][0] = 99;
            Console.WriteLine($"Value {dataMatrix[1][0]}");

            ;

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

        private class SortIntDescending : IComparer<int>
        {
            int IComparer<int>.Compare(int a, int b) //implement Compare
            {
                if (a > b)
                    return 1; //normally greater than = 1
                if (a < b)
                    return -1; // normally smaller than = -1
                else
                    return 0; // equal

            }
        }
    }
}
