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
	public virtual int Hitpoints { get; protected set; }

	public virtual int Damage { get; protected set; }

	public virtual Location Location { get; private set; }

    public Entity(Location loc)
    {
        Location = loc;
    }

    public void TakeDamage(int Damage)
    {
        Hitpoints -= Damage;
    }

    public void Move(Location loc)
    {
        Location = loc;
    }

}

