using UnityEngine;

public class EnemyProjectileWeapon : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float speed = 8f;
    public float shotInterval = 1.5f;
    private float shotTimer = 0f;
    public Transform firePoint;

    Rigidbody2D rb;
    float camera_width;
    float playerXCoord;
    Camera cam;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
        float camera_height = cam.orthographicSize * 2f;
        camera_width = camera_height * cam.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        // update shot timer
        if(shotTimer > 0f){
            shotTimer -=Time.deltaTime;
        }

        // check if player is on screen
        if(rb != null){
            playerXCoord = GameObject.Find("Player").transform.position.x;
            if((rb.position.x - playerXCoord) <= camera_width && shotTimer <= 0f){
            Shoot();
            shotTimer = shotInterval;
        }
        }
    }

      void Shoot(){
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        projectile.transform.Rotate(0, 0, 90);
        rb = projectile.GetComponent<Rigidbody2D>();
        if(rb != null){
            rb.AddForce(firePoint.right * -speed, ForceMode2D.Impulse);
        }
    }
}
