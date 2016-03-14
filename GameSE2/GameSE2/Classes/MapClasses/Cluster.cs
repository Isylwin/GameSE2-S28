using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsGame.Classes.MapClasses;

namespace GameSE2.Classes.MapClasses
{
    public class Cluster
    {
        public Cell CenterCell { get; }

        public bool IsVisited { get; set; }

        public Cluster(Cell centerCell)
        {
            CenterCell = centerCell;
            CenterCell.IsWall = false;
        }

        //public List<Cluster> GetNeighbours(Cluster[,] clusters)
        //{
        //    var Neighbours = new List<Cluster>();

        //    for (int i = CenterCell.Location.X - 1; i <= CenterCell.Location.X + 1; i++)
        //    {
        //        for (int j = CenterCell.Location.Y - 1; j <= CenterCell.Location.Y + 1; j++)
        //        {
        //            Neighbours.Add(clusters[i, j]);
        //        }
        //    }

        //    Neighbours.Remove(centerCell);
        //}

    }
}
