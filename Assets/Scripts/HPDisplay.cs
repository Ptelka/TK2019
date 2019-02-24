using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPDisplay : MonoBehaviour
{
	private float max = 100;

	public void setmax(float max)
	{
		this.max = max;
		display(max);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void display(float current)
	{
		Debug.Log(current / max * 100f + "%");
	}
}
