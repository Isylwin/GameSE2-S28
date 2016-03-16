using System;

namespace WinFormsGame.Classes.MapClasses
{
    public class Vector
    {
        public int XAxis { get;}

        public int YAxis { get;}

        public int Speed => Math.Abs(XAxis + YAxis);

        public VectorDirection VectorDirection { get; }

        public Vector(int x, int y)
        {
            XAxis = x;
            YAxis = y;

            if (XAxis < 0)
                VectorDirection = VectorDirection.West;
            else if (XAxis > 0)
                VectorDirection = VectorDirection.East;
            else if(YAxis < 0)
                VectorDirection = VectorDirection.North;
            else if(YAxis > 0)
                VectorDirection = VectorDirection.South;
            else
                throw new Exception("Incorrect vector.");
        }
    }

    public enum VectorDirection
    {
        West = 0,
        East = 1,
        North = 2,
        South = 3
    }
}