﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WinFormsGame.Classes.MapClasses;
using WinFormsGame.Classes;

namespace WinFormsGameTestProject
{
    [TestClass]
    public class MapTesting
    {
        [TestMethod]
        public void CellCreation()
        {
            int _horizontalCells = 200;
            int _verticalCells = 200;

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
            Map map = new Map(new Settings());

            Assert.AreEqual(50, map.Cells[50, 176].Location.X, "Cell in incorrect X location");
            Assert.AreEqual(174, map.Cells[67, 174].Location.Y, "Cell in incorrect Y location");

            Assert.AreEqual(true, map.Cells[0, 17].IsWall, "0X BorderCell is not a wall");
            Assert.AreEqual(true, map.Cells[199, 89].IsWall, "maxX BorderCell is not a wall");
            Assert.AreEqual(true, map.Cells[106, 0].IsWall, "0Y BorderCell is not a wall");
            Assert.AreEqual(true, map.Cells[67, 199].IsWall, "maxY BorderCell is not a wall");
        }
    }
}