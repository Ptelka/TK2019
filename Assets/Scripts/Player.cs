using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Rigidbody Boat;
    public int Controller;
    public GameObject[] projectiles;
    public float Force;
    public Transform SpawnPoint;


    private void Update()
    {
        Vector3 throwVector =  Boat.transform.forward * 2 + new Vector3(0, 0.05f, 0);
        if (Input.GetMouseButtonDown(0))
        {
            Shoot((-Boat.transform.right / 2+ throwVector) * Force + Boat.velocity, projectiles[Random.Range(0, projectiles.Length)]);
        }
        if (Input.GetMouseButtonDown(1))
        {
            Shoot((Boat.transform.right / 2+throwVector) *Force + Boat.velocity, projectiles[Random.Range(0, projectiles.Length)]);
        }
    }

    private void Shoot(Vector3 direction, GameObject projectileGO)
    {
        Projectile projectile = Instantiate(projectileGO, SpawnPoint.position, projectileGO.transform.rotation).GetComponent<Projectile>();
        projectile.SetTrajectory(direction);
    }
}
