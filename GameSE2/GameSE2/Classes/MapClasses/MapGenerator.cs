using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsGame.Classes.MapClasses;

namespace GameSE2.Classes.MapClasses
{
    static class MapGenerator
    {
        private static Cell[,] _cells;

        public static void GenerateMap(Settings settings, Cell[,] cells)
        {
            var clusterWidth = (settings.HorizontalCells - 1)/2;
            var clusterHeight = (settings.VerticalCells - 1)/2;

            Cluster[,] clusters = new Cluster[clusterWidth,clusterHeight];

            for (int i = 1; i < settings.HorizontalCells - 1; i+=2)
            {
                for (int j = 1; j < settings.VerticalCells - 1; j+=2)
                {
                    clusters[i/2,j/2] = new Cluster(cells[i,j]);
                }
            }

            Stack<Cluster> stack = new Stack<Cluster>();

            Cluster current = clusters[settings.MapRandom.Next(clusterWidth), settings.MapRandom.Next(clusterHeight)];
            current.IsVisited = true;
            stack.Push(current);

            while (stack.Count > 0)
            {
                var neighbours = GetNeighbours(clusters, current);
                current.IsVisited = true;

                if (neighbours.Count > 0)
                {
                    var temp = neighbours[settings.MapRandom.Next(neighbours.Count)];

                    var x = (current.CenterCell.Location.X + temp.CenterCell.Location.X)/2;
                    var y = (current.CenterCell.Location.Y + temp.CenterCell.Location.Y)/2;

                    cells[x, y].IsWall = false;

                    stack.Push(current);
                    current = temp;
                }
                else
                {
                    current = stack.Pop();
                }
            }

            //TODO continue with this maze algorithm.

        }

        private static List<Cluster> GetNeighbours(Cluster[,] clusters, Cluster cluster)
        {
            var returnValue = new List<Cluster>();

            int x = cluster.CenterCell.Location.X/2;
            int y = cluster.CenterCell.Location.Y/2;

            for (int i = x-1; i < x+2; i+=2)
            {
                if(i >= 0 && i < clusters.GetLength(0) && !clusters[i,y].IsVisited)
                    returnValue.Add(clusters[i,y]);
            }

            for (int i = y-1; i < y+2; i+=2)
            {
                if(i >= 0 && i < clusters.GetLength(1) && !clusters[x,i].IsVisited)
                    returnValue.Add(clusters[x,i]);
            }

            return returnValue;
        }
        


        //private static Settings _settings;
        //private static bool[,] _clusters;    //VisitedClusters
        //private const int C_Rad = 2; //Distance in cells to next cluster
        //private static int _maxClustersHeight;
        //private static int _maxClustersWidth;
        //private static int[,] dirList = new int[,] {{0, -1}, {1, 0}, {0, 1}, {-1, 0}};
        //private static Cell[,] _cells;

        //public static void GenerateMap(Settings settings, Cell[,] cells)
        //{
        //    _settings = settings;
        //    _cells = cells;

        //    _maxClustersHeight = _settings.VerticalCells/C_Rad - 1;
        //    _maxClustersWidth = _settings.HorizontalCells/C_Rad - 1;

        //    _clusters = new bool[_maxClustersWidth,_maxClustersHeight];

        //    int totalClusters = (_maxClustersHeight -1)*(_maxClustersWidth - 1);
        //    int rx = 2, ry = 2, dir = 0;
        //    int dx, dy;

        //    _clusters[rx, ry] = true;
        //    int visitedClusters = 1;

        //    while (visitedClusters < totalClusters - 1)
        //    {
        //        dir = _settings.MapRandom.Next(0, 4);

        //        dx = dirList[dir, 0];
        //        dy = dirList[dir, 1];

        //        if (InRange(rx*C_Rad + dx, ry*C_Rad + dy)
        //            && (!_clusters[rx + dx, ry + dy]))
        //        {
        //            ConnectClusters(rx*C_Rad, ry*C_Rad, (rx + dx)*C_Rad, (ry*dy)*C_Rad);
        //            rx += dx;
        //            ry += dy;

        //            _clusters[rx, ry] = true;
        //            _cells[rx * C_Rad, ry * C_Rad].IsWall = false;

        //            visitedClusters++;
        //        }
        //        else
        //        {
        //            do
        //            {
        //                rx = _settings.MapRandom.Next(0, _maxClustersWidth);
        //                ry = _settings.MapRandom.Next(0, _maxClustersHeight);
        //            } while (!_clusters[rx, ry]);
        //        }           
        //    }
        //}

        //private static bool InRange(int x, int y)
        //{
        //    return x > C_Rad && y > C_Rad
        //           && x < _settings.HorizontalCells - C_Rad - 1 && y < _settings.VerticalCells - C_Rad - 1;
        //}

        //private static void ConnectClusters(int x1, int y1, int x2, int y2)
        //{
        //    int cx = x1, cy = y1;

        //    while (cx != x2)
        //    {
        //        if (x1 > x2)
        //            cx--;
        //        else
        //            cx++; 
        //        if (InRange(cx, cy))
        //            _cells[cx,cy].IsWall = false;
        //    }
        //    while (cy != y2)
        //    {
        //        if (y1 > y2)
        //            cy--;
        //        else
        //            cy++;
        //        if (InRange(cx, cy))
        //            _cells[cx, cy].IsWall = false;
        //    }
        //}
    }
}
