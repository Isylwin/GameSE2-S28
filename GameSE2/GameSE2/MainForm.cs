using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        private World _world;
        private Settings _settings;

        private Location testLocation;

        public MainForm()
        {
            _settings = new Settings();
            _world = new World(_settings);

            testLocation = new Location(15, 15);

            InitializeComponent();
            SetFullScreen();
        }

        private void SetFullScreen()
        {
            this.WindowState = FormWindowState.Normal;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Bounds = Screen.PrimaryScreen.Bounds;
        }

        private void pbGame_Paint(object sender, PaintEventArgs e)
        {
            DrawWorld(e.Graphics,_world.GetViewToDraw(testLocation));
        }

        private void DrawWorld(Graphics g, Drawable toDraw)
        {
            int xOffset = (_settings.ViewWidth / 2) - toDraw.CenterLocation.X; //in cells
            int yOffset = (_settings.ViewHeight / 2) - toDraw.CenterLocation.Y; //in cells

            foreach(Cell cell in toDraw.Cells)
            {
                Image image = cell.IsWall ? ilMapItems.Images[1] : ilMapItems.Images[0];
                g.DrawImage(image, (cell.Location.X + xOffset) * _settings.CellSize, 
                    (cell.Location.Y + yOffset) * _settings.CellSize);
            }
        }

        private void MainForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch(e.KeyChar)
            {
                case 'a':
                    testLocation.X--;
                    break;
                case 'd':
                    testLocation.X++;
                    break;
                case 'w':
                    testLocation.Y--;
                    break;
                case 's':
                    testLocation.Y++;
                    break;
            }

            pbGame.Refresh();
        }
    }
}
