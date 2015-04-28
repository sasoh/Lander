using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelManagerScript : MonoBehaviour
{

	public PlayerController playerObject = null;
	public Text timerLabel = null;
	public Text endGameLabel = null;
	public int levelTime = 90;

	private bool victory = false;
	private float currentTimeLeft = 0.0f;
	private int lastTime = 0;
	private bool endGame = false;

	// Use this for initialization
	void Start()
	{

		victory = false;
		endGame = false;

		if (playerObject == null)
		{
			print("Player object not set in level manager script, restarting the level would not work.");
		}

		if (timerLabel == null)
		{
			print("Timer label not set.");
		}

		if (endGameLabel == null)
		{
			print("End game label not set.");
		}

		Time.timeScale = 1.0f;

		endGameLabel.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);

		// reset countdown
		currentTimeLeft = levelTime;
		lastTime = 0;

		// set default values
		timerLabel.fontSize = 20;
		timerLabel.color = new Color(1.0f, 1.0f, 1.0f);

	}

	// Update is called once per frame
	void Update()
	{

		if (endGame == false)
		{
			if (HasCargoBoxesOnScene() == false && victory == false)
			{
				victory = true;
				endGame = true;

				string message = "Player won!\nPress Enter/Space to restart.";
				ShowEndGameLabelWithText(message);
			}

			// player death restart
			if (playerObject != null && playerObject.isActiveAndEnabled == false)
			{
				endGame = true;
			}

			currentTimeLeft -= Time.deltaTime;
			UpdateTimerLabelForRemainingSeconds(Mathf.RoundToInt(currentTimeLeft));
		}
		else
		{
			if (playerObject != null && playerObject.isActiveAndEnabled == false)
			{
				string message = "Mission failed, player died.\nPress Enter/Space to restart.";
				ShowEndGameLabelWithText(message);
			}
		}

		if (victory == true || endGame == true)
		{
			if (Input.GetButton("Submit") == true)
			{
				Application.LoadLevel(Application.loadedLevel);
			}
		}

	}

	void ShowEndGameLabelWithText(string text)
	{

		if (endGameLabel != null)
		{
			timerLabel.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);

			endGameLabel.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
			endGameLabel.text = text;
		}

		// deactivate all simulations after a second (so animations finish)
		InvokeRepeating("StopTime", 1.0f, 1.0f);
	}

	void StopTime()
	{

		Time.timeScale = 0.0f;
		CancelInvoke("StopTime");

	}



	void UpdateTimerLabelForRemainingSeconds(int seconds)
	{

		if (seconds <= 0)
		{
			endGame = true;

			string message = "Mission failed, no time left.\nPress Enter/Space to restart.";
			ShowEndGameLabelWithText(message);

			return;
		}

		if (lastTime != seconds)
		{
			lastTime = seconds;

			if (timerLabel != null)
			{
				string timeString = "Time left: " + seconds;
				timerLabel.text = timeString;

				// increase size
				if (seconds < 11)
				{
					timerLabel.fontSize = timerLabel.fontSize + 2;

					// color red/yellow
					if (seconds < 6)
					{
						timerLabel.color = new Color(1.0f, 0.0f, 0.0f);
					}
					else
					{
						timerLabel.color = new Color(1.0f, 1.0f, 0.0f);
					}
				}
			}
		}

	}

	bool HasCargoBoxesOnScene()
	{

		bool result = false;

		GameObject[] cargos = GameObject.FindGameObjectsWithTag("Cargo");
		if (cargos.Length > 0)
		{
			result = true;
		}

		return result;

	}
}
