using UnityEngine;
using System.Linq;

public class FighterService : MonoBehaviour
{
    private readonly GameObject _fighter;

    public FighterService(GameObject fighter)
    {
        _fighter = fighter;
    }

    public GameObject CreateFighter(ArenaStateManager arenaStateManager, string fighterName, int teamPosition)
    {
        var fighter = (GameObject)Instantiate(_fighter);
        fighter.GetComponentInChildren<FightManager>().ArenaStateManager = arenaStateManager;
        fighter.GetComponentInChildren<HealthManager>().FighterName = fighterName;
        fighter.GetComponentInChildren<HealthManager>().TeamPosition = teamPosition;
        fighter.GetComponentInChildren<HealthManager>().TeamNumber = 1;

        return fighter;
    }

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
