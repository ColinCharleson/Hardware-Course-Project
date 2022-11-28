using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class PlayerController : MonoBehaviour
{
	public SerialController serialController;
	public GameObject leftShoe, rightShoe;

	public bool leftFootAhead, rightFoodAhead;
	public bool leftInput, rightInput;

	public Text win, timer, lose;

	public float timeRemaining = 15f; 
	
	void Start()
	{
		serialController = GameObject.Find("SerialController").GetComponent<SerialController>();
	}
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

		string message = serialController.ReadSerialMessage();

		if (message == null)
			return;

		if(message == "LeftDown")
		{
			leftInput = true;
		}
		else if (message == "LeftUp")
		{
			leftInput = false;
		}
		if(message == "RightDown")
		{
			rightInput = true;
		}
		else if (message == "RightUp")
		{
			rightInput = false;
		}


		// Check if the message is plain data or a connect/disconnect event.
		if (ReferenceEquals(message, SerialController.SERIAL_DEVICE_CONNECTED))
			Debug.Log("Connection established");
		else if (ReferenceEquals(message, SerialController.SERIAL_DEVICE_DISCONNECTED))
			Debug.Log("Connection attempt failed or disconnection detected");
		else
			Debug.Log("Message arrived: " + message);
	}

	public void Movement()
	{

		if (!leftInput && rightInput) //Left Foot Button Pushed Down
			LeftStep();

		if (!rightInput && leftInput) //Right Foot Button Pushed Down
			RightStep();
	}
	public void LeftStep()
	{
		string message = serialController.ReadSerialMessage();

		if (message == null)
		{
			Debug.Log("na");
		}
		else
		{
			Debug.Log(message);
		}

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
