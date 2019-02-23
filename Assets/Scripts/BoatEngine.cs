using System;
using NUnit.Framework;
using UnityEngine;

public class BoatEngine : MonoBehaviour {
	[SerializeField] private int Controller;
	[SerializeField] private int Position;
	[SerializeField] private GameObject Oar;
	[SerializeField] private float Speed;
	
	private Rigidbody body;
	private Rigidbody parentBody;
	private String stick;
	private float oarRotation;
	
	void Start ()
	{
		stick = Position == 0 ? InputWrapper.LeftAxisY : InputWrapper.RightAxisY;
		
		Debug.Log(stick);
		
		body = GetComponent<Rigidbody>();
		body.isKinematic = true;
		parentBody = transform.parent.GetComponent<Rigidbody>();

		oarRotation = Oar.transform.localEulerAngles.y;
	}


	private bool stageForward;
	private bool stageBackward;

	private float prevAxisValue;
	
	void Update () {
		float currectAxisValue = InputWrapper.GetAxis(stick, Controller);

		if (currectAxisValue < prevAxisValue)
		{
			parentBody.AddForceAtPosition(new Vector3(0, 0, -(currectAxisValue - prevAxisValue) * Time.deltaTime * Speed), transform.position);
		}
		else if (currectAxisValue > prevAxisValue)
		{
			parentBody.AddForceAtPosition(new Vector3(0, 0, -(currectAxisValue - prevAxisValue) * Time.deltaTime * Speed / 10), transform.position);
		}

		prevAxisValue = currectAxisValue;

		var ea = Oar.transform.localEulerAngles;
		ea.y = oarRotation + 20 * currectAxisValue;
		Oar.transform.localEulerAngles = ea;
	}
}
