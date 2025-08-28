using UnityEngine;

public class fun : MonoBehaviour
{

    private Rigidbody2D rb;
    private SpriteRenderer sr;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        rb.isKinematic = true;
    }

    // Update is called once per frame
    void Update() {
        
    }

    private void OnMouseDown() {
        sr.color = Color.green;
        rb.isKinematic = false;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        Destroy(collision.gameObject);
    }
}
