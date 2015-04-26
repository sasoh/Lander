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

	private bool shouldAutoHide = false;
	public float autoHideTimeout = 2.0f;
	private float autoHideTime = 0.0f;
	private GameObject autoHideGameObject = null;

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

		if (shouldAutoHide == true)
		{
			autoHideTime -= Time.deltaTime;

			if (autoHideTime <= 0.0f)
			{
				if (autoHideGameObject == playerObject && playerObject != null)
				{
					PlayerTutorialControllerScript playerScript = playerObject.GetComponent<PlayerTutorialControllerScript>();
					playerScript.HideSteps();
				}	
				else if (autoHideGameObject == cargoObject && cargoObject != null)
				{
					CargoTutorialControllerScript cargoScript = cargoObject.GetComponent<CargoTutorialControllerScript>();
					cargoScript.HideSteps();
				}
			}
		}

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

				// last step will disappear after a certain period of time
				shouldAutoHide = true;
				autoHideTime = autoHideTimeout;
				autoHideGameObject = playerObject;
			}
		}

	}

}
