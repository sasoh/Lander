using UnityEngine;
using System.Collections;

public class CargoDeliveryControllerScript : MonoBehaviour
{

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	void OnTriggerEnter2D(Collider2D otherObj)
	{

		if (otherObj.gameObject.tag == "Platform")
		{

			PlatformSimpleScript platformScript = otherObj.gameObject.GetComponentInParent<PlatformSimpleScript>();
			CargoFlagControllerScript flagScript = GetComponent<CargoFlagControllerScript>();

			if (platformScript.type == flagScript.type)
			{
				// rough release from the player object
				GameObject playerObject = GameObject.Find("Player");
				if (playerObject != null)
				{
					PlayerController playerController = playerObject.GetComponent<PlayerController>();
					playerController.DropCargo();

					Destroy(gameObject);
				}
			}
		}

	}
	
}
