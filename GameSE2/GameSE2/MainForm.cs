using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsGame.Classes;
using WinFormsGame.Classes.EntityClasses;

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

        private readonly List<Bitmap> _mapSprites;
        private readonly List<Bitmap> _entitySprites; 

        public MainForm()
        {
            InitializeComponent();
            SetFullScreen();

            pbGame.Width = Bounds.Width;
            pbGame.Height = Bounds.Height;
            pbGame.Location = new Point(0,0);

            _world = new World(new Settings(VerticalCells, HorizontalCells, pbGame.Height, pbGame.Width, CellSize));
            _keys = new List<Keys>();
            _mapSprites = new List<Bitmap>();
            _entitySprites = new List<Bitmap>();

            GameTimer.Enabled = true;

            _world.GameOver += _world_GameOver;

            Load_Content();
        }

        private void _world_GameOver(object sender, EventArgs e)
        {
            GameTimer.Enabled = false;
            _keys.Clear();
            MessageBox.Show("SUPER AWESOME! DAT BEN JIJJJJJ");
            _world.CreateNewLevel();
            GameTimer.Enabled = true;
        }

        private void SetFullScreen()
        {
            WindowState = FormWindowState.Normal;
            FormBorderStyle = FormBorderStyle.None;
            Bounds = Screen.PrimaryScreen.Bounds;
        }

        private void Load_Content()
        {
            _mapSprites.Add(Properties.Resources.Floor30x30_v2);
            _mapSprites.Add(Properties.Resources.Wall30x30_v3);

            _entitySprites.Add(Properties.Resources.Player_v2);
            _entitySprites.Add(Properties.Resources.Skeleton_v1);
            _entitySprites.Add(Properties.Resources.Arrow30x30_vFinalWest);
            _entitySprites.Add(Properties.Resources.Arrow30x30_vFinalEast);
            _entitySprites.Add(Properties.Resources.Arrow30x30_vFinalNorth);
            _entitySprites.Add(Properties.Resources.Arrow30x30_vFinalSouth);

            _entitySprites.ForEach(bitmap => bitmap.MakeTransparent(Color.White));
        }

        private void pbGame_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;

            g.SmoothingMode = SmoothingMode.HighSpeed;
            g.InterpolationMode = InterpolationMode.HighQualityBilinear;
            g.CompositingQuality = CompositingQuality.HighSpeed;
            g.CompositingMode = CompositingMode.SourceOver;
            g.PixelOffsetMode = PixelOffsetMode.HighSpeed;
            
            _world.GetViewToDraw().Draw(g, CellSize, _mapSprites, ilEntities.Images);
        }

        //private void DrawWorld(Graphics g, ViewPort toDraw)
        //{
        //    var xOffset = pbGame.Width / CellSize / 2 - toDraw.CenterLocation.X; //in cells
        //    var yOffset = pbGame.Height / CellSize / 2 - toDraw.CenterLocation.Y; //in cells

        //    foreach(var cell in toDraw.FoundPath)
        //    {
        //        var image = cell.IsWall ? _mapSprites[1] : _mapSprites[0];
        //        g.DrawImage(image, (cell.Location.X + xOffset) * CellSize, 
        //            (cell.Location.Y + yOffset) * CellSize);
        //    }

        //    foreach (var entity in toDraw.Entities)
        //    {
        //        Image image;

        //        if (entity is Player)
        //            image = ilEntities.Images[0];
        //        else if (entity is Enemy)
        //            image = ilEntities.Images[1];
        //        else if (entity is Arrow)
        //            image = ilEntities.Images[2 + (int) (entity as Arrow).Vector.VectorDirection];
        //        else
        //            image = ilEntities.Images[6]; //Make a no-texture exist texture.

        //        g.DrawImage(image, (entity.Location.X + xOffset) * CellSize,
        //            (entity.Location.Y + yOffset) * CellSize);
        //    }
        //}

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