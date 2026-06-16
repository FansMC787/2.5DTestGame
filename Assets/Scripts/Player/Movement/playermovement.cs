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
    
    

   

    // Update is called once per frame
    void Update()
    {
        MoveInput = MoveAction.ReadValue<Vector2>();
        

        TouchGround = isgrounded();
        if (TouchGround)
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector3(MoveInput.x * speed, rb.linearVelocity.y, MoveInput.y * speed);
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

