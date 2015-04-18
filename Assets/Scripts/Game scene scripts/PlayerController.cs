using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

	[Range(0.0f, 50.0f)]
	public float speedHorizontal = 1.0f;

	[Range(0.0f, 50.0f)]
	public float speedVertical = 1.0f;

	[Range(0.0f, 150.0f)]
	public float maximumVertical = 4.0f;

	[Range(0.0f, 150.0f)]
	public float maximumHorizontal = 4.0f;

	[Range(0.0f, 25.0f)]
	public float maximumSafeVelocity = 4.0f;

	public GameObject carryingPivot = null;

	public ScreenOverlayScript overlayScript = null; 

	public PlayerTutorialControllerScript tutorialController;

	private float moveHorizontal = 0.0f;
	private float moveVertical = 0.0f;

	private GameObject cargoObject;

	void Start()
	{

		cargoObject = null;

	}

	void Update()
	{

		ProcessInput();

		UpdateCargo();

	}

	void FixedUpdate()
	{

		UpdateMovement();

	}

	void ProcessInput()
	{

		
		moveHorizontal = Input.GetAxis("Horizontal");
		moveVertical = Input.GetAxis("Vertical");

		if (tutorialController != null)
		{
			if (Input.anyKeyDown == true)
			{
				if (tutorialController.lastStep == TutorialHandlerScript.TutorialStep.StepPlayerControls)
				{
					tutorialController.HideSteps();

					GameObject tutorialObject = GameObject.Find("Tutorial Handler");
					TutorialHandlerScript tutorialHandler = tutorialObject.GetComponent<TutorialHandlerScript>();
					tutorialHandler.ShowStep(TutorialHandlerScript.TutorialStep.StepCargoIntroduction);
				}
			}
		}

	}

	void UpdateMovement()
	{

		Rigidbody2D rigid2d = this.GetComponent<Rigidbody2D>();

		// vertical
		Vector2 verticalForce = new Vector2(0.0f, moveVertical * speedVertical);
		verticalForce.y = Mathf.Clamp(verticalForce.y, -maximumVertical, maximumVertical);
		rigid2d.AddForce(verticalForce);

		// horizontal
		Vector2 horizontalForce = new Vector2(moveHorizontal * speedHorizontal, 0.0f);
		horizontalForce.x = Mathf.Clamp(horizontalForce.x, -maximumHorizontal, maximumHorizontal);
		rigid2d.AddForce(horizontalForce);
	}

	void UpdateCargo()
	{

		if (cargoObject != null)
		{
			cargoObject.transform.position = carryingPivot.transform.position;
		}

	}

	void OnTriggerEnter2D(Collider2D otherObj)
	{

		if (otherObj.gameObject.tag == "Cargo")
		{

			// pickup cargo straight away
			PickupCargo(otherObj.gameObject);

		}

	}

	void OnCollisionEnter2D(Collision2D collision)
	{

		if (collision.gameObject.tag == "Platform")
		{
			Rigidbody2D rigid2d = this.GetComponent<Rigidbody2D>();

			if (Mathf.Abs(rigid2d.velocity.x) > maximumSafeVelocity || Mathf.Abs(rigid2d.velocity.y) > maximumSafeVelocity)
			{
				DidHitGroundFast();
			}
		}

	}

	void DidHitGroundFast()
	{

		MultipleParticleSystemController particleController = GetComponentInChildren<MultipleParticleSystemController>();
		particleController.BeginEmitting();
	
		if (overlayScript != null)
		{
			overlayScript.ShowRedOverlay();
		}

		CameraShakeScript shakeScript = Camera.main.GetComponent<CameraShakeScript>();
		if (shakeScript != null)
		{
			shakeScript.shake = 0.5f;
		}	

	}

	void PickupCargo(GameObject cargo)
	{

		if (cargo != null && cargoObject == null)
		{

			cargoObject = cargo;

			Rigidbody2D cargoRigid2d = cargoObject.GetComponent<Rigidbody2D>();
			cargoRigid2d.isKinematic = true;

			// ignore collisions with cargo bottom
			Physics2D.IgnoreCollision(GetComponent<BoxCollider2D>(), cargoObject.GetComponent<EdgeCollider2D>());

			if (tutorialController != null)
			{
				// move to next step
				GameObject tutorialObject = GameObject.Find("Tutorial Handler");
				TutorialHandlerScript tutorialHandler = tutorialObject.GetComponent<TutorialHandlerScript>();
				tutorialHandler.ShowStep(TutorialHandlerScript.TutorialStep.StepCargoPicked);
			}
		}

	}

	public void DropCargo()
	{

		// remove kinematic flag
		if (cargoObject != null)
		{

			Rigidbody2D cargoRigid2d = cargoObject.GetComponent<Rigidbody2D>();
			cargoRigid2d.isKinematic = false;
			cargoRigid2d.velocity = GetComponent<Rigidbody2D>().velocity;

		}

		cargoObject = null;

		if (tutorialController != null)
		{
			// move to next step
			GameObject tutorialObject = GameObject.Find("Tutorial Handler");
			TutorialHandlerScript tutorialHandler = tutorialObject.GetComponent<TutorialHandlerScript>();
			tutorialHandler.ShowStep(TutorialHandlerScript.TutorialStep.StepCargoDelivered);
		}
	}
}
