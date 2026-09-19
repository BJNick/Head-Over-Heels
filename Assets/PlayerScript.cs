using Unity.VisualScripting;
using UnityEngine;

public class PlayerScript : MonoBehaviour {
    private Rigidbody2D rb;
    public float speed = 5f;
    public float jumpForce = 10f;
    
    private Vector3 startPosition;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update() {
        float velX = (Input.GetAxis("Horizontal") * speed);
        rb.linearVelocityX = velX * speed;
        
        if (Input.GetKeyDown(KeyCode.Space)) {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.R)) {
            transform.position = startPosition;
            rb.linearVelocity = Vector3.zero;
        }
    }
}
