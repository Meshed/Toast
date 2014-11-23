using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ArenaStateManager : MonoBehaviour {
	public GameObject Fighter;
	public Text GameOver;
	public Button StartButton;
	public Button MainMenuButton;

	List<GameObject> _fighters = new List<GameObject>();
	List<GameObject> _enemies = new List<GameObject>();

	// Use this for initialization
	void Start () {
		Time.timeScale = 0.0f;

		// Create fighters
		GameObject fighter = (GameObject) GameObject.Instantiate (Fighter);
		fighter.GetComponentInChildren<HealthManager> ().FighterName = "Fighter 1";
		fighter.GetComponentInChildren<HealthManager> ().TeamPosition = 1;
		fighter.GetComponentInChildren<HealthManager> ().TeamNumber = 1;
		_fighters.Add (fighter);
		fighter = (GameObject) GameObject.Instantiate (Fighter);
		fighter.GetComponentInChildren<HealthManager> ().FighterName = "Fighter 2";
		fighter.GetComponentInChildren<HealthManager> ().TeamPosition = 2;
		fighter.GetComponentInChildren<HealthManager> ().TeamNumber = 1;
		_fighters.Add (fighter);

		// Create enemies
		var enemy = (GameObject) GameObject.Instantiate (Fighter);
		enemy.GetComponentInChildren<HealthManager> ().FighterName = "Enemy 1";
		enemy.GetComponentInChildren<HealthManager> ().TeamPosition = 1;
		enemy.GetComponentInChildren<HealthManager> ().TeamNumber = 2;
		_enemies.Add (enemy);
	}
	
	// Update is called once per frame
	void Update () {
		int healthForAllFighters = GetHealthForAllFighters ();
		int healthForAllEnemies = GetHealthForAllEnemies ();

		if(healthForAllFighters == 0 || healthForAllEnemies == 0)
		{
			Time.timeScale = 0.0f;

			if(healthForAllFighters == 0)
			{
				GameOver.text = "Game Over - You Lose";
			}
			else if(healthForAllEnemies == 0)
			{
				GameOver.text = "Game Over - You Win";
			}

			StartButton.gameObject.SetActive(true);
			MainMenuButton.gameObject.SetActive(true);
		}
	}

	public void StartFight()
	{
		// Reset player and enemy health
		Time.timeScale = 1.0f;
		StartButton.gameObject.SetActive (false);
		MainMenuButton.gameObject.SetActive (false);
		GameOver.text = "";
	}

	private int GetHealthForAllFighters()
	{
		int totalHealth = 0;

		foreach(var fighter in _fighters)
		{
			totalHealth += fighter.GetComponent<FighterStats>().Health;
		}

		return totalHealth;
	}
	private int GetHealthForAllEnemies()
	{
		int totalHealth = 0;
		
		foreach(var enemy in _enemies)
		{
			totalHealth += enemy.GetComponent<FighterStats>().Health;
		}
		
		return totalHealth;
	}
}
