using System.Linq;

namespace WinFormsGame.Classes.MapClasses
{
	using System.Collections.Generic;

	public class Path
	{
		public Location StartLocation { get; set; }

        public List<Cell> FoundPath { get; set; }

        public List<Cell> VisitedCells { get; set; }

        public Location EndLocation { get; set; }

	    public Path(Location startLoc, Location endLoc)
	    {
	        StartLocation = startLoc;
	        EndLocation = endLoc;
            FoundPath = new List<Cell>();
            VisitedCells = new List<Cell>();
	    }

        public bool FindPath(Location loc, Cell[,] cells)
        {
            if (loc == EndLocation)
            {
                VisitedCells.Add(cells[loc.X, loc.Y]);
                FoundPath.Add(cells[loc.X, loc.Y]);
                return true;
            }

            if (VisitedCells.Exists(x => x.Location == loc))
                return false;

            VisitedCells.Add(cells[loc.X, loc.Y]);
            var neighbours = GetNeighbours(loc, cells);

            if (neighbours.Any(newLoc => FindPath(newLoc, cells)))
            {
                FoundPath.Add(cells[loc.X, loc.Y]);
                return true;
            }

            return false;
        }

        private List<Location> GetNeighbours(Location loc, Cell[,] cells)
        {
            var returnValue = new List<Location>();

            for (var i = loc.X - 1; i < loc.X + 2; i += 2)
            {
                if (!cells[i, loc.Y].IsWall)
                    returnValue.Add(cells[i, loc.Y].Location);
            }

            for (var i = loc.Y - 1; i < loc.Y + 2; i += 2)
            {
                if (!cells[loc.X, i].IsWall)
                    returnValue.Add(cells[loc.X, i].Location);
            }

            return returnValue;
        }

    }
}

