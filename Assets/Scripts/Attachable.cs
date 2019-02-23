using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attachable : MonoBehaviour
{
    enum State
    {
        owned,
        lonely
    }

    private State state = State.lonely;
    private Rigidbody rb;
    private Transform owner;
    private SpringJoint joint;

    private void Awake()
    {
        joint = GetComponent<SpringJoint>();
        rb = GetComponent<Rigidbody>();
    }

    private void Attach(Collider collider)
    {
        state = State.owned;
        joint = gameObject.AddComponent<SpringJoint>();
        joint.connectedBody = collider.GetComponent<Rigidbody>();
        owner = collider.transform;
        joint.spring = 1000;
    }

    private void Detach()
    {
        state = State.lonely;
        Destroy(joint);
        owner = null;
    }

    private void DieHorribly()
    {
        ExplodeViolently();
        Destroy(gameObject);
    }

    private void ExplodeViolently()
    {
        //
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            switch (state)
            {
                case State.lonely:
                    Attach(collision.collider);
                    break;
                case State.owned:
                    if (owner != collision.transform)
                    {
                        Debug.Log("died");
                        DieHorribly();
                    }
                    break;
            }
        }
    }
}
