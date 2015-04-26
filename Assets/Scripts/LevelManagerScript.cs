using UnityEngine;
using System.Collections;

public class LevelManagerScript : MonoBehaviour
{

	private bool victory = false;

	// Use this for initialization
	void Start()
	{

		victory = false;

	}

	// Update is called once per frame
	void Update()
	{
		
		if (HasCargoBoxesOnScene() == false && victory == false)
		{
			victory = true;

			print("Player won!");
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
