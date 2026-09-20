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
    private Vector3 startPosition;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        camStartPosition = Camera.main.transform.position;
        startPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        var diff = Camera.main.transform.position - camStartPosition;
        var scrollX = startPosition.x - Mathf.Repeat(diff.x * scrollRatio, resetEvery);
        var scrollY = startPosition.y - (diff.y * scrollRatioY);
        transform.localPosition = new Vector3(scrollX, scrollY, transform.localPosition.z);

    }
}
