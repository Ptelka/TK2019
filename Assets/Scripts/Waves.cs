using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Waves : MonoBehaviour {

	public float WaveHeight = 0.31f;
	public float Speed = 1.18f;
	public float WaveLength = 2f;
	public float NoiseStrength = 0f;
	public float NoiseWalk = 1f;
	public float RandomHeight = 0.01f;
	public float RandomSpeed = 9f;
	public float NoiseOffset = 20.0f;

	private Vector3[] baseHeight;
	private Vector3[] vertices;
	private Mesh mesh;
	void Awake() {
		mesh = GetComponent<MeshFilter>().mesh;
		if (baseHeight == null) {
			baseHeight = mesh.vertices;
		}
	}

	void Update ()
	{
		vertices = mesh.vertices;

		for (int i=0;i<vertices.Length;i++) {
			vertices[i] += Vector3.up * Time.deltaTime;
			Vector3 vertex = baseHeight[i];
			Random.InitState((int)((vertex.x + NoiseOffset) * (vertex.x + NoiseOffset) + (vertex.z + NoiseOffset) * (vertex.z + NoiseOffset)));
			vertex.z += Mathf.Sin(Time.time * Speed + baseHeight[i].x * WaveLength + baseHeight[i].z * WaveLength) * WaveHeight;
			vertex.z += Mathf.Sin(Mathf.Cos(Random.value * 1.0f) * RandomHeight * Mathf.Cos (Time.time * RandomSpeed * Mathf.Sin(Random.value * 1.0f)));
			vertex.z += Mathf.PerlinNoise(baseHeight[i].z + Mathf.Cos(Time.time * 0.1f) + NoiseWalk, baseHeight[i].z + Mathf.Sin(Time.time * 0.1f)) * NoiseStrength;
			vertices[i] = vertex;
		}
		mesh.vertices = vertices;
		mesh.RecalculateNormals();
		mesh.RecalculateBounds();
	}
}