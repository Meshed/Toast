using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class FighterService : MonoBehaviour 
{
	public static int HealthOfAllFighters()
	{
		int fighterHealth = 0;

		var fighters = GameObject.FindGameObjectsWithTag ("Fighter").ToList ();

		foreach(var fighter in fighters)
		{
			fighterHealth += fighter.GetComponentInChildren<FighterStats>().Health;
		}

		return fighterHealth;
	}
}
