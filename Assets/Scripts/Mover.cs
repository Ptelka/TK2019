using UnityEngine;

public class Mover : MonoBehaviour {
	private Rigidbody body;
	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody>();
	}

	[SerializeField]
	private float MaxVelocity = 0.5f;
	[SerializeField]
	private float Acceleration = 10f;
	
	void Update() {
		float x = Input.GetAxis("LeftStickX");
		float y = Input.GetAxis("LeftStickY");

		if (x < 0 && body.velocity.x >= -MaxVelocity) {
			body.AddForce(new Vector3(x * Acceleration, 0, 0) * Time.deltaTime);
		} 
		
		if (x > 0 && body.velocity.x <= MaxVelocity) {
			body.AddForce(new Vector3(x * Acceleration, 0, 0) * Time.deltaTime);
		}

		if (y < 0 && body.velocity.y >= -MaxVelocity) {
			body.AddForce(new Vector3(0, 0, y * Acceleration) * Time.deltaTime);
		} 
		
		if (y > 0 && body.velocity.y <= MaxVelocity) {
			body.AddForce(new Vector3(0, 0, y * Acceleration) * Time.deltaTime);
		}
	}
}
