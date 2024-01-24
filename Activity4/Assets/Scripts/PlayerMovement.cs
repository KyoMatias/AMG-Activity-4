using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{


[Header("Player Attributes")]
    public float MoveSpeed;
    [SerializeField] private float m_PlayerHealth;
    private const float depriciation = 10f;
    
 
    public delegate void PlayMode();
    public static PlayMode EnterTurret;

    public static PlayMode Initialize;

    void Start()
    {
        Initialize += TurretInitialize;
    }




    private void Awake()
    {
        m_PlayerHealth = 100;
        MoveSpeed = 10;
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        Controls();
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
        }
    }



}

