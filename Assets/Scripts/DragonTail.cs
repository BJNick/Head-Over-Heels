using UnityEngine;

public class DragonTail : MonoBehaviour
{
    public Vector3 startPosition;

    public float offsetValue = 0.5f;
    public float smoothnessValue = 0.5f;
    public float maxOffset = 10f;
    public float defaultOffset = 1f;
    public float defaultSpeed = 20f;
    
    private Rigidbody2D playerBody;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPosition = transform.localPosition;
        playerBody = GameObject.Find("Player").GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var offset = Mathf.Clamp((playerBody.linearVelocityX - defaultSpeed) * offsetValue + defaultOffset, 0, maxOffset);
        transform.localPosition = Vector3.Lerp(transform.localPosition, startPosition + offset*Vector3.right, smoothnessValue);
    }
}
