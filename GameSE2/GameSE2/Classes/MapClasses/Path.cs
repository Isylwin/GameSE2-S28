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

	}
}

