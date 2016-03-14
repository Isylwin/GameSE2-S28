namespace WinFormsGame.Classes.MapClasses
{
	public class Cell
	{
        /// <summary>
        /// Determines wheter the cell has a wall or not.
        /// </summary>
		public bool IsWall { get; set; }

        /// <summary>
        /// Location of the cell.
        /// </summary>
		public Location Location { get; }

        public Cell(Location location)
        {
            Location = location;
        }

        public Cell(Location location, bool isWall)
        {
            Location = location;
            IsWall = isWall;
        }

        public override string ToString()
        {
            return Location.ToString() + " " + (IsWall ? "Wall" : "Empty");
        }

    }
}

