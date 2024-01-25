using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public static class BezierCurve
{
    /// <summary>
    /// PERFORMS  quadratic lerp
    /// </summary>
    /// <param name="p0">point 1</param>
    /// <param name="p1">point 2</param>
    /// <param name="p2">point 3</param>
    /// <param name="t"> value should be between 0 and 1</param>
    /// <returns></returns>

        public static Vector3 QuadraticLerp(Vector3 p0, Vector3 p1, Vector3 p2, float t)
    {
        var clampedTime = Mathf.Clamp01(t);
        var returnVector = Mathf.Pow((1 - clampedTime),2) * p0 
            + 2 * (1 - clampedTime) * clampedTime * p1 
            + Mathf.Pow(clampedTime, 2) * p2;
        return returnVector;
    }
  
}
    



/* Review and rewrite the code from the module pages []
 * improve and add more functions to fully fledge the bezier improvent []
 * GOAL: Be able to make a cube moved through the world, with its ease and follow points [].
 */