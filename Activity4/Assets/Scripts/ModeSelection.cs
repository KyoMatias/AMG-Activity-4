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

