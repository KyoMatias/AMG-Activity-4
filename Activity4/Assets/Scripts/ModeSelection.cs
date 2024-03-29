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
  PlayerMain = 0,
  TurretMain = 1,
  TutorialMain = 2,

}
public class ModeSelection : MonoBehaviour
{
  /*
  [IMPORTANT!] Restructure and rework the gamemode system, restructure it to have a setter and initializing parameter to Select and set the gamemode.
  -Remove Toggle[] variable and replace it with a more reliable and easier method to set and create a list of Gamemodes.
  -Replace OnToggleChanged Function to have a FixedUpdate() Parameter to check and update the Gamemode Variable what gamemode is currently set and active.
  -Restructure and reformat the code to be more readable and prevent spaghetti code and uneven Structures. [/]
  */
 public delegate void SelectMode();
  public static SelectMode Player;
  public static SelectMode Turret;
  public static SelectMode Tutorial;
[SerializeField] private TextMeshProUGUI getCurrentGamemode;

  void Awake()
  {
    DefaultMode();
  }

  void Start()
  {
    Player += PlayerMode;
    Turret += TurretMode;
    Tutorial += TutorialMode;
  }
  void FixedUpdate()
  {
  }
  private void ChangeGamemmode(int GMValue)
  {
    Gamemode currentGameMode = (Gamemode)GMValue;

      switch(currentGameMode)
      {
          case Gamemode.PlayerMain:
          Debug.Log($"Current Gamemode is : {currentGameMode}");
          getCurrentGamemode.text = currentGameMode.ToString();
          break;

          case Gamemode.TurretMain:
          Debug.Log($"Current Gamemode is : {currentGameMode}");
          getCurrentGamemode.text = currentGameMode.ToString();
          break;

          case Gamemode.TutorialMain:
          Debug.Log($"Current Gamemode is : {currentGameMode}");
          getCurrentGamemode.text = currentGameMode.ToString();
          break;
          default:
          break;
        
      }
  }
  
// Mode Functions
void DefaultMode()
{
  ChangeGamemmode(0);
}
  void PlayerMode()
  {
    ChangeGamemmode(0);
  }

  void TurretMode()
  {
    ChangeGamemmode(1);
  }

  void TutorialMode()
  {
    ChangeGamemmode(2);
  }


}


    //Exectute scripts to toggle and select gamemodes
    
    /* =Gamemode Setter [/]
        -Gamemode Checker
        -Gamemode Updater
        -Lock Gamemode
      
      = Switch between Turret Mode, Player Mode and Tutorial Mode.
        - Enable and Disable UI
        - Little storyltelling scripts and function.

    */