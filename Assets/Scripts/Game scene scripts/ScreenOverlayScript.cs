using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScreenOverlayScript : MonoBehaviour
{

	public Image overlayHit = null;

	private float timeToChange = 0.0f;
	private bool shouldChange = false;

	// Use this for initialization
	void Start()
	{

		overlayHit.CrossFadeAlpha(0.0f, 0.0f, true);

	}

	// Update is called once per frame
	void Update()
	{

		if (shouldChange == true)
		{
			timeToChange -= Time.deltaTime;
			if (timeToChange <= 0.0f)
			{
				shouldChange = false;

				// hide hit overlay
				overlayHit.CrossFadeAlpha(0.0f, 0.5f, false);
			}
		}

	}

	public void ShowRedOverlay()
	{

		timeToChange = 0.25f;

		// show hit overlay
		overlayHit.CrossFadeAlpha(1.0f, 0.1f, false);

		shouldChange = true;

	}
	
}
