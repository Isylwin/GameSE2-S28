using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsGame.Classes;
using WinFormsGame.Classes.EntityClasses;
using WinFormsGame.Classes.MapClasses;

namespace WinFormsGame
{
    public partial class MainForm : Form
    {
        //Constraints of the levelsize: needs to be atleast 17 big and an uneven number of cells.

        private const int HorizontalCells = 99;
        private const int VerticalCells = 99;
        private const int CellSize = 30;

        private readonly World _world;

        private readonly List<Keys> _keys; 

        public MainForm()
        {
            InitializeComponent();
            SetFullScreen();

            _world = new World(new Settings(VerticalCells, HorizontalCells, pbGame.Height, pbGame.Width, CellSize));
            _keys = new List<Keys>();

            GameTimer.Enabled = true;
        }

        private void SetFullScreen()
        {
            WindowState = FormWindowState.Normal;
            FormBorderStyle = FormBorderStyle.None;
            Bounds = Screen.PrimaryScreen.Bounds;
        }

        private void pbGame_Paint(object sender, PaintEventArgs e)
        {
            DrawWorld(e.Graphics,_world.GetViewToDraw());
        }

        private void DrawWorld(Graphics g, ViewPort toDraw)
        {
            var xOffset = pbGame.Width / CellSize / 2 - toDraw.CenterLocation.X; //in cells
            var yOffset = pbGame.Height / CellSize / 2 - toDraw.CenterLocation.Y; //in cells

            foreach(var cell in toDraw.Cells)
            {
                var image = cell.IsWall ? ilMapItems.Images[1] : ilMapItems.Images[0];
                g.DrawImage(image, (cell.Location.X + xOffset) * CellSize, 
                    (cell.Location.Y + yOffset) * CellSize);
            }

            foreach (var entity in toDraw.Entities)
            {
                Image image;

                if (entity is Player)
                    image = ilEntities.Images[0];
                else if (entity is Enemy)
                    image = ilEntities.Images[1];
                else
                    image = null;

                g.DrawImage(image, (entity.Location.X + xOffset) * CellSize,
                    (entity.Location.Y + yOffset) * CellSize);
            }
        }

        private void Update(object sender, EventArgs e)
        {
            _world.Update(_keys);
            pbGame.Refresh();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (!_keys.Exists(x => x == e.KeyCode))
                _keys.Add(e.KeyCode);
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            _keys.RemoveAll(x => x == e.KeyCode);
        }
    }
}


//TODO add test code for random map generation.
//TODO add test code for entity creation.