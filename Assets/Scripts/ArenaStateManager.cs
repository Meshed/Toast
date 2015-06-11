using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ArenaStateManager : MonoBehaviour {
	public GameObject Fighter;
	public GameObject Monster;
	public Text GameOver;
	public Button StartButton;
	public Button MainMenuButton;
	public Text Wave;

	public List<GameObject> Fighters = new List<GameObject>();

    private FighterService _fighterService;
    private MonsterService _monsterService;
	int _monsterWave = 1;

	// Use this for initialization
	void Start () {
		Time.timeScale = 0.0f;
        _fighterService = new FighterService(Fighter);
        _monsterService = new MonsterService(Monster);

		// Create fighters
		var fighter = _fighterService.CreateFighter(this, "Fighter 1", 1);
	    Fighters.Add (fighter);
	    fighter = _fighterService.CreateFighter(this, "Fighter 2", 2);
		Fighters.Add (fighter);
	    fighter = _fighterService.CreateFighter(this, "Fighter 3", 3);
		Fighters.Add (fighter);
	    fighter = _fighterService.CreateFighter(this, "Fighter 4", 4);
		Fighters.Add (fighter);
	}

    // Update is called once per frame
	void Update () {
		if(FightCompleted())
		{
			EndFight();
		}

		if(WaveCompleted())
		{
		    _monsterWave++;
		    CreateMonsterWave();
		}

	    UpdateWaveLabel ();
	}

    private void EndFight()
    {
        Time.timeScale = 0.0f;

        if (_monsterWave <= 2)
            GameOver.text = "You have completed " + (_monsterWave - 1) + " wave";
        else
            GameOver.text = "You have completed " + (_monsterWave - 1) + " waves";

        MainMenuButton.gameObject.SetActive(true);
    }
    private bool FightCompleted()
    {
        return FighterService.HealthOfAllFighters() == 0;
    }
    private void CreateMonsterWave()
    {
        if (_monsterWave <= 4)
        {
            for (int counter = 1; counter <= _monsterWave; counter++)
            {
                _monsterService.CreateMonster(this, "Monster " + counter, counter);
            }
        }
        else
        {
            _monsterService.CreateMonster(this, "Monster 1", 1);
            _monsterService.CreateMonster(this, "Monster 2", 2);
            _monsterService.CreateMonster(this, "Monster 3", 3);
            _monsterService.CreateMonster(this, "Monster 4", 4);
        }
    }
    private static bool WaveCompleted()
    {
        return MonsterService.HealthOfAllMonsters() == 0 && Time.timeScale == 1.0f;
    }
    private void UpdateWaveLabel()
    {
        Wave.text = "Wave: " + _monsterWave;
    }

    public void StartFight()
	{
		// Reset player and enemy health
		StartButton.gameObject.SetActive (false);
		MainMenuButton.gameObject.SetActive (false);
		GameOver.text = "";

		// Create monsters
		_monsterService.CreateMonster (this, "Monster 1", 1);

		Time.timeScale = 1.0f;
	}
}
