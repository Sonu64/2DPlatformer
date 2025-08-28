using System;
using UnityEngine;
using UnityEngine.InputSystem;


public class fun : MonoBehaviour
{

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Vector2 movement;
    private bool isFiring;

    [SerializeField] float moveSpeed = 5.0f;
    [SerializeField] GameObject enemy;



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

        if (isFiring) { 
            sr.color = Color.yellow;
            if (enemy != null) 
                Destroy(enemy);
        }
    }

    public void OnMove(InputValue value) {
        movement = value.Get<Vector2>();
        Debug.Log(movement);
    }

    public void OnFire(InputValue value) { 
        isFiring = value.isPressed;
    }

}
