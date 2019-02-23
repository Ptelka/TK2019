
using System;
using UnityEngine;

public static class InputWrapper
{
    public static string LeftAxisX = "LeftStickX";
    public static string LeftAxisY = "LeftStickY";
    public static string RightAxisX = "RightStickX";
    public static string RightAxisY = "RightStickY";
    public static string LeftAttack = "LeftAttack";
    public static string RightAttack = "RightAttack";

    public static float GetAxis(string axis, int controller) {
        return Input.GetAxis(controller + axis);
    }
}
