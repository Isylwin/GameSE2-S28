﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Settings
{
	public virtual int VerticalCells { get; }

	public virtual int HorizontalCells { get; }

	public virtual int CellSize { get; }

	public virtual int Seed { get; }

    /// <summary>
    /// Measured in cells
    /// </summary>
	public virtual int ViewHeight { get; }

    /// <summary>
    /// Measured in cells
    /// </summary>
	public virtual int ViewWidth { get; }

    public Settings(int verticalCells, int horizontalCells, int displayHeight, int displayWidth, int cellSize)
    {
        VerticalCells = verticalCells;
        HorizontalCells = horizontalCells;
        CellSize = cellSize;

        ViewHeight = displayHeight/CellSize;
        ViewWidth = displayWidth/CellSize;       
    }

}

