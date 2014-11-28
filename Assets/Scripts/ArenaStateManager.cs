using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ArenaStateManager : MonoBehaviour {
	public GameObject Fighter;
	public GameObject Monster;
	public Text GameOver;
	public Button StartButton;
	public Button MainMenuButton;
	public Text Wave;

	public List<GameObject> Fighters = new List<GameObject>();

	int _monsterWave = 1;

	// Use this for initialization
	void Start () {
		Time.timeScale = 0.0f;

		// Create fighters
		GameObject fighter = (GameObject) GameObject.Instantiate (Fighter);
		fighter.GetComponentInChildren<FightManager> ().ArenaStateManager = this;
		fighter.GetComponentInChildren<HealthManager> ().FighterName = "Fighter 1";
		fighter.GetComponentInChildren<HealthManager> ().TeamPosition = 1;
		fighter.GetComponentInChildren<HealthManager> ().TeamNumber = 1;
		Fighters.Add (fighter);
		fighter = (GameObject) GameObject.Instantiate (Fighter);
		fighter.GetComponentInChildren<FightManager> ().ArenaStateManager = this;
		fighter.GetComponentInChildren<HealthManager> ().FighterName = "Fighter 2";
		fighter.GetComponentInChildren<HealthManager> ().TeamPosition = 2;
		fighter.GetComponentInChildren<HealthManager> ().TeamNumber = 1;
		Fighters.Add (fighter);
		fighter = (GameObject) GameObject.Instantiate (Fighter);
		fighter.GetComponentInChildren<FightManager> ().ArenaStateManager = this;
		fighter.GetComponentInChildren<HealthManager> ().FighterName = "Fighter 3";
		fighter.GetComponentInChildren<HealthManager> ().TeamPosition = 3;
		fighter.GetComponentInChildren<HealthManager> ().TeamNumber = 1;
		Fighters.Add (fighter);
		fighter = (GameObject) GameObject.Instantiate (Fighter);
		fighter.GetComponentInChildren<FightManager> ().ArenaStateManager = this;
		fighter.GetComponentInChildren<HealthManager> ().FighterName = "Fighter 4";
		fighter.GetComponentInChildren<HealthManager> ().TeamPosition = 4;
		fighter.GetComponentInChildren<HealthManager> ().TeamNumber = 1;
		Fighters.Add (fighter);
	}
	
	// Update is called once per frame
	void Update () {
		int healthForAllFighters = GetHealthForAllFighters ();
		int healthForAllMonsters = GetHealthForAllEnemies ();

		if(healthForAllFighters == 0)
		{
			Time.timeScale = 0.0f;

			if(healthForAllFighters == 0)
			{
				if(_monsterWave <= 2)
					GameOver.text = "You have completed " + (_monsterWave - 1) + " wave";
				else
					GameOver.text = "You have completed " + (_monsterWave - 1) + " waves";
			}

			MainMenuButton.gameObject.SetActive(true);
		}

		if(healthForAllMonsters == 0 && Time.timeScale == 1.0f)
		{
			_monsterWave++;

			if(_monsterWave <= 4)
			{
				for(int counter = 1; counter <= _monsterWave; counter++)
				{
					CreateMonster("Monster " + counter, counter);
				}
			}
			else
			{
				CreateMonster("Monster 1", 1);
				CreateMonster("Monster 2", 2);
				CreateMonster("Monster 3", 3);
				CreateMonster("Monster 4", 4);
			}
		}

		UpdateWaveLabel ();
	}

	public void StartFight()
	{
		// Reset player and enemy health
		StartButton.gameObject.SetActive (false);
		MainMenuButton.gameObject.SetActive (false);
		GameOver.text = "";

		// Create monsters
		CreateMonster ("Monster 1", 1);

		Time.timeScale = 1.0f;
	}

	private void UpdateWaveLabel()
	{
		Wave.text = "Wave: " + _monsterWave;
	}

	private void CreateMonster(string monsterName, int teamPosition)
	{
		var monster = (GameObject) GameObject.Instantiate (Monster);
		monster.GetComponentInChildren<FightManager> ().ArenaStateManager = this;
		monster.GetComponentInChildren<HealthManager> ().FighterName = monsterName;
		monster.GetComponentInChildren<HealthManager> ().TeamPosition = teamPosition;
	}

	private int GetHealthForAllFighters()
	{
		int totalHealth = 0;

		foreach(var fighter in Fighters)
		{
			totalHealth += fighter.GetComponent<FighterStats>().Health;
		}

		return totalHealth;
	}
	private int GetHealthForAllEnemies()
	{
		int totalHealth = 0;

		List<GameObject> monsters = MonsterService.GetAllMonsters ();
		
		foreach(var monster in monsters)
		{
			totalHealth += monster.GetComponent<FighterStats>().Health;
		}
		
		return totalHealth;
	}
}
