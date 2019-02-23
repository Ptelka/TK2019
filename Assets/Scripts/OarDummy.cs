using System;
using NUnit.Framework;
using UnityEngine;

public class OarDummy : MonoBehaviour
{
    [SerializeField] private Transform target;
    

    void Update()
    {
        transform.LookAt(target);
    }
}
