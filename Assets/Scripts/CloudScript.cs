using UnityEngine;

public class CloudScript : MonoBehaviour
{
    public float scrollRatio = 3f;
    public float scrollRatioY = 0.5f;
    public float destroyBeyond = 20f;
    
    private Vector3 startPosition;
    private Vector3 camPosition;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPosition = transform.position;
        camPosition = Camera.main.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        var diff = Camera.main.transform.position - camPosition;
        var scrollX = startPosition.x + (Camera.main.transform.position.x - diff.x * scrollRatio);
        var scrollY = startPosition.y + (Camera.main.transform.position.y - diff.y * scrollRatioY);
        transform.position = new Vector3(scrollX, scrollY, transform.position.z);
        if (Camera.main.transform.position.x - transform.position.x > destroyBeyond)
        {
            Destroy(gameObject);
        }
    }
}
