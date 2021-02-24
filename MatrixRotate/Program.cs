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

            int size = 11;
            List<List<int>> dataMatrix;
            List<List<int>> identityMatrix;
            List<List<int>> lowerLeft;
            List<List<int>> resultMatrix;
            List<List<int>> dataRandom;
 
            // Create a matrix and rotate 90 degrees. 
            dataMatrix= matrix.NewDataSeed(size, 10);
            matrix.List(dataMatrix, size, "Data Matrix");

            matrix.Rotate_90(dataMatrix);
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

            dataRandom = matrix.NewDataRandom(3, 7);
            matrix.ListRect(dataRandom);

            matrix.SortEachRowInPlace(dataRandom);
            matrix.ListRect(dataRandom);

            Console.ReadKey();
        }


    }
}
