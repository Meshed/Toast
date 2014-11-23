using UnityEngine;
using System.Collections;

public class FightManager : MonoBehaviour {
	public GameObject Enemy;
	FighterStats _fighterStats;
	float _attackDelay = 1f;
	float _attackTimer = 0f;

	// Use this for initialization
	void Start () {
		_fighterStats = this.GetComponent<FighterStats> ();
		_attackTimer = _attackDelay;
	}
	
	// Update is called once per frame
	void Update () {
		_attackTimer -= Time.deltaTime;

		if (_attackTimer < 0) 
		{
			DamageManager _enemyDamageManager = Enemy.GetComponent<DamageManager>();

			_enemyDamageManager.TakeDamage(_fighterStats.Attack);
			_attackTimer = _attackDelay;
		}
	}
}
