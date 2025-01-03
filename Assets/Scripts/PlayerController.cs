using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Scripting;


public class PlayerController : MonoBehaviour
{
    public bool FacingLeft { get { return isFacingLeft; } set { isFacingLeft = value; } }

    [SerializeField] private float moveSpeed = 1;

    private PlayerControls playerControls;
    private Vector2 movement; // stores values coming in from user
    private Rigidbody2D rb;
    private Animator myAnimator;
    private SpriteRenderer mySpriteRenderer;

    private bool isFacingLeft = false;

    private void Awake()
    {
        playerControls = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
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
        PlayerInput();
    }

    private void FixedUpdate()
    {
        FlipPlayer();
        Move();
    }

    private void PlayerInput()
    {
        movement = playerControls.Movement.Move.ReadValue<Vector2>();
        myAnimator.SetFloat("moveX", movement.x);
        myAnimator.SetFloat("moveY", movement.y);
    }

    private void Move()
    {
        rb.MovePosition(rb.position + movement * (moveSpeed * Time.fixedDeltaTime));

    }

    void FlipPlayer()
    {

        Vector3 mousePos = Input.mousePosition;
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(transform.position);

        //if(mousePos.x < playerScreenPoint.x)
        //{
        //    mySpriteRenderer.flipX = true;
        //    FacingLeft = true;
        //}
        //else
        //{
        //    mySpriteRenderer.flipY = false;
        //    FacingLeft = false;
        //}

        //Vector3 mousePos = Mouse.current.position.ReadValue();
        //Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(transform.position);
        //mySpriteRenderer.flipX = mousePos.x < playerScreenPoint.x;


        if (mousePos.x < playerScreenPoint.x)
        {

            gameObject.transform.localScale = new Vector3(-1, 1, 1);



        }
        else
        {

            gameObject.transform.localScale = new Vector3(1, 1, 1);

        }
    }

}