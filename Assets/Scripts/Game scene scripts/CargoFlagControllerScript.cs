using UnityEngine;
using System.Collections;

public class CargoFlagControllerScript : MonoBehaviour
{

	public GameObject flag;
	public PlatformSimpleScript.PlatformType type;

	// Use this for initialization
	void Start()
	{

		SetFlag();

	}

	// Update is called once per frame
	void Update()
	{

	}

	void SetFlag()
	{

		SpriteRenderer spriteRenderer = flag.GetComponent<SpriteRenderer>();
		spriteRenderer.sprite = PlatformSimpleScript.LoadFlagSpriteForType(type);

	}
}
