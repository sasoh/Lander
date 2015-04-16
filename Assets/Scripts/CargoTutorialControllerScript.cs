using UnityEngine;
using System.Collections;

public class CargoTutorialControllerScript : MonoBehaviour
{

	public GameObject step2Object;

	public TutorialHandlerScript.TutorialStep lastStep;

	private ArrayList allObjects;

	// Use this for initialization
	void Start()
	{

		allObjects = new ArrayList();
		allObjects.Add(step2Object);

		HideSteps();

	}

	// Update is called once per frame
	void Update()
	{

	}

	public void ShowStep(TutorialHandlerScript.TutorialStep step)
	{

		HideSteps();
		lastStep = step;

		if (step == TutorialHandlerScript.TutorialStep.StepCargoIntroduction)
		{
			step2Object.SetActive(true);
		}

	}

	public void HideSteps()
	{

		foreach (GameObject obj in allObjects)
		{
			obj.SetActive(false);
		}

	}

}
