using UnityEngine;
using System.Collections;

public class MonsterManager : MonoBehaviour {
	FighterStats _fighterStats;

	// Use this for initialization
	void Start () {
		_fighterStats = gameObject.GetComponentInChildren<FighterStats> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(_fighterStats.Health == 0)
		{
			DestroyObject(gameObject);
		}
	}
}
