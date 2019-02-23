using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Rigidbody Boat;
    public int Controller;
    public GameObject[] projectiles;
    public float Force;


    private void Update()
    {
        if (InputWrapper.GetAxis("LeftAttack",Controller)>0.5f)
        {
            Shoot((-Boat.transform.right + Boat.transform.forward + new Vector3(0, 1, 0)) * Force, projectiles[Random.Range(0, projectiles.Length)]);
        }
        if (InputWrapper.GetAxis("RightAttack", Controller)>0.5f)
        {
            Shoot((Boat.transform.right + Boat.transform.forward + new Vector3(0, 1, 0)) * Force, projectiles[Random.Range(0, projectiles.Length)]);
        }
    }

    private void Shoot(Vector3 direction, GameObject projectileGO)
    {
        Projectile projectile = Instantiate(projectileGO, transform.position + direction.normalized, projectileGO.transform.rotation).GetComponent<Projectile>();
        projectile.SetTrajectory(direction);
    }
}
