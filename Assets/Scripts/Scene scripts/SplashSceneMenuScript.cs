using UnityEngine;
using System.Collections;

// Transitions to main menu scene after a certain timeout
public class SplashSceneMenuScript : MonoBehaviour
{

	public float timeoutBeforeTransition = 1.0f;
	private float timePassed = 0.0f;

	// Use this for initialization
	void Start()
	{

		timePassed = 0.0f;

	}

	// Update is called once per frame
	void Update()
	{

		timePassed += Time.deltaTime;

		if (timePassed >= timeoutBeforeTransition)
		{
			// transition
			Application.LoadLevel("MainMenuScene");
		}

	}
}
