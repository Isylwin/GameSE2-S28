namespace WinFormsGame.Classes.MapClasses
{
	using System.Collections.Generic;

	public class Path
	{
		public virtual Location StartLocation
		{
			get;
			set;
		}

        public virtual List<Cell> Cells
        {
            get;
            set;
        }

        public virtual Location EndLocation
		{
			get;
			set;
		}

	}
}

