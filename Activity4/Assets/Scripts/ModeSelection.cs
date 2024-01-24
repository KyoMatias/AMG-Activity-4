using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ModeSelection : MonoBehaviour
{
    public GameObject[] Modes;

    private GameObject m1;
    private GameObject m2;

    private GameObject m3;

    private GameObject m4;

    private GameObject m5;

     public int GamemodeNum;


    public delegate void ChooseGM();
    public static ChooseGM GM1;
    public static ChooseGM GM2;
  void Start()
  {
  GamemodeNum = 0;
    GM1 += Mode1;

    GM2 += Mode2;
  }

  void FixedUpdate()
  {
    CheckGamemode();
    
  }

void CheckGamemode()
{
        int Index = GamemodeNum;
        switch(Index)
        {
            case 0:
            GM1?.Invoke();
            break;
            
            case 1:
            GM2?.Invoke();
            break;

            case 2:
            break;

            case 3:
            break;

            case 4:
            break;

            default:
            print("FATAL GAMEMODE NOT FOUND");
            break;

        
    }
}
     void Mode1()
    {
        PlayerMovement.InitControl?.Invoke();
        Debug.Log($"GAMEMODE: {m1} Initialized");
        
    }

    void Mode2()
    {
        Debug.Log("Controls Disabled");
    }


}
