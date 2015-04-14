using UnityEngine;
using System.Collections;

public class GeneralControlsController : MonoBehaviour
{

	void Start()
	{

		Cursor.visible = false;

	}

	void OnDestroy()
	{

		Cursor.visible = true;

	}

	// Update is called once per frame
	void Update()
	{

		if (Input.GetKey("escape"))
		{
			Application.LoadLevel("MainMenuScene");
		}

	}

}
