using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	public GameObject leftShoe, rightShoe;

	public bool leftFootAhead, rightFoodAhead;

	public Text win, timer, lose;

	public float timeRemaining = 15f;
	// Update is called once per frame
	void Update()
	{
		if (win.enabled == false && lose.enabled == false)
		{
			Movement();
			Timer();
		}

		if (leftShoe.transform.position.z > 35 && rightShoe.transform.position.z > 35)  //Win Condition
		{
			win.enabled = true;
		}

		if (timeRemaining <= 0f) // Lose Condition
		{
			lose.enabled = true;
		}
	}

	public void Movement()
	{
		if (Input.GetKeyDown(KeyCode.A)) //Left Foot Button Pushed Down
			LeftStep();

		if (Input.GetKeyDown(KeyCode.D)) //Right Foot Button Pushed Down
			RightStep();
	}
	public void LeftStep()
	{
		if (!leftFootAhead)
		{
			if (rightFoodAhead)
			{
				leftShoe.transform.position += Vector3.forward;
				rightFoodAhead = false;
			}
			else
			{
				leftShoe.transform.position += Vector3.forward;
				leftFootAhead = true;
				rightFoodAhead = false;
			}
		}
	}
	public void RightStep()
	{
		if (!rightFoodAhead)
		{
			if (leftFootAhead)
			{
				rightShoe.transform.position += Vector3.forward;
				leftFootAhead = false;
			}
			else
			{
				rightShoe.transform.position += Vector3.forward;
				rightFoodAhead = true;
				leftFootAhead = false;
			}
		}
	}
	public void Timer()
	{
		timer.text = timeRemaining.ToString("00.00");

		if (timeRemaining > 0)
		{
			timeRemaining -= Time.deltaTime;
		}
	}
}
