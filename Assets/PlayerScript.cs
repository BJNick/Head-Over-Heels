using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Rigidbody2D rb;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = Vector2.right * Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space)) {
            rb.AddForce(Vector2.up * 10f, ForceMode2D.Impulse);
        }
    }
}
