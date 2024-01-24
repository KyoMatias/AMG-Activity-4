using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{


[Header("Player Attributes")]
    public float MoveSpeed;
    [SerializeField] private float m_PlayerHealth;
    private const float depriciation = 10f;

    [SerializeField] private bool m_IsControl;
    
 
    public delegate void PlayMode();
    public static PlayMode EnterTurret;

    public static PlayMode Initialize;

    public static PlayMode Live;

    public static PlayMode InitControl;

    public static PlayMode DisableControl;


    void OnEnable()
    {
        Initialize += TurretInitialize;
        Live += Controls;
        InitControl += ControllerToggle;
        
    }

    void OnDisable()
    {
                InitControl -= ControllerToggle;
    }



    private void Awake()
    {
        m_PlayerHealth = 100;
        MoveSpeed = 10;
        m_IsControl = false;
    }
void ControllerToggle()
{
    m_IsControl = true;
}
    // Update is called once per frame
    private void FixedUpdate()
    {
        CheckControlAvailability();
    }


    void CheckControlAvailability()
    {
        if(m_IsControl)
        {
            Live?.Invoke();
        }
        CancelInvoke("Controls");


        Debug.Log("Player Control DIsconnected");
    }
    void Controls()
    {
        //Move Player left to right
        float MoveX = Input.GetAxis("Horizontal") * MoveSpeed;
        transform.Translate(MoveX * Time.deltaTime, 0, 0);

        //Move Player up and down
        float MoveY = Input.GetAxis("Vertical") * MoveSpeed;
        transform.Translate(0, 0, MoveY * Time.deltaTime);
    }
    
    public void TurretInitialize ()
    {
        if(Input.GetKey(KeyCode.F)){
            Debug.Log("ENTERING TURRET");
            EnterTurret?.Invoke();
            m_IsControl = false;;

        }
    }



}

