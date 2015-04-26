using UnityEngine;
using System.Collections;

public class TutorialHandlerScript : MonoBehaviour
{

	public enum TutorialStep
	{
		StepPlayerControls,
		StepCargoIntroduction,
		StepCargoPicked,
		StepCargoDelivered,
	}

	public TutorialStep lastStep;

	private GameObject playerObject;
	private GameObject cargoObject;

	// Use this for initialization
	void Start()
	{

		playerObject = GameObject.Find("Player");
		cargoObject = GameObject.Find("Cargo");

		ShowStep(TutorialStep.StepPlayerControls);

	}

	// Update is called once per frame
	void Update()
	{

	}

	public void ShowStep(TutorialStep step)
	{

		if (playerObject != null && cargoObject != null)
		{
			lastStep = step;

			PlayerTutorialControllerScript playerScript = playerObject.GetComponent<PlayerTutorialControllerScript>();
			CargoTutorialControllerScript cargoScript = cargoObject.GetComponent<CargoTutorialControllerScript>();

			if (step == TutorialStep.StepPlayerControls)
			{
				cargoScript.HideSteps();
				playerScript.ShowStep(step);
			}
			else if (step == TutorialStep.StepCargoIntroduction)
			{
				playerScript.HideSteps();
				cargoScript.ShowStep(step);
			}
			else if (step == TutorialStep.StepCargoPicked)
			{
				cargoScript.HideSteps();
				playerScript.ShowStep(step);
			}
			else if (step == TutorialStep.StepCargoDelivered)
			{
				cargoScript.HideSteps();
				playerScript.ShowStep(step);
			}
		}

	}

}
