using Unity.VisualScripting;
using UnityEngine;

public class PlayerScript : MonoBehaviour {
    private Rigidbody2D rb;
    public float speed = 5f;
    public float jumpForce = 10f;
    
    public float slideSpeed = 2f;
    public float minSlideDuration = 0.5f;
    public float maxSlideDuration = 3f;
    public float slideTimeout = 1f;
    private float slideStartTime = -1f;
    private float slideStopTime = -1f;
    private bool isSliding = false;
    
    private Vector3 startPosition;
    
    private Animator animator;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update() {
        float velX = ((Input.GetAxis("Horizontal")+1) * speed);
        float slideTime = Time.time - slideStartTime;
        
        if (isSliding) {
            velX *= slideSpeed;
        }
        
        rb.linearVelocityX = velX * speed;
        
        animator.speed = Input.GetAxis("Horizontal")+1;
        
        if (Input.GetKeyDown(KeyCode.Space)) {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.R)) {
            transform.position = startPosition;
            rb.linearVelocity = Vector3.zero;
        }
        if (Input.GetKey(KeyCode.S) && !isSliding && (Time.time - slideStopTime >= slideTimeout)) {
            animator.SetBool("Slide", true);
            slideStartTime = Time.time;
            isSliding = true;
        }
        else if (isSliding && ((Input.GetKeyUp(KeyCode.S) && slideTime >= minSlideDuration) ||
                          (slideTime >= maxSlideDuration))) {
            animator.SetBool("Slide", false);
            isSliding = false;
            slideStopTime = Time.time;
        }
    }
}
