using System;
using UnityEngine;
using UnityEngine.InputSystem;


public class Player : MonoBehaviour {

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Vector2 movement;
    private bool isJumping;

    [SerializeField] float moveSpeed = 5.0f;
    [SerializeField] float jumpSpeed = 5.0f;

    [SerializeField] Transform groundCheck;
    [SerializeField] float groundCheckRadius;
    [SerializeField] LayerMask groundCheckLayerMask;
    private bool isGrounded;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update() {

        /** Physics2D.OverlapCircle is a powerful function in Unity that checks for colliders 
         * within a circular area in your game world. Params = (circleCenter, circleRadius, Layername)
         */
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundCheckLayerMask);

        // Horizontal Movement
        float horizontalInput = movement.x * moveSpeed;
        //float verticalInput = movement.y * moveSpeed; // not used yet 
        rb.linearVelocity = new Vector2(horizontalInput, rb.linearVelocityY);


        // Vertical Jump Movement
        if (isJumping && isGrounded) {
            // For the new Input system, better to use AddForce to stimulate Jump instead of changing linearVelocityY
            rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
            isJumping = false;
        }

    }

    public void OnMove(InputValue value) {
        movement = value.Get<Vector2>();
        Debug.Log(movement);
    }

    public void OnJump(InputValue jump) {
        isJumping = jump.isPressed;
        Debug.Log(isJumping);
    }

}
