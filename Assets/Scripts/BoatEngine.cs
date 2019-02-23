﻿using System;
using NUnit.Framework;
using UnityEngine;

public class BoatEngine : MonoBehaviour
{
    public Player owner;
    public float speed;

    private Rigidbody boat;
    private Vector3 basePosition;
    [SerializeField] private int Controller;
    [SerializeField] private int Position;
    private string analogY;
    private string analogX;
    private float previousValX;
    private bool works;

    private void Start()
    {
        boat = owner.Boat;
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
            boat.AddRelativeTorque(new Vector3(0, speed * 5 * Mathf.Clamp((currentValX - previousValX), -1, 1) * (Position == 0 ? 1 : -1)));
            boat.AddForce(owner.transform.forward * speed * Mathf.Clamp((currentValX - previousValX), -1, 1));
        }
        previousValX = transform.localPosition.z;
    }
}
