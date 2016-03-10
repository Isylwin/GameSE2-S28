﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
namespace WinFormsGame.Classes.MapClasses
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;

	public class Location
	{
		public int X { get; set; }
		public int Y { get; set; }

        public Location(int x, int y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Returns a random location within given bounds
        /// </summary>
        /// <param name="xMin">Minimum x-coordinate</param>
        /// <param name="xMax">Maximum x-coordinate</param>
        /// <param name="yMin">Minimum y-coordinate</param>
        /// <param name="yMax">Maximum y-coordinate</param>
	    public Location(int xMin, int xMax, int yMin, int yMax, Random rnd)
	    {
            //Random rnd = new Random();
	        X = rnd.Next(xMin, xMax);
	        Y = rnd.Next(yMin, yMax);
	    }

        public override string ToString()
        {
            return "(" + X + "," + Y + ")";
        }

	    public override bool Equals(object obj)
	    {
	        var otherLoc = obj as Location;

	        return X == otherLoc.X && Y == otherLoc.Y;
	    }

	    public static bool operator ==(Location a, Location b)
	    {
            if (object.ReferenceEquals(a, null))
            {
                return object.ReferenceEquals(b, null);
            }

            return a.Equals(b);
	    }

	    public static bool operator !=(Location a, Location b)
	    {
	        return !(a == b);
	    }
	}
}

