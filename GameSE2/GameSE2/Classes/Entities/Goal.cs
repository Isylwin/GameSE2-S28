using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsGame.Classes.MapClasses;

namespace WinFormsGame.Classes.EntityClasses
{
    public class Goal : Entity
    {
        public Goal(Location loc) : base(loc)
        {
            Hitpoints = 999999;
            Damage = 0;
        }
    }
}
