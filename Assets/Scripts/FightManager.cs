using UnityEngine;
using System.Collections;

public class FightManager : MonoBehaviour {
	public ArenaStateManager ArenaStateManager;

	FighterStats _fighterStats;
	HealthManager _healthManager;
	float _attackDelay = 1f;
	float _attackTimer = 0f;
	GameObject _enemy;

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

		if(_healthManager.TeamNumber == 1)
		{
			int enemyIndex;

			enemyIndex = ArenaStateManager.Enemies.Count == 1 ? 0 : Random.Range(0, ArenaStateManager.Enemies.Count);
			_enemy = ArenaStateManager.Enemies[enemyIndex];
		}
		else
		{
			if(ArenaStateManager.Fighters.Count == 1)
			{
				_enemy = ArenaStateManager.Fighters[0];
			}
			else
			{
				int enemyIndex = Random.Range (0, ArenaStateManager.Fighters.Count);
				_enemy = ArenaStateManager.Fighters[enemyIndex];
			}
		}

		if (_attackTimer < 0) 
		{
			DamageManager _enemyDamageManager = _enemy.GetComponent<DamageManager>();

			_enemyDamageManager.TakeDamage(_fighterStats.Attack);
			_attackTimer = _attackDelay;
		}
	}
}
