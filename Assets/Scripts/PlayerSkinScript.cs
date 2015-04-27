using UnityEngine;
using System.Collections;

public class PlayerSkinScript : MonoBehaviour
{

	public SpriteRenderer faceObject = null;
	public GameObject body = null;
	public GameObject body1prefab = null;
	public GameObject body2prefab = null;

	// Use this for initialization
	void Start()
	{

		if (faceObject == null)
		{
			print("Face pointer not set.");
		}
		else
		{
			UpdateSkin();
		}
	}

	// Update is called once per frame
	void Update()
	{

	}

	public void UpdateSkin()
	{

		Sprite faceSprite = LoadFaceSpriteFromSettings();
		if (faceSprite != null)
		{
			faceObject.sprite = faceSprite;
		}

		// remove old frame
		GameObject oldFrame = GameObject.FindGameObjectWithTag("Frame");
		if (oldFrame != null)
		{
			Vector3 originalPosition = oldFrame.transform.localPosition;
			Destroy(oldFrame);
			GameObject newFrame = LoadNewFrameFromSettings();
			if (newFrame != null)
			{
				newFrame.transform.parent = body.transform;
				newFrame.transform.localPosition = originalPosition;
			}
		}
	}

	GameObject LoadNewFrameFromSettings()
	{

		GameObject result = null;

		int index = 0;
		if (PlayerPrefs.HasKey("BodyNumber") == true)
		{
			index = PlayerPrefs.GetInt("BodyNumber");
		}

		if (index == 0)
		{
			result = Instantiate(body1prefab);
		}
		else
		{
			result = Instantiate(body2prefab);
		}

		return result;

	}

	Sprite LoadFaceSpriteFromSettings()
	{

		Sprite result = null;

		Sprite[] allFaces = Resources.LoadAll<Sprite>("Sprites/Player/Character/Faces");

		if (allFaces.Length > 0)
		{
			int index = 0; // default face index

			if (PlayerPrefs.HasKey("FaceNumber") == true)
			{
				index = PlayerPrefs.GetInt("FaceNumber");
			}

			if (index < allFaces.Length && index >= 0)
			{
				result = allFaces[index];
			}
		}

		return result;

	}

}
