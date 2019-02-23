using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControll : MonoBehaviour
{
    public Transform Target;
    public float FollowDistance;
    public float CatchUpSpeed;
    public float Tolerance;


    private Vector3 offset;         //Private variable to store the offset distance between the player and camera
    void Start()
    {
        offset = transform.position - Target.position;
    }

    void FixedUpdate()
    {
        FollowTarget();
        LookAtTarget();
    }

    private void LateUpdate()
    {
    }

    void LookAtTarget()
    {
        transform.LookAt(Target.position + Target.forward * (FollowDistance + Tolerance + 1), Vector3.up);
    }

    void FollowTarget()
    {
        float Distance = Vector3.Distance(this.gameObject.transform.position, Target.position);

        if (Distance > FollowDistance + Tolerance)
        {
            transform.position = Vector3.Lerp(transform.position,new Vector3(Target.position.x, Target.position.y+offset.y, Target.position.z) - Target.forward * (FollowDistance + Tolerance), CatchUpSpeed);
        }
        else if (Distance < FollowDistance - Tolerance)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(Target.position.x, Target.position.y + offset.y, Target.position.z) - Target.forward * (FollowDistance - Tolerance), CatchUpSpeed);
        }

        transform.position = Vector3.Lerp(transform.position, new Vector3(Target.position.x, Target.position.y + offset.y, Target.position.z) - Target.forward * FollowDistance, CatchUpSpeed/2);
    }
}
