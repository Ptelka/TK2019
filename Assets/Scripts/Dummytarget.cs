using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummytarget : MonoBehaviour
{
    public Rigidbody owner;
    public float speed;

    private Vector3 basePosition;
    [SerializeField] private int Controller;
    [SerializeField] private int Position;
    private string analogY;
    private string analogX;
    private float previousValX;
    private bool works;

    private void Start()
    {
        basePosition = transform.localPosition;
        analogY = Position == 0 ? InputWrapper.LeftAxisY : InputWrapper.RightAxisY;
        analogX = Position == 0 ? InputWrapper.LeftAxisX : InputWrapper.RightAxisX;
    }

    private void Update()
    {
        if (!works)
        {
            // previousValX = trans
        }
        transform.localPosition = new Vector3(basePosition.x, basePosition.y + InputWrapper.GetAxis(analogY, Controller), basePosition.z - InputWrapper.GetAxis(analogX, Controller) * (Position == 0 ? 1 : -1));
        float currentValX = transform.localPosition.z;
        works = InputWrapper.GetAxis(analogY, Controller) > 0;
        if (works)
        {
            owner.AddRelativeTorque(new Vector3(0,speed *5* Mathf.Clamp((currentValX - previousValX), -1, 1) * (Position == 0 ? 1 : -1)));
            owner.AddForce(owner.transform.forward * speed * Mathf.Clamp((currentValX - previousValX), -1, 1));
        }
        previousValX = transform.localPosition.z;
    }
}
