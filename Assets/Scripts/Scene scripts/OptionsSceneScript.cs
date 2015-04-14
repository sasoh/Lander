using UnityEngine;
using System.Collections;

// Handles options scene controls
public class OptionsSceneScript : MonoBehaviour
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

	public void DidPressBackButton()
	{
	
		Application.LoadLevel("MainMenuScene");

	}
}
