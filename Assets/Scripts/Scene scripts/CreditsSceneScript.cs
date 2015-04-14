using UnityEngine;
using System.Collections;

// Handles credits scene interaction
public class CreditsSceneScript : MonoBehaviour
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
