using System;
using System.Collections.Generic;

namespace Matrix
{
    class Program
    {
        static void Main()
        {
            Console.Clear();
            while (true)
            {

                Console.WriteLine("Matrix Related Methods");
                Console.WriteLine("1) Rotate matrix 90 degees.");
                Console.WriteLine("2) Create matrix size n * m. random values.");
                Console.WriteLine("3) Create matrix size n * m. seed values.");
                Console.WriteLine("4) Multiply two matricies n * m.");
                Console.WriteLine("5) Sort random values by row.");
                Console.WriteLine("6) Fill lower left with 1's.");

                Console.WriteLine("Type a number or ESC to quit");
                var info = Console.ReadKey();

                if (info.Key == ConsoleKey.Escape) return;

                switch (info.Key)
                {
                    case ConsoleKey.D1:
                        RotateMatrix90();

                        break;
                    case ConsoleKey.D2:
                        CreateMatrixRandom();
                        break;

                    case ConsoleKey.D3:
                        CreateMatrixSeed();
                        break;

                    case ConsoleKey.D4:
                        MultiplyTwoMaticies();
                        break;

                    case ConsoleKey.D5:
                        SortMatrixRows();
                        break;
                    case ConsoleKey.D6:
                        CreateLowerLeft();
                        break;

                }
                Console.ReadKey();
                Console.Clear();
            }
        }

        public static void RotateMatrix90()
        {
            Console.Clear();
            Console.WriteLine("Rotate Matrix 90 degees\n");

            // Create a matrix and rotate 90 degrees.
            var matrix = new MatrixOps();
            int size = 5;
            List<List<int>> dataMatrix;

            dataMatrix = matrix.NewDataSeed(size, 10);
            matrix.ListRect(dataMatrix);
            matrix.Rotate_90(dataMatrix);
            matrix.ListRect(dataMatrix);
        }
        public static void CreateMatrixRandom()
        {
            Console.Clear();
            Console.WriteLine("2) Create Matrix with Random values");
            var matrix = new MatrixOps();
            List<List<int>> dataMatrix;

            dataMatrix = matrix.NewDataRandom(4, 7);
            matrix.ListRect(dataMatrix);
        }

        public static void CreateMatrixSeed()
        {
            Console.Clear();
            Console.WriteLine("3) Create Matrix with Seed values");
            var matrix = new MatrixOps();
            List<List<int>> dataMatrix;

            dataMatrix = matrix.NewDataMatrix(4, 1);
            matrix.ListRect(dataMatrix);
        }

        public static void SortMatrixRows()
        {
            Console.Clear();
            Console.WriteLine("2) Sort Matrix Rows");
            var matrix = new MatrixOps();
            List<List<int>> dataMatrix;

            dataMatrix = matrix.NewDataRandom(4, 7);
            matrix.ListRect(dataMatrix);
            matrix.SortEachRowInPlace(dataMatrix);
            matrix.ListRect(dataMatrix);
        }

        public static void MultiplyTwoMaticies()
        {
            Console.Clear();
            Console.WriteLine("3) Multiply Two Matricies n * m\n");

            var matrix = new MatrixOps();
            List<List<int>> mA;
            List<List<int>> mB;

            mA = matrix.NewDataRect(4, 4, 1);
            mB = matrix.NewDataRect(4, 12, 1);

            matrix.ListRect(mA);
            Console.WriteLine("");
            matrix.ListRect(mB);

            List<List<int>> mC = matrix.MultiplyRectangular(mA, mB);

            if (mC == null)
                Console.WriteLine($" {matrix.RunError}");
            else
                matrix.ListRect(mC);

            Console.ReadKey();
        }

        public static void CreateLowerLeft()
        {
            Console.Clear();
            Console.WriteLine("6) Fill Lower Left");
            var matrix = new MatrixOps();
            List<List<int>> dataMatrix;

            dataMatrix = matrix.NewLowerLeft(4);
            matrix.ListRect(dataMatrix);
            matrix.SortEachRowInPlace(dataMatrix);
            matrix.ListRect(dataMatrix);
        }
    }
}

