using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

// PlayerMovement class handles player movement and control-related logic
public class PlayerMovement : MonoBehaviour
{
    // Player attributes
    [Header("Player Attributes")]
    public float MoveSpeed; // Movement speed of the player
    [SerializeField] private float m_PlayerHealth; // Player's health
    private const float depriciation = 10f; // Depreciation rate for player's health

    [SerializeField] private bool m_IsControl; // Flag to check if the player has control

    // Delegates for game modes
    public delegate void PlayMode();
    public static PlayMode EnterTurret;
    public static PlayMode Initialize;
    public static PlayMode Live;
    public static PlayMode InitControl;
    public static PlayMode DisableControl;

    /*
        PROF NOTES: Better to not use Static variables as they are very heavy and can cause a lot of problems on the scripts
        Better to think of another method to reiterate a better event system without trying to use the static parameter.
        
        - Unity Event System []
        - Game Mode Switch []
        -Invoking and CancelInvoke Parameters
        -Getter and Setter Functions.

        Read On Tutorials and Youtube Videos on how to [Select Gamemode and Implementing Unity Events]

    */

    // Current game mode
    public Gamemode mode;

    // Subscribe to event handlers
    void OnEnable()
    {
        Initialize += TurretInitialize;
        Live += Controls;
        InitControl += ControllerToggle;
    }

    // Unsubscribe from event handlers
    void OnDisable()
    {
        InitControl -= ControllerToggle;
    }

    // Awake is called when the script is first loaded
    private void Awake()
    {
        m_PlayerHealth = 100; // Initialize player health
        MoveSpeed = 10; // Initialize movement speed
        m_IsControl = false; // Initialize control flag
    }

    // Toggle player control
    void ControllerToggle()
    {
        m_IsControl = true;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        CheckControlAvailability();
    }

    // Check if the player has control and invoke the appropriate game mode
    void CheckControlAvailability()
    {
        if (m_IsControl)
        {
            Live?.Invoke();
        }
        CancelInvoke("Controls");

        Debug.Log("Player Control Disconnected");
    }

    // Player controls for movement
    void Controls()
    {
        // Move player left to right
        float MoveX = Input.GetAxis("Horizontal") * MoveSpeed;
        transform.Translate(MoveX * Time.deltaTime, 0, 0);

        // Move player up and down
        float MoveY = Input.GetAxis("Vertical") * MoveSpeed;
        transform.Translate(0, 0, MoveY * Time.deltaTime);
    }

    // Initialize turret mode
    public void TurretInitialize()
    {
        if (Input.GetKey(KeyCode.F))
        {
            Debug.Log("ENTERING TURRET");
            EnterTurret?.Invoke();
            m_IsControl = false;
        }
    }
}