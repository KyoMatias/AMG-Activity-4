using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SwitchCam : MonoBehaviour
{
    [SerializeField] private Camera playercam;
    [SerializeField] private Camera turretcam;



void Start()
{
    playercam.enabled = true;
    turretcam.enabled = false;
}

    void OnEnable()
    {
       PlayerMovement.EnterTurret += SwitchToTurretCam;

    }

    void OnDisable()
    {
        PlayerMovement.EnterTurret += SwitchToTurretCam;
    
    }
     void SwitchToTurretCam()
    {
            playercam.enabled = false;
            turretcam.enabled = true;
    }
     
    void SwitchToPlayerCam()
    {
            playercam.enabled = !playercam.enabled;
            turretcam.enabled = !turretcam.enabled;
    }
    
    }


