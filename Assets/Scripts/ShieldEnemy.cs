using UnityEngine;

public class ShieldEnemy : MonoBehaviour
{
    private Rigidbody2D rb;
    float playerXCoord;
    float movementSpeed = -2f;
    float velX;
    Camera cam;
    float camera_width;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
        float camera_height = cam.orthographicSize * 2f;
        camera_width = camera_height * cam.aspect;
        
    }

    // Update is called once per frame
    void Update()
    {
        playerXCoord = GameObject.Find("Player").transform.position.x;
        if((rb.position.x - playerXCoord) <= camera_width){
            velX = ((Input.GetAxis("Horizontal")-1) * movementSpeed);
            rb.linearVelocityX = velX * movementSpeed;
        }
    }
}
