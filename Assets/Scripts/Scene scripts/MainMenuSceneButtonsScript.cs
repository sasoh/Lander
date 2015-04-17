using UnityEngine;
using System.Collections;

// Handles button interaction on the main menu scene
public class MainMenuSceneButtonsScript : MonoBehaviour
{

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	void LoadSceneNamed(string name)
	{

		Application.LoadLevel(name);

	}

	public void DidPressPlayButton()
	{

		LoadSceneNamed("MissionScene");

	}

	public void DidPressOptionsButton()
	{

		LoadSceneNamed("OptionsScene");
	
	}

	public void DidPressCreditsButton()
	{

		LoadSceneNamed("CreditsScene");

	}

	public void DidPressExitButton()
	{

		// confirmation?
		Application.Quit();

	}
}
