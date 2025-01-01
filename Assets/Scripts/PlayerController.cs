using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Scripting;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1;

    private PlayerControls playerControls;
    private Vector2 movement; // stores values coming in from user
    private Rigidbody2D rb;

    private void Awake()
    {
        playerControls = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    private void Update()
    {
        PlayerMovement();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void PlayerMovement()
    {
        // reads the value of the playercontrols movementr Move value that we setup in the Action Map
        movement = playerControls.Movement.Move.ReadValue<Vector2>();
        Debug.Log(movement.x);
    }

    private void Move()
    {
        rb.MovePosition(rb.position + movement * (moveSpeed * Time.fixedDeltaTime));
        
    }


}
