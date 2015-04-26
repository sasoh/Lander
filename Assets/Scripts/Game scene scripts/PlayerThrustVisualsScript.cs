using UnityEngine;
using System.Collections;

public class PlayerThrustVisualsScript : MonoBehaviour
{

	[Tooltip("Left thruster game object, must not be null.")]
	public GameObject thrusterLeft = null;

	[Tooltip("Right thruster game object, must not be null.")]
	public GameObject thrusterRight = null;

	public float jerkAmount = 1.0f;

	private GameObject[] allThrusters = null;
	private Vector3[] allThrustersOriginalPositions = null;
	private bool active; // tells if thruster visuals has been set correctly

	// Use this for initialization
	void Start()
	{

		CheckConfiguration();

	}

	// Update is called once per frame
	void Update()
	{

		if (active == true)
		{
			AddJerkyMotion();
			SetThrusterVisibility();
		}

	}

	void AddJerkyMotion()
	{

		for (int i = 0; i < 2; ++i)
		{
			GameObject thruster = allThrusters[i];
			thruster.transform.localPosition = allThrustersOriginalPositions[i] + Random.insideUnitSphere * jerkAmount;
		}


	}

	void SetThrusterVisibility()
	{

		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		bool horizontal = AxisStatusForValue(moveHorizontal);
		bool vertical = AxisStatusForValue(moveVertical);

		if (vertical == true)
		{
			SetVerticalVisibility(moveVertical);
		}
		else if (horizontal == true)
		{
			SetHorizontalVisibility(moveHorizontal);
		}
		else
		{
			SetBothThrustersVisible(false);
		}
	}

	void SetVerticalVisibility(float amount)
	{

		float alpha = Mathf.Abs(amount);

		for (int i = 0; i < 2; ++i)
		{
			GameObject thruster = allThrusters[i];
			thruster.SetActive(true);

			SpriteRenderer targetRenderer = thruster.GetComponent<SpriteRenderer>();
			Color targetColor = targetRenderer.color;
			targetColor.a = alpha;
			targetRenderer.color = targetColor;
		}

	}

	void SetHorizontalVisibility(float amount)
	{

		GameObject targetThruster = null;
		float alpha = Mathf.Abs(amount);

		// show thrust only on the opposite side
		if (amount < 0.0f)
		{
			// movement to the left
			thrusterLeft.SetActive(false);
			thrusterRight.SetActive(true);

			targetThruster = thrusterRight;
		}
		else
		{
			// movement to the right
			thrusterLeft.SetActive(true);
			thrusterRight.SetActive(false);

			targetThruster = thrusterLeft;
		}

		// set alpha
		SpriteRenderer targetRenderer = targetThruster.GetComponent<SpriteRenderer>();
		Color targetColor = targetRenderer.color;
		targetColor.a = alpha;
		targetRenderer.color = targetColor;

	}

	void SetBothThrustersVisible(bool status)
	{

		for (int i = 0; i < 2; ++i)
		{
			GameObject thruster = allThrusters[i];
			thruster.SetActive(status);
		}

	}

	bool AxisStatusForValue(float value)
	{

		bool result = false;

		if (Mathf.Abs(value) > 0.01f)
		{
			result = true;
		}

		return result;

	}

	void CheckConfiguration()
	{

		active = false;

		if (thrusterLeft != null && thrusterRight != null)
		{
			allThrusters = new GameObject[2];
			allThrusters[0] = thrusterLeft;
			allThrusters[1] = thrusterRight;

			allThrustersOriginalPositions = new Vector3[2];
			allThrustersOriginalPositions[0] = allThrusters[0].transform.localPosition;
			allThrustersOriginalPositions[1] = allThrusters[1].transform.localPosition;

			active = true;
		}

		if (active == false)
		{
			print("Player thrust visuals not set properly.");
		}

	}
}
