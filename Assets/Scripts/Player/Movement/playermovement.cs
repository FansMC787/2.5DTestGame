using System;
using Unity.VisualScripting;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.InputSystem;

public class playermovement : MonoBehaviour
{
    private Vector2 MoveInput;
    

    

    private bool TouchGround;

    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform GroundCheck;
    [SerializeField] private LayerMask GroundLayer;
    [SerializeField] private InputAction MoveAction;
    [SerializeField] private InputAction JumpAction;
    [SerializeField] private float Radius = 0.2f;
    [SerializeField] private float speed = 8f;
    [SerializeField] private float Jumppower = 12f;

    [SerializeField] private float MaxStufenHöhe = 0.3f;
    [SerializeField] private float VorwärtsAbstandTeleport = 0.2f;


   
    
    

   

    // Update is called once per frame
    void Update()
    {
        MoveInput = MoveAction.ReadValue<Vector2>();
        

        TouchGround = isgrounded();
        if (TouchGround && JumpAction.triggered)
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        // Richtung berechnen (Normalisiert für gleichmäßige Geschwindigkeit)
        Vector3 laufRichtung = new Vector3(MoveInput.x, 0f, MoveInput.y).normalized;
        
        float zielX = laufRichtung.x * speed;
        float zielZ = laufRichtung.z * speed;
        float zielY = rb.linearVelocity.y;

       
        if (TouchGround && MoveInput.magnitude > 0.1f && zielY <= 0.1f)
        {
            zielY = 0f;
        }

        rb.linearVelocity = new Vector3(zielX, zielY, zielZ);

        if (MoveInput.magnitude > 0.1f) 
        {
            StufenCheck(laufRichtung);
        }
    }








 private void OnEnable()
    {
        MoveAction.Enable();
        JumpAction.Enable();
    }

   
    private void OnDisable()
    {
        MoveAction.Disable();
        JumpAction.Disable();
    }
    private void StufenCheck(Vector3 richtung)
    {
        Vector3 startPunkt = transform.position + Vector3.up * 0.05f;

        RaycastHit hit;

        if (Physics.Raycast(startPunkt, richtung, out hit, VorwärtsAbstandTeleport, GroundLayer))
        {
            Vector3 obererStartPunkt = transform.position + Vector3.up * MaxStufenHöhe;
            if (!Physics.Raycast(obererStartPunkt, richtung, VorwärtsAbstandTeleport, GroundLayer))
            {
                rb.position += new Vector3(0f, MaxStufenHöhe * 0.5f, 0f) + (richtung * 0.05f);
                
                rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
            }
        }
    }
    private bool isgrounded ()
    {
        return Physics.CheckSphere(GroundCheck.position, Radius , GroundLayer);
    }
    private void Jump()
    {
        rb.linearVelocity = new Vector3(MoveInput.x * speed,Jumppower,rb.linearVelocity.z);
    }

        }

