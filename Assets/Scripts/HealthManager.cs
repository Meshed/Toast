using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {
	FighterStats _fighterStats;
	Text _health;
	GameObject _fighter;

	// Use this for initialization
	void Start () {
		Text[] _playerUILabels;

		_fighter = this.transform.parent.gameObject;
		_fighterStats = _fighter.GetComponent<FighterStats> ();
		_playerUILabels = _fighter.GetComponentsInChildren<Text> ();

		foreach(var label in _playerUILabels)
		{
			switch(label.name)
			{
				case "FighterHealth":
					_health = label;
					break;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		_health.text = _fighterStats.Health + " / 100";
	}
}
