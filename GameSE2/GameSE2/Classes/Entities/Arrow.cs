using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WinFormsGame.Classes.MapClasses;

namespace WinFormsGame.Classes.EntityClasses
{
    public class Arrow : Entity
    {
        public Vector Vector { get; }

        public Arrow(Location loc, Vector vector) : base(loc)
        {
            Vector = vector;
            Hitpoints = 1;
            Damage = 10;
        }
    }
}

