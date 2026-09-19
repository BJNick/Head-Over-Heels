using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class BackgroundPan : MonoBehaviour
{
    public float scrollRatio = 0.5f;
    public float scrollRatioY = 0.5f;
    public float resetEvery = 10f;
    
    private Vector3 camStartPosition;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        camStartPosition = Camera.main.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        var diff = Camera.main.transform.position - camStartPosition;
        var scrollX = (Camera.main.transform.position.x - Mathf.Repeat(diff.x * scrollRatio, resetEvery));
        var scrollY = (Camera.main.transform.position.y - diff.y * scrollRatioY);
        transform.position = new Vector3(scrollX, scrollY, transform.position.z);

    }
}
