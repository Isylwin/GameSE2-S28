using System;

namespace WinFormsGame.Classes.MapClasses
{
    public class Vector
    {
        public int XAxis { get; private set; }

        public int YAxis { get; private set; }

        public int Speed => Math.Abs(XAxis + YAxis);

        public VectorDirection VectorDirection
        {
            get
            {
                if (XAxis < 0)
                    return VectorDirection.West;
                if (XAxis > 0)
                    return VectorDirection.East;
                if (YAxis < 0)
                    return VectorDirection.North;
                if (YAxis > 0)
                    return VectorDirection.South;
               
                    throw new Exception("Incorrect vector.");
            }

            set
            {
                switch (value)
                {
                    case VectorDirection.East:
                        XAxis = 1;
                        YAxis = 0;
                        break;
                    case VectorDirection.West:
                        XAxis = -1;
                        YAxis = 0;
                        break;
                    case VectorDirection.South:
                        XAxis = 0;
                        YAxis = 1;
                        break;
                    case VectorDirection.North:
                        XAxis = 0;
                        YAxis = -1;
                        break;
                }
            }
        }

        public Vector(int x, int y)
        {
            XAxis = x;
            YAxis = y;

            
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