using System;
using System.Collections.Generic;

namespace MatrixOps
{
    public class MatrixOps
    {
        public static int instances = 0;
 
        public MatrixOps()
        {
            instances += 1;
            Console.WriteLine($"Create Matrix Ops Object cnt={instances} ");
        }

        public void Rotate_90(List<List<int>> matrix, int size)
        {
            /* Rotate input matrix 90 degrees clockwise, in place. Time = O(n^2). Space= O(n^2). */
            int tail;

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

        public void NewFromSeed(List<List<int>> dataMatrix, int size, int seed)
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

        public List<List<int>> NewIdentity(int size)
        {
            var identity = new List<List<int>>();
            for (int i=0; i < size; i++)
            {
                var row = new List<int>();
                for (int j=0; j<size; j++)
                {
                     row.Insert(j, i==j? 1 : 0);
                }

                identity.Insert(i, row);
            }

            return identity;
        }

        public List<int> NewSimpleList(int size)
        {
            var rand = new Random();
            var sList = new List<int>();
            for (int i = 0; i < size; i++)
                sList.Insert(i,  rand.Next(50,101));

            return sList;
        }


        public List<List<int>> MultiplySqr (List<List<int>> leftMatrix, List<List<int>> rightMatrix, int size)
        {
            var resultMatrix = new List<List<int>>(); 

            for (int i = 0; i < size; i++)
            {
                var row = new List<int>();
                for (int j = 0; j < size; j++)
                {
                    int tmp = 0;

                    for (int r = 0; r < size; r++)
                        tmp += leftMatrix[i][r] * rightMatrix[r][j];

                    row.Insert(j, tmp);
                }
                resultMatrix.Insert(i, row);
            }
            return resultMatrix;
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



    }   //End Matrix Class
}   // End Namespace 
