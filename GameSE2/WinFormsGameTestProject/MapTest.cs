using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WinFormsGame;
using WinFormsGame.Classes.MapClasses;
using WinFormsGame.Classes;

namespace WinFormsGameTestProject
{
    [TestClass]
    public class MapTest
    {
        private Settings _settings = new Settings(199, 199, 30, 930, 930);
        private Map map;
        private Cell[,] testCells;

        public MapTest()
        {
            map = new Map(_settings);

            testCells = new Cell[_settings.HorizontalCells,_settings.VerticalCells];

            for (int i = 0; i < _settings.HorizontalCells; i++)
            {
                for (int j = 0; j < _settings.VerticalCells; j++)
                {
                    testCells[i, j] = new Cell(new Location(i, j), true); //Make a map will all walls.
                }
            }
        }
        

        [TestMethod]
        public void CellCreation()
        {
            int _horizontalCells = _settings.HorizontalCells;
            int _verticalCells = _settings.VerticalCells;

            Cell[,] Cells = new Cell[_horizontalCells , _verticalCells];

            for (int i = 0; i < _horizontalCells; i++)
            {
                for (int j = 0; j < _verticalCells; j++)
                {
                    Cells[i,j] = new Cell(new Location(i, j));
                    if (i % 2 == 0) Cells[i, j].IsWall = true;
                }
            }

            Assert.AreEqual(50, Cells[50, 176].Location.X, "Cell in incorrect X location");
            Assert.AreEqual(174, Cells[67, 174].Location.Y, "Cell in incorrect Y location");

            Assert.AreEqual("(51,176) Empty", Cells[51, 176].ToString(), "Cell.ToString() incorrect");
            Assert.AreEqual("(50,176) Wall", Cells[50, 176].ToString(), "Cell.ToString() incorrect");

            Assert.AreNotEqual(39, Cells[45, 65].Location.X);
        }

        [TestMethod]
        public void MapCreation()
        {
            Assert.AreEqual(50, map.Cells[50, 176].Location.X, "Cell in incorrect X location");
            Assert.AreEqual(174, map.Cells[67, 174].Location.Y, "Cell in incorrect Y location");

            Assert.AreEqual(true, map.Cells[0, 17].IsWall, "0X BorderCell is not a wall");
            Assert.AreEqual(true, map.Cells[198, 89].IsWall, "maxX BorderCell is not a wall");
            Assert.AreEqual(true, map.Cells[106, 0].IsWall, "0Y BorderCell is not a wall");
            Assert.AreEqual(true, map.Cells[67, 198].IsWall, "maxY BorderCell is not a wall");
        }

        [TestMethod]
        public void LocationTests()
        {
            var a = new Location(76,12);
            var b = new Location(31,76);
            var c = new Location(76,12);
            Location d = null;

            Assert.AreEqual(true, a == c, "== success incorrect");
            Assert.AreEqual(true, a != b, "!= success incorrect");
            Assert.AreEqual(false, b == a, "== fail incorrect");
            Assert.AreEqual(false, d == a, "Null reference not caught");
        }

        [TestMethod]
        public void MapGeneratePerformance()
        {
            MapGenerator.MineMazeRecursiveBacktracking(_settings.MapRandom, testCells);
        }

        [TestMethod]
        public void CheckPathFinding()
        {
            foreach (var path in from Cell cell in map.Cells where !cell.IsWall && cell.Location != new Location(1,1) select map.CalculatePath(cell.Location, new Location(1, 1)))
            {
                Assert.IsTrue(path.FoundPath.Count > 0, "No Path found");
                Assert.IsFalse(path.FoundPath.Exists(x => x.IsWall), "Path uses invalid cell");
            }
        }
    }
}
