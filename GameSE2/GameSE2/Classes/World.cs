using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using WinFormsGame.Classes.MapClasses;
using WinFormsGame.Classes.EntityClasses;

namespace WinFormsGame.Classes
{
    public class World
    {
        private readonly Settings _settings;

        //public int Score { get; }
        
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
        public void Update()
        {
            throw new System.NotImplementedException();
        }

        private void MovePlayer()
        {
            throw new System.NotImplementedException();
        }

        private void MoveArrows()
        {
            throw new System.NotImplementedException();
        }

        public Drawable GetViewToDraw(Location loc)
        {
            var cellsToDraw = Level.Map.GetViewPort(loc);

            return new Drawable(cellsToDraw, null, loc);
        }

        private void CreateNewLevel()
        {
            Level = new Level(_settings, LevelNumber);
        }

    }
}

//TODO make sure entities are also giving to the drawable.