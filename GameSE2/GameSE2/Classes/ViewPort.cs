using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WinFormsGame.Classes.EntityClasses;
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

        public void Draw(Graphics g, int cellSize, List<Bitmap> mapSprites, ImageList.ImageCollection entitySprites)
        {
            var xOffset = g.ClipBounds.Width / cellSize / 2 - CenterLocation.X; //in cells
            var yOffset = g.ClipBounds.Height / cellSize / 2 - CenterLocation.Y; //in cells

            foreach (var cell in Cells)
            {
                var image = cell.IsWall ? mapSprites[1] : mapSprites[0];
                g.DrawImage(image, (cell.Location.X + xOffset) * cellSize,
                    (cell.Location.Y + yOffset) * cellSize);
            }

            foreach (var entity in Entities)
            {
                Image image;

                if (entity is Player)
                    image = entitySprites[0];
                else if (entity is Enemy)
                    image = entitySprites[1];
                else if (entity is Arrow)
                    image = entitySprites[2 + (int)(entity as Arrow).Vector.VectorDirection];
                else
                    image = entitySprites[6]; //Make a no-texture exist texture.

                g.DrawImage(image, (entity.Location.X + xOffset) * cellSize,
                    (entity.Location.Y + yOffset) * cellSize);
            }
        }

    }
}

