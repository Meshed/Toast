using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class MonsterService : MonoBehaviour {
	public static List<GameObject> GetAllMonsters()
	{
		var monsters = GameObject.FindGameObjectsWithTag ("Monster").ToList ();

		return monsters;
	}

	public static int CountOfAllMonsters()
	{
		var monsters = GetAllMonsters ();

		return monsters.Count;
	}
}
