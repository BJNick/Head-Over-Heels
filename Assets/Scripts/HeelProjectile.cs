using Unity.Mathematics.Geometry;
using UnityEngine;

public class HeelProjectile : MonoBehaviour {
    
    public static bool heelInScene = false;
    
    private Rigidbody2D rb;

    private GameObject smear;
    
    public float fallOffAfter = 3f;
    
    private float spawnTime;

    public int maxHits = 3;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb.linearVelocityX == 0) {
            rb.linearVelocityX = 30;
        }
        smear = transform.Find("Smear").gameObject;
        spawnTime = Time.time;
        heelInScene = true;
    }

    // Update is called once per frame
    void Update() {
        var velVector = rb.linearVelocity;
        // rotate that vector by 90 degrees around the Z axis
        Vector3 rotatedVectorToTarget = Quaternion.Euler(0, 0, 90) * velVector;
        // get the rotation that points the Z axis forward, and the Y axis 90 degrees away from the target
        // (resulting in the X axis facing the target)
        Quaternion targetRotation = Quaternion.LookRotation(forward: Vector3.forward, upwards: rotatedVectorToTarget);
        smear.transform.rotation = Quaternion.RotateTowards(smear.transform.rotation, targetRotation, 2*90 * Time.deltaTime);

        if (velVector.magnitude < 20f || Time.time - spawnTime > fallOffAfter || maxHits <= 0) {
            rb.GetComponent<Collider2D>().enabled = false;
            smear.SetActive(false);
            heelInScene = false;
        }

        if (Camera.main.transform.position.y - transform.position.y > 30) {
            heelInScene = false;
            Destroy(this.gameObject);
        }
        if (Mathf.Abs(Camera.main.transform.position.x - transform.position.x) > 30) {
            heelInScene = false;
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        maxHits -= 1;
    }
}
