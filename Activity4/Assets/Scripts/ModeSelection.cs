using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public enum Gamemode
{
  PlayerMain,
  TurretMain,
  TutorialMain

}



public class ModeSelection : MonoBehaviour
{
  /*
  [IMPORTANT!] Restructure and rework the gamemode system, restructure it to have a setter and initializing parameter to Select and set the gamemode.

  -Remove Toggle[] variable and replace it with a more reliable and easier method to set and create a list of Gamemodes.
  -Replace OnToggleChanged Function to have a FixedUpdate() Parameter to check and update the Gamemode Variable what gamemode is currently set and active.
  -Restructure and reformat the code to be more readable and prevent spaghetti code and uneven Structures.

  */


  [SerializeField]  private Toggle[] m_toggleGM;
  [SerializeField] private Gamemode m_InitialGamemode;

  public Gamemode _currentGameMode;

  [SerializeField] private TextMeshProUGUI getgamemmodestatus;

public delegate void Setup();
public static Setup setupPlayerMode;
public static Setup setupTurretMode;

public static Setup setupTutorialMode;


  void Awake()
  {
    _currentGameMode = m_InitialGamemode;
    CheckGameMode(_currentGameMode);
    
    setupPlayerMode = SetupPlayerMode;
    setupTurretMode = SetupTurretMode;
    setupTutorialMode = SetupTutorialMode;

  }

  public void OnToggleChanged(int toggleIndex)
  {
    if(m_toggleGM[toggleIndex].isOn)
    {
      _currentGameMode =(Gamemode)toggleIndex;
      CheckGameMode(_currentGameMode);
    }
  }

   public void CheckGameMode(Gamemode gm)
    {
      switch(gm)
      {
        case Gamemode.PlayerMain:
        PlayerMovement.Live?.Invoke();
        PlayerMovement.InitControl?.Invoke();
        getgamemmodestatus.text = gm.ToString();

        break;

        case Gamemode.TurretMain:
        PlayerMovement.EnterTurret?.Invoke();
        getgamemmodestatus.text = gm.ToString();
        break;
      }
    }

    void Update()
    {
      if(Input.GetKeyDown(KeyCode.P))
      {
        Debug.Log($"The Current Gamemode Is: {_currentGameMode}");
      }
    }

    void SetupPlayerMode()
    {
      OnToggleChanged(0);
    }

    void SetupTurretMode()
    {
      OnToggleChanged(1);
    }

    void SetupTutorialMode()
    {
      OnToggleChanged(2);
    }

}

