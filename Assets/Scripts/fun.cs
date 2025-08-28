using System;
using UnityEngine;
using UnityEngine.InputSystem;


public class fun : MonoBehaviour
{

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Vector2 movement;

    [SerializeField] float moveSpeed = 5.0f;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update() {
        float horizontalInput = movement.x * moveSpeed;
        float verticalInput = movement.y * moveSpeed; // not used yet 
        rb.linearVelocity = new Vector2 (horizontalInput, rb.linearVelocityY);
    }

    public void OnMove(InputValue value) {
        movement = value.Get<Vector2>();
        Debug.Log(movement);
    }

}
