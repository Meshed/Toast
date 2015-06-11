using UnityEngine;

public class DamageManager : MonoBehaviour
{
    public int ChanceToDodge = 0;

	FighterStats _fighterStats;

	void Start () {
		GetFighterStats();
	}

	public void TakeDamage(int damage)
	{
		if (FighterDead()) return;

		if (PlayerDodgedAttack() == false)
		{
			_fighterStats.Health -= damage;
		}
	}

    private void GetFighterStats()
    {
        _fighterStats = GetComponent<FighterStats>();
    }
    private bool FighterDead()
    {
        return _fighterStats.Health <= 0;
    }
    private bool PlayerDodgedAttack()
    {
        int dodgeRoll = Random.Range(1, 101);

        return dodgeRoll < ChanceToDodge;
    }
}
