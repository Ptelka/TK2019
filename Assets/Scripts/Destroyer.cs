using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour {
	[SerializeField] private float HP;
	[SerializeField] private float CollsionDamageMultiplayer;
	[SerializeField] private ParticleSystem Explosion;
	
	private HPDisplay display;
	private Rigidbody body;

	void Start ()
	{
		body = GetComponent<Rigidbody>();
		display = gameObject.GetComponent<HPDisplay>();
		display.setmax(HP);
	}

	void EXPLODE1111ONMEONEONE()
	{
		Debug.Log("Starting");
		var explosion = Instantiate<ParticleSystem>(Explosion, transform.position, Quaternion.identity);
		explosion.gameObject.SetActive(true);
		explosion.enableEmission = true;
		if (explosion.isPlaying)
		{
			explosion.Stop();
		}

		explosion.Play();
	}
	
	private void OnCollisionEnter(Collision other)
	
	{
		float dmg = 0;
		if (other.gameObject.CompareTag("Weapon"))
		{
			//dmg = other.gameObject.GetComponent<Projectile>().GetDamage();
		}
		else
		{
			var v = body.velocity;
			dmg = v.magnitude * CollsionDamageMultiplayer;
		}
		
		display.display(HP -= dmg);
		if (HP <= 0)
		{
			EXPLODE1111ONMEONEONE();
		}
	}
}
