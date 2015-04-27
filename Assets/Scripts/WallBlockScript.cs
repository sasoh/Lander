using UnityEngine;
using System.Collections;

public class WallBlockScript : MonoBehaviour
{

	private bool directionCW = false;
	private float multiplier = 10.0f;

	// Use this for initialization
	void Start()
	{

		directionCW = false;
		
		if (Random.Range(0, 2) == 1)
		{
			directionCW = true;
		}

		multiplier = Random.Range(3.0f, 20.0f);

	}

	// Update is called once per frame
	void Update()
	{

		int direction = -1;
		if (directionCW == true)
		{
			direction = 1;
		}

		// add slow rotating motion
		Vector3 currentRotation = transform.localRotation.eulerAngles;
		currentRotation.z += Time.deltaTime * direction * multiplier;
		transform.rotation = Quaternion.Euler(currentRotation);

	}
}
