using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsGame.Classes;
using WinFormsGame.Classes.MapClasses;

namespace WinFormsGame
{
    public partial class MainForm : Form
    {
        private const int HorizontalCells = 99;
        private const int VerticalCells = 99;
        private const int CellSize = 30;

        private readonly World _world;
        private readonly Settings _settings;

        private readonly Location _testLocation;

        public MainForm()
        {
            InitializeComponent();
            SetFullScreen();

            _settings = new Settings(VerticalCells, HorizontalCells, pbGame.Height, pbGame.Width, CellSize);
            _world = new World(_settings);

            _testLocation = new Location(15, 15);
        }

        private void SetFullScreen()
        {
            WindowState = FormWindowState.Normal;
            FormBorderStyle = FormBorderStyle.None;
            Bounds = Screen.PrimaryScreen.Bounds;
        }

        private void pbGame_Paint(object sender, PaintEventArgs e)
        {
            DrawWorld(e.Graphics,_world.GetViewToDraw(_testLocation));
        }

        private void DrawWorld(Graphics g, Drawable toDraw)
        {
            var xOffset = (_settings.ViewWidth / 2) - toDraw.CenterLocation.X; //in cells
            var yOffset = (_settings.ViewHeight / 2) - toDraw.CenterLocation.Y; //in cells

            foreach(var cell in toDraw.Cells)
            {
                var image = cell.IsWall ? ilMapItems.Images[1] : ilMapItems.Images[0];
                g.DrawImage(image, (cell.Location.X + xOffset) * _settings.CellSize, 
                    (cell.Location.Y + yOffset) * _settings.CellSize);
            }
        }

        private void MainForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch(e.KeyChar)
            {
                case 'a':
                    _testLocation.X--;
                    break;
                case 'd':
                    _testLocation.X++;
                    break;
                case 'w':
                    _testLocation.Y--;
                    break;
                case 's':
                    _testLocation.Y++;
                    break;
            }

            pbGame.Refresh();
        }
    }
}
