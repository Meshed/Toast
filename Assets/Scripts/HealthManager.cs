using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {
	FighterStats _fighterStats;
	public Text HealthLabel;
	Text _health;

	// Use this for initialization
	void Start () {
		_fighterStats = this.GetComponent<FighterStats> ();
		_health = HealthLabel.GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		_health.text = _fighterStats.Health + " / 100";
	}
}
