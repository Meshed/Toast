using UnityEngine;

public class FightManager : MonoBehaviour {
	public ArenaStateManager ArenaStateManager;
    public float AttackDelay = 1f;

	FighterStats _fighterStats;
	HealthManager _healthManager;
	float _attackTimer;
	GameObject _target;

	// Use this for initialization
	void Start () {
		_fighterStats = GetComponent<FighterStats> ();
		_healthManager = GetComponentInChildren<HealthManager> ();
		_attackTimer = AttackDelay;
	}
	
	// Update is called once per frame
	void Update () {
		if(IsDead()) return;
		if(GameIsPaused()) return;

		UpdateAttackTimer();
		ResetTarget();

		if (TimeToAttack()) 
		{
			if(IsFighter())
			{
				TargetRandomMonster();
			}
			else
			{
				if(AtLeastOneFighterIsAlive())
				{
					if(OnlyOneFighter())
					{
						TargetFirstFighter();
					}
					else
					{
						TargetRandomFighter();
					}
				}

			}

			if(HaveTarget())
			{
			    AttackTarget();
			}

		    ResetAttackTimer();
		}
	}

    private void AttackTarget()
    {
        var enemyDamageManager = _target.GetComponent<DamageManager>();

        if (enemyDamageManager)
            enemyDamageManager.TakeDamage(_fighterStats.Attack);
    }
    private GameObject HaveTarget()
    {
        return _target;
    }
    private void TargetFirstFighter()
    {
        _target = ArenaStateManager.Fighters[0];
    }
    private bool OnlyOneFighter()
    {
        return ArenaStateManager.Fighters.Count == 1;
    }
    private static bool AtLeastOneFighterIsAlive()
    {
        return FighterService.HealthOfAllFighters() > 0;
    }
    private bool IsFighter()
    {
        return _healthManager.TeamNumber == 1;
    }
    private bool TimeToAttack()
    {
        return _attackTimer < 0;
    }
    private bool IsDead()
    {
        return _fighterStats.Health <= 0;
    }
    private static bool GameIsPaused()
    {
        return Time.timeScale == 0;
    }
    private void TargetRandomMonster()
    {
        int monsterCount = MonsterService.CountOfAllMonsters();

        if (monsterCount > 0)
        {
            int enemyIndex = MonsterService.CountOfAllMonsters() == 1 ? 0 : Random.Range(0, MonsterService.CountOfAllMonsters());
            _target = MonsterService.GetAllMonsters()[enemyIndex];
        }
    }
    private void TargetRandomFighter()
    {
        do
        {
            int enemyIndex = Random.Range(0, ArenaStateManager.Fighters.Count);
            _target = ArenaStateManager.Fighters[enemyIndex];
        } while (_target.GetComponent<FighterStats>().Health <= 0);
    }
    private void ResetTarget()
    {
        _target = null;
    }
    private void UpdateAttackTimer()
    {
        _attackTimer -= Time.deltaTime;
    }
    private void ResetAttackTimer()
    {
        _attackTimer = AttackDelay;
    }
}
