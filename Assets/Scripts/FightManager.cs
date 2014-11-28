using UnityEngine;
using System.Collections;

public class FightManager : MonoBehaviour {
	public ArenaStateManager ArenaStateManager;

	FighterStats _fighterStats;
	HealthManager _healthManager;
	float _attackDelay = 1f;
	float _attackTimer = 0f;
	public GameObject _enemy;

	// Use this for initialization
	void Start () {
		_fighterStats = this.GetComponent<FighterStats> ();
		_healthManager = this.GetComponentInChildren<HealthManager> ();
		_attackTimer = _attackDelay;
	}
	
	// Update is called once per frame
	void Update () {
		if(_fighterStats.Health <= 0) return;
		if(Time.timeScale == 0) return;

		_attackTimer -= Time.deltaTime;
		_enemy = null;

		if (_attackTimer < 0) 
		{
			if(_healthManager.TeamNumber == 1)
			{
				int enemyIndex;

				int monsterCount = MonsterService.CountOfAllMonsters();
				if(monsterCount > 0)
				{
					enemyIndex = MonsterService.CountOfAllMonsters() == 1 ? 0 : Random.Range(0, MonsterService.CountOfAllMonsters());
					_enemy = MonsterService.GetAllMonsters()[enemyIndex];
				}
			}
			else
			{
				if(FighterService.HealthOfAllFighters() > 0)
				{
					if(ArenaStateManager.Fighters.Count == 1)
					{
						_enemy = ArenaStateManager.Fighters[0];
					}
					else
					{
						do
						{
							int enemyIndex = Random.Range (0, ArenaStateManager.Fighters.Count);
							_enemy = ArenaStateManager.Fighters[enemyIndex];
						} while(_enemy.GetComponent<FighterStats>().Health <= 0);
					}
				}

			}

			if(_enemy)
			{
				DamageManager _enemyDamageManager = _enemy.GetComponent<DamageManager>();
			
				if(_enemyDamageManager)
					_enemyDamageManager.TakeDamage(_fighterStats.Attack);
			}

			_attackTimer = _attackDelay;
		}
	}
}
