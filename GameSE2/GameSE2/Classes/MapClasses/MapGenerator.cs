using System;
using System.Collections.Generic;
using WinFormsGame.Classes.MapClasses;

namespace WinFormsGame.Classes.MapClasses
{
    public static class MapGenerator
    {
        /// <summary>
        /// Mines a single solution maze into a map. Using recursive backtracking
        /// </summary>
        /// <param name="mapRandom">The random object that is used to create the map. Needed to ensure reproducability</param>
        /// <param name="cells">The 2D array of cells that represent the map. Map needs to be entirely walls.</param>
        public static void MineMazeRecursiveBacktracking(Random mapRandom, Cell[,] cells)
        {
            //There is 1 cell between the centers of clusters, thus half the amount of cells in either direction. 
            var clusterWidth = (cells.GetLength(0) - 1)/2;
            var clusterHeight = (cells.GetLength(1) - 1)/2;

            var clusters = new Cluster[clusterWidth,clusterHeight];

            //Create the array of clusters.
            for (var i = 1; i < cells.GetLength(0) - 1; i+=2)
            {
                for (var j = 1; j < cells.GetLength(1) - 1; j+=2)
                {
                    clusters[i/2,j/2] = new Cluster(cells[i,j]);
                }
            }

            var stack = new Stack<Cluster>();

            //Choose a random location to start the mining.
            var current = clusters[mapRandom.Next(clusterWidth), mapRandom.Next(clusterHeight)];

            //Push the current cluster to the stack.
            stack.Push(current);

            //As long as there are clusters with neighbours, execute the algorithm.
            while (stack.Count > 0)
            {
                //Retrieve the neighbours
                var neighbours = current.GetNeighbours(clusters);

                //Mark the current cluster as being visited, prevents infinite loop.
                current.IsVisited = true;

                //If the cluster has neighbours create a connection, else backtrack to a cell that has neighbours.
                if (neighbours.Count > 0)
                {
                    //Choose a random neighbour.
                    var temp = neighbours[mapRandom.Next(neighbours.Count)];

                    //Get the coordinates of the cell between the two clusters.
                    var x = (current.CenterCell.Location.X + temp.CenterCell.Location.X)/2;
                    var y = (current.CenterCell.Location.Y + temp.CenterCell.Location.Y)/2;

                    cells[x, y].IsWall = false;

                    //Add the current cluster to the stack and move to the neighbour.
                    stack.Push(current);
                    current = temp;
                }
                else
                {
                    current = stack.Pop();
                }
            }
        }    
    }
}
