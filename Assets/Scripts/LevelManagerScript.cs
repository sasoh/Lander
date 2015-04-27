using UnityEngine;
using System.Collections;

public class LevelManagerScript : MonoBehaviour
{

	public PlayerController playerObject = null;
	private bool victory = false;

	// Use this for initialization
	void Start()
	{

		victory = false;

		if (playerObject == null)
		{
			print("Player object not set in level manager script, restarting the level would not work.");
		}

	}

	// Update is called once per frame
	void Update()
	{
		
		if (HasCargoBoxesOnScene() == false && victory == false)
		{
			victory = true;

			print("Player won!");
		}

		if (playerObject != null && playerObject.isActiveAndEnabled == false)
		{
			if (Input.GetButton("Submit") == true)
			{
				Application.LoadLevel(Application.loadedLevel);
			}
		}

	}

	bool HasCargoBoxesOnScene()
	{
		
		bool result = false;
		
		GameObject[] cargos = GameObject.FindGameObjectsWithTag("Cargo");
		if (cargos.Length > 0)
		{
			result = true;
		}

		return result;

	}
}
