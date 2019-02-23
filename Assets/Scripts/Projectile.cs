using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class Projectile : MonoBehaviour
{
    public enum WeaponType
    {
        blunt,
        pierce,
        hack
    }
    public float deathDelay = 3;
    public WeaponType weaponType;
    public float Damage;

    private Rigidbody rb;
    private Collider coll;
    private Quaternion hitRotationOffset;
    private Vector3 hitPositionOffset;
    private Transform target;

    public float GetDamage()
    {
        return Damage;
    }


    private void Awake()
    {
        gameObject.tag = "Weapon";
        rb = GetComponent<Rigidbody>();
        coll = GetComponent<Collider>();
        coll.enabled = false;
        Invoke("EnableCollider", 0.25f);
    }
    
    private void EnableCollider()
    {
        coll.enabled = true;
    }

    public void SetTrajectory(Vector3 direction)
    {
        transform.forward = direction;
        rb.velocity = direction;
        if (weaponType == WeaponType.hack)
        {
            rb.AddRelativeTorque(900,0,0);
        }
    }

    private void AttachToTarget(Collision collision)
    {
        rb.isKinematic = true;
        coll.enabled = false;
        transform.parent = collision.transform;
    }


    private void OnCollisionEnter(Collision collision)
    {
        gameObject.tag = "Used";
        switch (weaponType)
        {
            case WeaponType.blunt:
                Destroy(gameObject, deathDelay);
                break;
            default:
                AttachToTarget(collision);
                break;
        }
    }
}
