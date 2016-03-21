using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinFormsGame.Classes.MapClasses;
using WinFormsGame.Classes.EntityClasses;

namespace WinFormsGame.Classes
{
    public class World
    {
        private readonly Settings _settings;

        public event EventHandler GameOver;
        
        public int LevelNumber { get; private set; }     

        public Level Level { get; private set; }

        public World(Settings settings)
        {
            _settings = settings;

            LevelNumber = 0;           
            CreateNewLevel();           
        }
        
        /// <summary>
        /// Needs the keys from the form that are currently active.
        /// </summary>
        public void Update(List<Keys> keys)
        {
            MoveArrows();
            HandleKeyInput(keys);
            CheckForGameEnd();
            Level.RemoveDeadEntities();
        }

        private void MoveArrows()
        { 
            foreach (var arrow in Level.Arrows)
            {
                Location newloc;

                for (var i = 0; i < arrow.Vector.Speed; i++)
                {
                    newloc = new Location(arrow.Location.X + arrow.Vector.XAxis / arrow.Vector.Speed, arrow.Location.Y + arrow.Vector.YAxis / arrow.Vector.Speed);

                    if (Level.CheckArrowHit(arrow, newloc))
                        arrow.Move(newloc);
                    else
                        break;
                }
            }
        }

        private void HandleKeyInput(List<Keys> keys)
        {
            if (keys.Exists(x => x == Keys.D) && Level.Player.Vector.VectorDirection == VectorDirection.East)
                Level.MovePlayer();
            else if (keys.Exists(x => x == Keys.D) && Level.Map.IsLocationEmpty(new Location(Level.Player.Location.X + 1, Level.Player.Location.Y)))
                Level.Player.Vector.VectorDirection = VectorDirection.East;

            if (keys.Exists(x => x == Keys.A) && Level.Player.Vector.VectorDirection == VectorDirection.West)
                Level.MovePlayer();
            else if (keys.Exists(x => x == Keys.A) && Level.Map.IsLocationEmpty(new Location(Level.Player.Location.X - 1, Level.Player.Location.Y)))
                Level.Player.Vector.VectorDirection = VectorDirection.West;

            if (keys.Exists(x => x == Keys.S) && Level.Player.Vector.VectorDirection == VectorDirection.South)
                Level.MovePlayer();
            else if (keys.Exists(x => x == Keys.S) && Level.Map.IsLocationEmpty(new Location(Level.Player.Location.X, Level.Player.Location.Y + 1)))
                Level.Player.Vector.VectorDirection = VectorDirection.South;

            if (keys.Exists(x => x == Keys.W) && Level.Player.Vector.VectorDirection == VectorDirection.North)
                Level.MovePlayer();
            else if (keys.Exists(x => x == Keys.W) && Level.Map.IsLocationEmpty(new Location(Level.Player.Location.X, Level.Player.Location.Y - 1)))
                Level.Player.Vector.VectorDirection = VectorDirection.North;

            if (keys.Exists(x => x == Keys.T))
                Level.Player.CheatsyDoodles = Level.Map.CalculatePath(Level.Player.Location, Level.Goal.Location);

            if (keys.Exists(x => x == Keys.J) && Level.Player.CheatsyDoodles != null 
                && Level.Player.CheatsyDoodles.FoundPath.Last().Location == Level.Player.Location && Level.Player.Location != Level.Player.CheatsyDoodles.EndLocation)
            {
                Level.Player.Move(Level.Player.CheatsyDoodles.FoundPath[Level.Player.CheatsyDoodles.FoundPath.Count - 2].Location);
                Level.Player.CheatsyDoodles.FoundPath.Remove(Level.Player.CheatsyDoodles.FoundPath.Last());
                
            }

            if (keys.Exists(x => x == Keys.Space))
            {
                Level.CreateArrow();
            }
        }

        private void CheckForGameEnd()
        {
            if (Level.Player.Location == Level.Goal.Location && GameOver != null)
            {
                GameOver(new object(), new EventArgs());
            }
        }

        public ViewPort GetViewToDraw()
        {
            return Level.ViewPort;
        }

        public void CreateNewLevel()
        {
            LevelNumber++;
            Level = new Level(_settings, LevelNumber);
        }

    }
}

//TODO make sure entities are also giving to the drawable.