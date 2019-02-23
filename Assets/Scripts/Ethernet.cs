using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ethernet : MonoBehaviour
{
	private LineRenderer renderer;
	private Vector3 lastPos;
	private List<Vector3> positions = new List<Vector3>();
	public float distance = 1;
	void Start ()
	{
		renderer = GetComponent<LineRenderer>();
		lastPos = gameObject.transform.position;
	}
	
	void Update () {
		if (Vector3.Distance(lastPos, gameObject.transform.position) > distance)
		{
			SpawnCable();
			lastPos = gameObject.transform.position;
		}
	}

	void SpawnCable()
	{
		positions.Add(gameObject.transform.position);
		renderer.positionCount = positions.Count;
		renderer.SetPositions(positions.ToArray());
		Debug.Log(positions.Count);
	}
}
