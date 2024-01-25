using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BezierCurve
{
    /// <summary>
    /// PERFORMS quadratic lerp
    /// </summary>
    /// <param name="p0">point 1</param>
    /// <param name="p1">point 2</param>
    /// <param name="p2">point 3</param>
    /// <param name="t"> value should be between 0 and 1</param>
    /// <returns></returns>
    public static Vector3 QuadraticLerp(Vector3 p0, Vector3 p1, Vector3 p2, float t)
    {
        // Clamp the input parameter 't' to be between 0 and 1
        float clampedTime = Mathf.Clamp01(t);

        // Calculate the return vector using the quadratic formula
        Vector3 returnVector = Mathf.Pow((1 - clampedTime), 2) * p0 
            + 2 * (1 - clampedTime) * clampedTime * p1 
            + Mathf.Pow(clampedTime, 2) * p2;

        return returnVector;
    }

    /// <summary>
    /// PERFORMS linear interpolation
    /// </summary>
    /// <param name="p0">point 1</param>
    /// <param name="p1">point 2</param>
    /// <param name="t"> value should be between 0 and 1</param>
    /// <returns></returns>
    public static Vector3 LinearLerp(Vector3 p0, Vector3 p1, float t)
    {
        // Clamp the input parameter 't' to be between 0 and 1
        float clampedTime = Mathf.Clamp01(t);

        // Calculate the return vector using the linear interpolation formula
        Vector3 returnVector = p0 * (1 - clampedTime) + p1 * clampedTime;

        return returnVector;
    }
}