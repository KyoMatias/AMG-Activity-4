using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class RangeDetect : MonoBehaviour
{
    [SerializeField] private GameObject Range;

    float r;
    float g;
    float b;

    [SerializeField] private PlayerMovement PlayerMode;

      public delegate void SwitchMode();
    public static SwitchMode Switch2Player;
    public static SwitchMode Switch2Turret;


    public void IntiateEnter()
    {
        Color RangeHover = new Color(0.67f, 1.0f, 0.26f, 0.20f);
            Debug.Log("Player Has been detected by Turret");
            var RangeColor= Range.GetComponent<Renderer>();
          RangeColor.material.SetColor("_Color", RangeHover );
         PlayerMovement.Initialize?.Invoke();
    }
}
