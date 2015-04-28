using UnityEngine;
using System.Collections;

public class PlatformSimpleScript : MonoBehaviour
{

	public GameObject flagSprite;

	private float counter = 0;

	public enum PlatformType
	{

		Red,
		Green,
		Yellow,
		Blue

	}

	public PlatformType type;

	// Use this for initialization
	void Start()
	{

		SetFlagSprite();

		counter += Random.Range(-0.5f, 0.5f);

	}

	// Update is called once per frame
	void Update()
	{

		// add some bobbing motion
		float deltaTime = Time.deltaTime;
		if (deltaTime > 0.001f)
		{
			counter += deltaTime / 5.0f;
			float y = Mathf.Sin(counter * Mathf.PI) * 0.005f;

			Vector3 localPos = transform.localPosition;
			localPos.y += y;
			transform.localPosition = localPos;
		}

	}

	void SetFlagSprite()
	{

		SpriteRenderer spriteRenderer = flagSprite.GetComponent<SpriteRenderer>();
		spriteRenderer.sprite = PlatformSimpleScript.LoadFlagSpriteForType(type);

	}

	public static Sprite LoadFlagSpriteForType(PlatformType type)
	{

		Sprite result = null;

		string filename = "Sprites/Game scene/level elements/flags/sprite_flag_";
		if (type == PlatformType.Blue)
		{
			filename += "blue1";
		}
		else if (type == PlatformType.Green)
		{
			filename += "green1";
		}
		else if (type == PlatformType.Red)
		{
			filename += "red1";
		}
		else if (type == PlatformType.Yellow)
		{
			filename += "yellow1";
		}

		result = Resources.Load<Sprite>(filename);

		if (result == null)
		{
			print("Failed loading flag image " + filename);
		}

		return result;

	}
}
