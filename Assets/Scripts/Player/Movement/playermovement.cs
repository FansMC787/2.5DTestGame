using System;
using Unity.VisualScripting;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.InputSystem;

public class playermovement : MonoBehaviour
{
    private Vector2 MoveInput;

    private void OnEnable() => MoveAction.Enable();
    private void OnDisable() => MoveAction.Disable();

    private bool TouchGround;

    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform GroundCheck;
    [SerializeField] private LayerMask GroundLayer;
    [SerializeField] private InputAction MoveAction;
    [SerializeField] private float Radius = 0.2f;

    [SerializeField] private float speed = 8f;

    
    
    

   

    // Update is called once per frame
    void Update()
    {
        MoveInput = MoveAction.ReadValue<Vector2>();
        TouchGround = isgrounded();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector3(MoveInput.x * speed, rb.linearVelocity.y, MoveInput.y * speed);
    }
    private bool isgrounded ()
    {
        return Physics.CheckSphere(GroundCheck.position, Radius , GroundLayer);
    }
    

        }

