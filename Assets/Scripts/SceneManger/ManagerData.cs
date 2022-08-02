using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Manger Data", menuName = "Manger Data")]
public class ManagerData : ScriptableObject
{
    public float CubeSpeed;
    public float PlayerSpeed;
    public float CubeInstantiationLimits = 3f;
    public string PlayerName;
}

