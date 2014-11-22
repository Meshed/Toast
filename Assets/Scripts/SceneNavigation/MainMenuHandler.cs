using UnityEngine;
using System.Collections;

public class MainMenuHandler : MonoBehaviour {
	public void LoadAreana()
	{
		Application.LoadLevel ("Arena");
	}

	public void LoadCredits()
	{
		Application.LoadLevel ("Credits");
	}

	public void LoadMainMenu()
	{
		Application.LoadLevel ("MainMenu");
	}

	public void ExitGame()
	{
		Application.Quit ();
	}
}
