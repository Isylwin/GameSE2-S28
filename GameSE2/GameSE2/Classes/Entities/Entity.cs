using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WinFormsGame.Classes.MapClasses;

/// <summary>
/// Entities that can exist within the game
/// </summary>
/// <remarks>See entity diagram for childs</remarks>
public abstract class Entity
{
	/// <summary>
	/// Amount of hitpoints
	/// </summary>
	public int Hitpoints { get; protected set; }

	public int Damage { get; protected set; }

	public Location Location { get; protected set; }

    public Vector Vector { get; protected set; }

    public Entity(Location loc)
    {
        Location = loc;
        Vector = new Vector(1,0);
    }

    public void TakeDamage(int Damage)
    {
        Hitpoints -= Damage;
    }

    public virtual void Move(Location loc)
    {
        Location = loc;
    }

}

