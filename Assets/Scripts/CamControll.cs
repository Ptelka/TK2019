using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControll : MonoBehaviour
{
	[SerializeField]
	GameObject obj;	
	
	private Vector3 offset;         //Private variable to store the offset distance between the player and camera
	void Start () {
		offset = transform.position - obj.transform.position;

		Debug.Log("Size: " + Input.GetJoystickNames().Length);
		foreach (var name in Input.GetJoystickNames())
		{
			Debug.Log(name);
		}
	}
	
	void Update () {
		transform.position = obj.transform.position + offset;
	}
}
