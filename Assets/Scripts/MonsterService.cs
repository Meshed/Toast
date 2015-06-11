using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class MonsterService : MonoBehaviour
{
    private readonly GameObject _monster;

    public MonsterService(GameObject monster)
    {
        _monster = monster;
    }

    public GameObject CreateMonster(ArenaStateManager arenaStateManager, string monsterName, int teamPosition)
    {
        var monster = (GameObject)Instantiate(_monster);
        monster.GetComponentInChildren<FightManager>().ArenaStateManager = arenaStateManager;
        monster.GetComponentInChildren<HealthManager>().FighterName = monsterName;
        monster.GetComponentInChildren<HealthManager>().TeamPosition = teamPosition;

        return monster;
    }

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
    public static int HealthOfAllMonsters()
    {
        List<GameObject> monsters = GetAllMonsters();

        return monsters.Sum(monster => monster.GetComponent<FighterStats>().Health);
    }
}
