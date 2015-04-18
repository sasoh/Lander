using UnityEngine;
using System.Collections;

public class PlayerTutorialControllerScript : MonoBehaviour
{

	public GameObject step1Object;
	public GameObject step3Object;
	public GameObject step4Object;

	public TutorialHandlerScript.TutorialStep lastStep;

	private ArrayList allObjects;

	// Use this for initialization
	void Start()
	{

		allObjects = new ArrayList();
		allObjects.Add(step1Object);
		allObjects.Add(step3Object);
		allObjects.Add(step4Object); 

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
		
		if (step == TutorialHandlerScript.TutorialStep.StepPlayerControls)
		{
			step1Object.SetActive(true);
		}
		else if (step == TutorialHandlerScript.TutorialStep.StepCargoPicked)
		{
			step3Object.SetActive(true);
		}
		else if (step == TutorialHandlerScript.TutorialStep.StepCargoDelivered)
		{
			step4Object.SetActive(true);
		}

	}

	public void HideSteps()
	{

		if (allObjects != null)
		{
			foreach (GameObject obj in allObjects)
			{
				obj.SetActive(false);
			}
		}

	}

}
