using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ArenaStateManager : MonoBehaviour {
	public GameObject Fighter;
	public Text GameOver;
	public Button StartButton;
	public Button MainMenuButton;

	public List<GameObject> Fighters = new List<GameObject>();
	public List<GameObject> Enemies = new List<GameObject>();

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
		int healthForAllEnemies = GetHealthForAllEnemies ();

		if(healthForAllFighters == 0)
		{
			Time.timeScale = 0.0f;

			if(healthForAllFighters == 0)
			{
				GameOver.text = "Game Over - You Lose";
			}

			StartButton.gameObject.SetActive(true);
			MainMenuButton.gameObject.SetActive(true);
		}
	}

	public void StartFight()
	{
		// Reset player and enemy health
		StartButton.gameObject.SetActive (false);
		MainMenuButton.gameObject.SetActive (false);
		GameOver.text = "";

		// Create enemies
		var enemy = (GameObject) GameObject.Instantiate (Fighter);
		enemy.GetComponentInChildren<FightManager> ().ArenaStateManager = this;
		enemy.GetComponentInChildren<HealthManager> ().FighterName = "Enemy 1";
		enemy.GetComponentInChildren<HealthManager> ().TeamPosition = 1;
		enemy.GetComponentInChildren<HealthManager> ().TeamNumber = 2;
		Enemies.Add (enemy);
		enemy = (GameObject) GameObject.Instantiate (Fighter);
		enemy.GetComponentInChildren<FightManager> ().ArenaStateManager = this;
		enemy.GetComponentInChildren<HealthManager> ().FighterName = "Enemy 2";
		enemy.GetComponentInChildren<HealthManager> ().TeamPosition = 2;
		enemy.GetComponentInChildren<HealthManager> ().TeamNumber = 2;
		Enemies.Add (enemy);

		Time.timeScale = 1.0f;
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
		
		foreach(var enemy in Enemies)
		{
			totalHealth += enemy.GetComponent<FighterStats>().Health;
		}
		
		return totalHealth;
	}
}
