using UnityEngine;
using System.Collections;

public class DamageManager : MonoBehaviour {
	FighterStats _fighterStats;

	// Use this for initialization
	void Start () {
		_fighterStats = this.GetComponent<FighterStats> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void TakeDamage(int damage)
	{
		if (_fighterStats.Health <= 0)
			return;

		int dodgeRoll = Random.Range (1, 101);

		if (dodgeRoll < 90)
		{
			_fighterStats.Health -= damage;
		}

		if(_fighterStats.Health <= 0)
		{
			// Destroy fighter game object if this is an NPC
		}
	}
}
