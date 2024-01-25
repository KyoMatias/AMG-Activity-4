using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public enum Gamemode
{
  PlayerMain,
  TurretMain,
  CinematicMain

}



public class ModeSelection : MonoBehaviour
{
  [SerializeField]  private Toggle[] m_toggleGM;
  [SerializeField] private Gamemode m_InitialGamemode;

  private Gamemode _currentGameMode;




  void Awake()
  {
    _currentGameMode = m_InitialGamemode;
    SetGameMode(_currentGameMode);
  }

  public void OnToggleChanged(int toggleIndex)
  {
    if(m_toggleGM[toggleIndex].isOn)
    {
      _currentGameMode =(Gamemode)toggleIndex;
      SetGameMode(_currentGameMode);
    }
  }

   private void SetGameMode(Gamemode gm)
    {
      switch(gm)
      {
        case Gamemode.PlayerMain:
        PlayerMovement.Live?.Invoke();
        PlayerMovement.InitControl?.Invoke();
        break;

        case Gamemode.TurretMain:
        PlayerMovement.EnterTurret?.Invoke();
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

}

