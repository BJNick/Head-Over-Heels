using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    
    private float smoothVelocity = 0f;
    public float smoothSpeed = 10f;

    public GameObject projectilePrefab;
    
    public Vector3 projectileSpawnOffset = new Vector3(1f, 0f, 0.1f);
    public float projectileAngle = 0f;
    
    public float projectileBoost = 10f;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        startPosition = transform.position;
        smoothVelocity = speed;
    }

    // Update is called once per frame
    void Update() {
        float velX = ((Input.GetAxis("Horizontal")+1) * speed);
        float slideTime = Time.time - slideStartTime;
        
        if (isSliding) {
            velX *= slideSpeed;
        }
        
        var raycastHit = Physics2D.Raycast(transform.position+Vector3.left * (1.1f), Vector2.down, 2.2f, LayerMask.GetMask("Default"));
        if (!raycastHit) {
            raycastHit = Physics2D.Raycast(transform.position+Vector3.right * (1.1f), Vector2.down, 2.2f, LayerMask.GetMask("Default"));
        }
        bool grounded = raycastHit && raycastHit.collider;
        animator.SetBool("Fall", !grounded && rb.linearVelocityY < 0);
        animator.SetBool("Grounded", grounded);
        
        smoothVelocity = Mathf.Lerp(smoothVelocity, velX, Time.deltaTime * smoothSpeed);
        
        rb.linearVelocityX = smoothVelocity;
        
        animator.speed = Input.GetAxis("Horizontal")+1;
        
        if (grounded && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))) {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            animator.SetTrigger("Jump");
        }
        if (Input.GetKeyDown(KeyCode.R)) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
        
        if (Input.GetKeyDown(KeyCode.F) && !HeelProjectile.heelInScene) {
            var obj = Instantiate(projectilePrefab, transform.position + projectileSpawnOffset, Quaternion.identity);
            obj.GetComponent<Rigidbody2D>().linearVelocity = (rb.linearVelocityY * Vector3.up) + (smoothVelocity + projectileBoost) * (Quaternion.Euler(0f, 0f, projectileAngle) * Vector3.right);
        }
    }

    public void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position + (Vector3)projectileSpawnOffset, transform.position + (Vector3)projectileSpawnOffset + Quaternion.Euler(0f, 0f, projectileAngle) * Vector3.right);
        Gizmos.DrawLine(transform.position + Vector3.left * (1.1f), transform.position + Vector3.left * (1.1f) + Vector3.down * 2.2f);
    }
}
