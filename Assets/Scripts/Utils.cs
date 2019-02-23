
using System;
using UnityEngine;

public static class Utils {
    static void PrintButton(String button) {
        if (Input.GetButtonDown(button)) {
            Debug.Log(button);
        }
    }
}
