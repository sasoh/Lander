using UnityEngine;
using System.Collections;

public class PlayerSkinScript : MonoBehaviour
{

	public SpriteRenderer faceObject = null;

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
		faceObject.sprite = faceSprite;

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
