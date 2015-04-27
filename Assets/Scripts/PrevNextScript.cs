using UnityEngine;
using System.Collections;

public class PrevNextScript : MonoBehaviour
{

	public string keyToChange = null;
	public int maximumCount = 0;
	public PlayerSkinScript skinToUpdate = null;

	private bool isActive = false;

	// Use this for initialization
	void Start()
	{

		isActive = false;
		if (keyToChange == null || keyToChange.Length == 0 || maximumCount == 0 || skinToUpdate == null)
		{
			print("One of the parameters is incorrectly set.");
		}
		else
		{
			isActive = true;
		}

	}

	// Update is called once per frame
	void Update()
	{

	}

	public void DidPressPrevious()
	{

		SetValueWithModifier(-1);
		
	}

	public void DidPressNext()
	{
		
		SetValueWithModifier(1);
	}

	void SetValueWithModifier(int modifier)
	{

		if (isActive == true)
		{
			int currentValue = 0;
			if (PlayerPrefs.HasKey(keyToChange) == true)
			{
				currentValue = PlayerPrefs.GetInt(keyToChange);
			}

			currentValue += modifier;
			currentValue %= maximumCount; // limit to max
			if (currentValue < 0)
			{
				currentValue = maximumCount - 1;
			}

			PlayerPrefs.SetInt(keyToChange, currentValue); 
			PlayerPrefs.Save();

			skinToUpdate.UpdateSkin();
		}

	}

}
