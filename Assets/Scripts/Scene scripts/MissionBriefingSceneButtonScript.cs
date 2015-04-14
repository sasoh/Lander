using UnityEngine;
using System.Collections;

public class MissionBriefingSceneButtonScript : MonoBehaviour
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

		Application.LoadLevel("MissionScene");

	}

	public void DidPressBackButton()
	{

		Application.LoadLevel("MainMenuScene");

	}
}
