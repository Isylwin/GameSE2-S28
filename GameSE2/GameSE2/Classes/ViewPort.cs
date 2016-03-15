using System.Collections.Generic;
using WinFormsGame.Classes.MapClasses;

namespace WinFormsGame.Classes
{
    /// <summary>
    /// Class used to determine everything that needs to be rendered by the computer.
    /// </summary>
    public class ViewPort
    {
        /// <summary>
        /// The cells that lie within the view port.
        /// </summary>
        public List<Cell> Cells { get; }

        /// <summary>
        /// The entities that exist within the view port.
        /// </summary>
        public List<Entity> Entities { get; }

        /// <summary>
        /// The center location of the view port.
        /// </summary>
        public Location CenterLocation { get;}

        public ViewPort(List<Cell> cells, List<Entity> entities, Location loc)
        {
            Cells = cells;
            Entities = entities;
            CenterLocation = loc;
        }

    }
}

