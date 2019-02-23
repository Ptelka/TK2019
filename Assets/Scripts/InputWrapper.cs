
using System;
using UnityEngine;

public static class InputWrapper
{
    public static String LeftAxisX = "LeftStickX";
    public static String LeftAxisY = "LeftStickY";
    public static String RightAxisX = "RightStickX";
    public static String RightAxisY = "RightStickY";

    public static float GetAxis(String axis, int controller) {
        return Input.GetAxis(controller + axis);
    }
}
