
using System;
using UnityEngine;

public static class InputWrapper
{
    public static string LeftAxisX = "LeftStickX";
    public static string LeftAxisY = "LeftStickY";
    public static string RightAxisX = "RightStickX";
    public static string RightAxisY = "RightStickY";
    public static string LeftAttack = "L1";
    public static string RightAttack = "R1";

    public static float GetAxis(string axis, int controller) {
        return Input.GetAxis(controller + axis);
    }

    public static bool GetButtonDown(string button, int controller)
    {
        return Input.GetButtonDown(controller + button);
    }
}
