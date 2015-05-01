using UnityEngine;
using System.Collections;

// Handles character creation screen button interaction
public class CharacterCreationSceneButtonsScript : MonoBehaviour
{

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

		if (Input.GetKeyDown("escape") == true)
		{
			DidPressBackButton();
		}

	}

	public void DidPressPlayButton()
	{

		Application.LoadLevel("MissionScene1");

	}

	public void DidPressBackButton()
	{

		Application.LoadLevel("MainMenuScene");

	}
}
