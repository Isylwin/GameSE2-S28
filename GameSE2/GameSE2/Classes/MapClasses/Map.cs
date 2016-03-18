﻿using WinFormsGame.Classes.MapClasses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WinFormsGame.Classes
{
    public class Map
    {
        private readonly Settings _settings;

        /// <summary>
        /// 2D array of cells that represent the map.
        /// </summary>
        public Cell[,] Cells { get; }

        public Map(Settings settings)
        {
            _settings = settings;

            Cells = new Cell[settings.HorizontalCells, settings.VerticalCells];

            for (int i = 0; i < settings.HorizontalCells; i++)
            {
                for (int j = 0; j < settings.VerticalCells; j++)
                {
                    Cells[i, j] = new Cell(new Location(i, j), true); //Make a map will all walls.
                }
            }

            MapGenerator.MineMazeRecursiveBacktracking(_settings.MapRandom, Cells);
        }

        public Path CalculatePath(Location startLoc, Location endLoc)
        {
            var path = new Path(startLoc,endLoc);

            FindPath(startLoc, path);

            return path;
        }

        private bool FindPath(Location loc, Path path)
        {
            if (loc == path.EndLocation)
            {
                path.VisitedCells.Add(Cells[loc.X, loc.Y]);
                path.FoundPath.Add(Cells[loc.X, loc.Y]);
                return true;
            }

            if (path.VisitedCells.Exists(x => x.Location == loc))
                return false;

            path.VisitedCells.Add(Cells[loc.X, loc.Y]);
            var neighbours = GetNeighbours(loc);

            if (neighbours.Any(newLoc => FindPath(newLoc, path)))
            {
                path.FoundPath.Add(Cells[loc.X,loc.Y]);
                return true;
            }

            return false;
        }

        private List<Location> GetNeighbours(Location loc)
        {
            var returnValue = new List<Location>();

            for (var i = loc.X - 1; i < loc.X + 2; i += 2)
            {
                if(!Cells[i,loc.Y].IsWall)
                    returnValue.Add(Cells[i,loc.Y].Location);
            }

            for (var i = loc.Y - 1; i < loc.Y + 2; i += 2)
            {
                if(!Cells[loc.X,i].IsWall)
                    returnValue.Add(Cells[loc.X,i].Location);
            }

            return returnValue;
        }

        /// <summary>
        /// Gets the cells within the view of a certain location.
        /// </summary>
        /// <param name="loc">Location which should be the center.</param>
        /// <returns>List with all the cells that are within view.</returns>
        public List<Cell> GetViewPort(Location loc) 
        {
            var returnValue = new List<Cell>();

            //Get an equal amount of cells left and right from the given center
            var xStart = loc.X > _settings.ViewWidth / 2 ? loc.X - _settings.ViewWidth / 2 : 0;
            var yStart = loc.Y > _settings.ViewHeight ? loc.Y - _settings.ViewHeight / 2 : 0;
            var xEnd = loc.X + _settings.ViewWidth / 2 < _settings.HorizontalCells ? loc.X + _settings.ViewWidth / 2 : _settings.HorizontalCells - 1;
            var yEnd = loc.Y + _settings.ViewHeight / 2 < _settings.HorizontalCells ? loc.Y + _settings.ViewHeight / 2 : _settings.VerticalCells - 1;

            for(int i = xStart; i <= xEnd; i++ )
            {
                for(int j = yStart; j <= yEnd; j++)
                {
                    returnValue.Add(Cells[i, j]);
                }
            }

            return returnValue;
        }

        /// <summary>
        /// Gets a random location from the map that is empty.
        /// </summary>
        /// <returns>The empty location.</returns>
        public Location GetEmptyLocation(Random rnd)
        {
            Location returnLocation;
            int tries = 0;           

            //Keep trying to find an empty location through luck, performance worsens when empty spaces are few.
            do
            {
                returnLocation = new Location(1, _settings.HorizontalCells, 1, _settings.VerticalCells, rnd);

                //Throw an exception when an empty location cannot be found.
                tries++;
                if(tries > _settings.HorizontalCells * _settings.VerticalCells)
                    throw new Exception("Cannot find empty location.");

            } while (!IsLocationEmpty(returnLocation));

            return returnLocation;
        }

        public bool IsLocationEmpty(Location loc)
        {
            return !Cells[loc.X, loc.Y].IsWall;
        }
	}
}