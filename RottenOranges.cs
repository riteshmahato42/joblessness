/*
 *In a given grid, each cell can have one of three values:

the value 0 representing an empty cell;
the value 1 representing a fresh orange;
the value 2 representing a rotten orange.
Every minute, any fresh orange that is adjacent (4-directionally) to a rotten orange becomes rotten.

Return the minimum number of minutes that must elapse until no cell has a fresh orange.  If this is impossible, return -1 instead. * 
 */

namespace InterviewPrep.Graph
{
    using System;
    using System.Collections.Generic;

    public class RottenOranges
    {
        public int OrangesRotting(int[][] grid)
        {
            var nextCells = new Queue<Tuple<int, int>>();

            // Initialize the queue for BFS
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (grid[i][j] == 2)
                    {
                        nextCells.Enqueue(new Tuple<int, int>(i,j));
                    }
                }
            }

            int minutes = 0;

            return BFSGrid(grid, nextCells, minutes);
        }

        private int BFSGrid(int[][] grid, Queue<Tuple<int, int>> nextCells, int minutes)
        {
            var currSizeOfQueue = nextCells.Count;
            while (nextCells.Count != 0)
            {
                var currentCell = nextCells.Dequeue();
                if (currentCell.Item1 - 1 >= 0)
                {
                    if (grid[currentCell.Item1 - 1][currentCell.Item2] == 1)
                    {
                        grid[currentCell.Item1 - 1][currentCell.Item2] = 2;
                        nextCells.Enqueue(new Tuple<int, int>(currentCell.Item1 - 1, currentCell.Item2));
                    }
                }

                if (currentCell.Item1 + 1 < grid.Length)
                {
                    if (grid[currentCell.Item1 + 1][currentCell.Item2] == 1)
                    {
                        grid[currentCell.Item1 + 1][currentCell.Item2] = 2;
                        nextCells.Enqueue(new Tuple<int, int>(currentCell.Item1 + 1, currentCell.Item2));
                    }
                }

                if (currentCell.Item2 - 1 >= 0)
                {
                    if (grid[currentCell.Item1][currentCell.Item2 - 1] == 1)
                    {
                        grid[currentCell.Item1][currentCell.Item2 - 1] = 2;
                        nextCells.Enqueue(new Tuple<int, int>(currentCell.Item1, currentCell.Item2 - 1));
                    }
                }

                if (currentCell.Item2 + 1 < grid[0].Length)
                {
                    if (grid[currentCell.Item1][currentCell.Item2 + 1] == 1)
                    {
                        grid[currentCell.Item1][currentCell.Item2 + 1] = 2;
                        nextCells.Enqueue(new Tuple<int, int>(currentCell.Item1, currentCell
                            .Item2 + 1));
                    }
                }

                currSizeOfQueue--;

                if (currSizeOfQueue == 0)
                {
                    currSizeOfQueue = nextCells.Count;
                    if (currSizeOfQueue != 0)
                    {
                        minutes++;
                    }
                }
            }

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        return -1;
                    }
                }
            }

            return minutes;
        }
    }
}
