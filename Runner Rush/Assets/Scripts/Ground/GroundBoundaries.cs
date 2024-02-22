using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundBoundaries : MonoBehaviour
{
    public static float leftBoundary = -3f;
    public static float rightBoundary = 3f;
    public float leftBounValue;
    public float rightBounValue;

    void Update()
    {
        leftBounValue = leftBoundary;
        rightBounValue = rightBoundary;
    }
}
