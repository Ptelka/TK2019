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
	private String analogY;
	private String analogX;
	private Vector3 oarRotation;

	private bool works;
	
	void Start ()
	{
		analogY = Position == 0 ? InputWrapper.LeftAxisY : InputWrapper.RightAxisY;
		analogX = Position == 0 ? InputWrapper.LeftAxisX : InputWrapper.RightAxisX;
		
		Debug.Log(analogY);
		
		body = GetComponent<Rigidbody>();
		body.isKinematic = true;

		if (transform.parent)
		{
			parentBody = transform.parent.GetComponent<Rigidbody>();
			if (transform.parent.parent)
			{
				parentBody = transform.parent.parent.GetComponent<Rigidbody>();
			}
		}

		oarRotation = Oar.transform.localEulerAngles;
	}


	private bool stageForward;
	private bool stageBackward; 

	private float prevAxisValue;
	
	void Update () {
		float currectYAxisValue = -InputWrapper.GetAxis(analogX, Controller);
		float currectXAxisValue = -InputWrapper.GetAxis(analogY, Controller);
		
		if (works)
		{
			parentBody.AddForceAtPosition(new Vector3(0, 0, (prevAxisValue - currectYAxisValue) * Time.deltaTime * Speed), transform.position);
		}

		prevAxisValue = currectYAxisValue;

		var target = Oar.transform.localEulerAngles;

		target.x = oarRotation.x;
		target.y = oarRotation.y - 50 * currectYAxisValue;
		target.z = oarRotation.z + 30 * currectXAxisValue;
		
		Oar.transform.localRotation = Quaternion.Lerp(Oar.transform.localRotation, Quaternion.Euler(target.x, target.y, target.z), .5f);
	}
	
	private void OnTriggerEnter(Collider other)
	{
		works = true;
	}
	
	private void OnTriggerExit(Collider other)
	{
		works = false;
	}
}
