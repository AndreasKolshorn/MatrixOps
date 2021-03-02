using System;
using System.Collections.Generic;

namespace Matrix
{
    public class MatrixOps
    {
        public string RunError { get; set; } 
        public static int Instances { get; set; }
 
        public MatrixOps()
        {
            Instances += 1;
        }

        public void Rotate_90(List<List<int>> matrix)
        {
            /* Rotate input matrix 90 degrees clockwise, in place. Time = O(n^2). Space= O(n^2). */
            int size;
            int tail;
            int garbage;

            Instances -= 1;
            size = (matrix.Count ==matrix[0].Count? matrix.Count :0 );

            for (int box = 0; box < size / 2; box++)
                for (int runner = box; runner < size - box - 1; runner++)
                {
                    tail = matrix[box][runner];
                    matrix[box][runner] = matrix[size - runner - 1][box];                       //TL
                    matrix[size - runner - 1][box] = matrix[size - box - 1][size - runner - 1]; //BL
                    matrix[size - box - 1][size - runner - 1] = matrix[runner][size - box - 1]; //BR
                    matrix[runner][size - box - 1] = tail;                                      //TR
                }
        }

        public List<List<int>> NewDataSeed(int size,int seed)
        {
            return NewDataSeed(size, size, seed);
        }

        public List<List<int>> NewDataSeed(int rows, int columns, int seed)
        {
            List<List<int>> matrix = new();

            for (int i = 0; i < rows; i++)
            {
                List<int> row = new();

                for (int j = 0; j < columns; j++)
                {
                    row.Insert(j, seed++);
                }
                matrix.Insert(i, row);
            }
            return matrix;
        }

        public List<List<int>> MultiplyRectangular(List<List<int>> left, List<List<int>> right)
        {
            RunError = "";
            List<List<int>> result = new();

            int left_i = left.Count;
            int left_j = left[0].Count;
            int right_i = right.Count;
            int right_j = right[0].Count;

            // Check if the two matrices can be multiplied
            if (left_j != right_i )
            {
                RunError = "Wrong Size: Matrix Left Cols != Matrix Right Rows";
                return null;
            }

            try
            {
                int val = 0;
                for (int i = 0; i < left_i; i++)
                {
                    var row = new List<int>();
                    for (int j = 0; j < right_j; j++)
                    {
                        val = 0;
                        for (int r = 0; r < right_i; r++)
                            val += left[i][r] * right[r][j];

                        row.Insert(j, val);
                    }
                    result.Insert(i, row);
                }
            }
            catch
            {
                RunError = "Multiply Error";
                return null;
            }

            return result;
        }

        public List<List<int>> NewCopy (List<List<int>> source)
        {
            List<List<int>> result = new();
            int source_i = source.Count;
            int source_j = source[0].Count;
            for (int i =0; i<source_i; i++)
            {
                var row = new List<int>();
                for (int j = 0; j < source_j; j++)
                {
                    row.Insert(j, source[i][j]);
                }
                result.Insert(i, row);
            }
            return result;
        }

        public List<List<int>> NewDataRandom(int size)
        {
            return NewDataRandom(size, size);
        }

        public List<List<int>> NewDataRandom(int rows, int columns)
        {
            var matrix = new List<List<int>>();
            var rand = new Random();

            for (int i=0; i<rows; i++)
            {
                var row = new List<int>();
                for (int j=0; j<columns; j++)
                {
                    row.Insert(j, rand.Next(50, 100));
                }
                matrix.Insert(i,row);
            }

            return matrix;
        }

        public List<List<int>> NewDataRect(int rows, int columns, int seed)
        {
            var matrix = new List<List<int>>();
            var rand = new Random();

            for (int i = 0; i < rows; i++)
            {
                var row = new List<int>();
                for (int j = 0; j < columns; j++)
                {
                    row.Insert(j, seed++);
                }
                matrix.Insert(i, row);
            }

            return matrix;
        }

        public void ListRect(List<List<int>> matrix)
        {
            int ni = matrix.Count;
            int nj = matrix[0].Count;

            for (int i=0; i < ni; i++)
            {
                for (int j = 0; j < nj; j++)
                    Console.Write($" {matrix[i][j]}");

                Console.WriteLine("");
            }

            Console.WriteLine($" i={ni}/{matrix.Capacity} j={nj}/{matrix[0].Capacity} \n");
        }

        public  List<List<int>> NewDataMatrix(int size, int seed)
        {
            var matrix = new List<List<int>>(); 

            for (int i = 0; i < size; i++)
            {
                var vi = new List<int>();

                for (int j = 0; j < size; j++)
                {
                    vi.Insert(j, seed);
                    seed++;
                }

                matrix.Insert(i, vi);
            }
            return matrix;
        }

        public  List<List<int>> NewLowerLeft(int size)
        {
            /* Create a square matrix of ones in lower left side including diagonal.
            * e.g.     1 0 0
            *          1 1 0
            *          1 1 1
            */

            int cnt;
            var matrix = new List<List<int>>();

            for (int i = 0; i < size; i++)
            {
                var vi = new List<int>();
                cnt = 0;

                for (int j = 0; j < size; j++)
                   if (cnt < i + 1)
                    {
                        vi.Insert(j, 1);
                        cnt++;
                    }
                    else
                        vi.Insert(j, 0);

                matrix.Insert(i, vi);
            }

            return matrix;
        }

        public List<int> NewSimpleList(int size)
        {
            var rand = new Random();
            var sList = new List<int>();
            for (int i = 0; i < size; i++)
                sList.Insert(i,  rand.Next(50,101));

            return sList;
        }

        public void List(List<List<int>> matrix, int size, string msg)
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

        public void SortEachRowInPlace(List<List<int>> matrix)
        {
            int mi = matrix.Count;
            int mj = matrix[0].Count;

            for (int i=0; i < mi; i++)
            {
                matrix[i].Sort(new SortIntDescending());
            }
        }

    }   //End Matrix Class

    public class SortIntDescending : IComparer<int>
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

    /* TODO: Transform augmented matrix into eshelon form */

}   // End Namespace 

