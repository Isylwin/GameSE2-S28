namespace GameSE2.Classes.MapClasses
{
    public class Vector
    {
        public int XAxis { get; set; }

        public int YAxis { get; set; }

        public override string ToString()
        {
            if (XAxis != 0)
                return XAxis > 0 ? "East" : "West";
            if (YAxis != 0)
                return YAxis > 0 ? "South" : "North";

            return "No vector";
        }
    }
}
