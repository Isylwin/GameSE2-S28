﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
namespace WinFormsGame.Classes.EntityClasses
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
    using MapClasses;

	public class Player : Entity
	{
        public Path CheatsyDoodles { get; set; }

        public Player(Location loc) : base(loc)
        {
            Hitpoints = 100;
            Damage = 20;
        }

	    public void Move()
	    {
	        Location = new Location(Location.X + Vector.XAxis, Location.Y + Vector.YAxis);
	    }
	}
}

