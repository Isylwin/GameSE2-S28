using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;
using WinFormsGame.Classes.MapClasses;
using WinFormsGame.Classes.EntityClasses;

namespace WinFormsGame.Classes
{
    public class World
    {
        private readonly Settings _settings;
        
        public int LevelNumber { get; }     

        public Level Level { get; private set; }

        public World(Settings settings)
        {
            _settings = settings;

            LevelNumber = 1;           
            CreateNewLevel();           
        }
        
        /// <summary>
        /// Needs the keys from the form that are currently active.
        /// </summary>
        public void Update(List<Keys> keys)
        {
            MovePlayer(keys);
        }

        private void MovePlayer(List<Keys> keys)
        {
            var xAxis = 0;
            var yAxis = 0;
            Location newLoc;

            if (keys.Exists(x => x == Keys.D))
                xAxis++;
            if (keys.Exists(x => x == Keys.A))
                xAxis--;

            newLoc = new Location(Level.Player.Location.X + xAxis, Level.Player.Location.Y);

            if(Level.Map.IsLocationEmpty(newLoc))
                Level.Player.Move(newLoc);

            if (keys.Exists(x => x == Keys.S))
                yAxis++;
            if (keys.Exists(x => x == Keys.W))
                yAxis--;

            newLoc = new Location(Level.Player.Location.X, Level.Player.Location.Y + yAxis);

            if(Level.Map.IsLocationEmpty(newLoc))
                Level.Player.Move(newLoc);
        }

        public ViewPort GetViewToDraw()
        {
            return Level.ViewPort;
        }

        private void CreateNewLevel()
        {
            Level = new Level(_settings, LevelNumber);
        }

    }
}

//TODO make sure entities are also giving to the drawable.