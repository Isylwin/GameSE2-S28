using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WinFormsGame.Classes.MapClasses;
using WinFormsGame.Classes.EntityClasses;

namespace WinFormsGame.Classes
{
    public class World
    {
        private List<Entity> Entities;

        private Player _player { get
            {
                return null;
            } }

        private Enemy _enemies { get
            {
                return null;
            } }

        private Arrow _arrows { get
            {
                return null;
            } }

        public virtual int Score { get; set; }

        public virtual Map Map { get; set; }

        public virtual Settings Settings { get; set; }

        public virtual Level Level { get; set; }

        public virtual List<PowerUp> PowerUps { get; set; }

        public World(Settings settings)
        {

        }
        
        /// <summary>
        /// Needs the keys from the form that are currently active.
        /// </summary>
        public virtual void Update()
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

    }
}



