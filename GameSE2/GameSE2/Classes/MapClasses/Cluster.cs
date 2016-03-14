using System.Collections.Generic;

namespace WinFormsGame.Classes.MapClasses
{
    /// <summary>
    /// Needed to represent a cell with 4 walls on each side. Needed for maze generation algorithms.
    /// </summary>
    public class Cluster
    {
        /// <summary>
        /// The cell that is the center of the cluster
        /// </summary>
        public Cell CenterCell { get; }

        /// <summary>
        /// Bool that specifies wheter this cluster has been visited, required for some algorithms.
        /// </summary>
        public bool IsVisited { private get; set; }

        public Cluster(Cell centerCell)
        {
            CenterCell = centerCell;

            //The center of the cluster is always empty
            CenterCell.IsWall = false;
        }

        /// <summary>
        /// Gets the neighbours of this cluster.
        /// </summary>
        /// <param name="clusters">The other clusters that exist</param>
        /// <returns>A list of neighbours</returns>
        public List<Cluster> GetNeighbours(Cluster[,] clusters)
        {
            var returnValue = new List<Cluster>();

            //Using the saved centerCell location we can determine the index of the cluster in the array
            var x = CenterCell.Location.X / 2;
            var y = CenterCell.Location.Y / 2;

            //Only get the horizontal and vertical neighbours, not the diagonal.
            for (var i = x - 1; i < x + 2; i += 2)
            {
                if (i >= 0 && i < clusters.GetLength(0) && !clusters[i, y].IsVisited)
                    returnValue.Add(clusters[i, y]);
            }

            for (var i = y - 1; i < y + 2; i += 2)
            {
                if (i >= 0 && i < clusters.GetLength(1) && !clusters[x, i].IsVisited)
                    returnValue.Add(clusters[x, i]);
            }

            return returnValue;
        }

    }
}
