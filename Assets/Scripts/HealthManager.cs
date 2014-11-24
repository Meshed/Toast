using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {
	public int TeamPosition = 1;
	public int TeamNumber = 1;
	public string FighterName = "";

	FighterStats _fighterStats;
	Text _name;
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
				case "FighterName":
					_name = label;
					break;
			}
		}

		_name.text = FighterName;
		SetFighterStatusLocation ();
	}
	
	// Update is called once per frame
	void Update () {
		_health.text = _fighterStats.Health + " / 100";
	}

	void SetFighterStatusLocation()
	{
		if(TeamNumber == 1)
		{
			switch(TeamPosition)
			{
				case 1:
					_name.rectTransform.anchoredPosition = new Vector2(108, -36);
					_health.rectTransform.anchoredPosition = new Vector2(61, -56);
					break;
				case 2:
					_name.rectTransform.anchoredPosition = new Vector2(108, -74);
					_health.rectTransform.anchoredPosition = new Vector2(61, -94);
					break;
				case 3:
					_name.rectTransform.anchoredPosition = new Vector2(108, -112);
					_health.rectTransform.anchoredPosition = new Vector2(61, -132);
					break;
				case 4:
					_name.rectTransform.anchoredPosition = new Vector2(108, -148);
					_health.rectTransform.anchoredPosition = new Vector2(61, -168);
					break;
			}
		}
		else if(TeamNumber == 2)
		{
			// Set anchor for text rect transform to top right
			_name.rectTransform.anchorMin = new Vector2(1, 1);
			_name.rectTransform.anchorMax = new Vector2(1, 1);
			_health.rectTransform.anchorMin = new Vector2(1, 1);
			_health.rectTransform.anchorMax = new Vector2(1, 1);

			// Set text alignment
			_name.alignment = TextAnchor.UpperRight;
			_health.alignment = TextAnchor.UpperRight;

			switch(TeamPosition)
			{
				case 1:
					_name.rectTransform.anchoredPosition = new Vector2(-108, -36);
					_health.rectTransform.anchoredPosition = new Vector2(-61, -56);
					break;
				case 2:
					_name.rectTransform.anchoredPosition = new Vector2(-108, -74);
					_health.rectTransform.anchoredPosition = new Vector2(-61, -94);
					break;
				case 3:
					_name.rectTransform.anchoredPosition = new Vector2(108, -112);
					_health.rectTransform.anchoredPosition = new Vector2(-61, -132);
					break;
				case 4:
					_name.rectTransform.anchoredPosition = new Vector2(108, -36);
					_health.rectTransform.anchoredPosition = new Vector2(-61, -168);
					break;
			}
		}
	}
}
