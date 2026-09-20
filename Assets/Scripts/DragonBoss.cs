using System;
using UnityEngine;

public class DragonBoss : MonoBehaviour {
    
    private SpriteRenderer tailSprite = null;
    
    public Color tailColor = Color.white;
    public Color hitColor = Color.red;
    
    public float flashOnHitDuration = 0.1f;
    
    private bool gotHit = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tailSprite = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (!gotHit) {
            gotHit = true;
            tailSprite.color = hitColor;
            Invoke("ResetColor", flashOnHitDuration);
        }
    }

    private void ResetColor() {
        tailSprite.color = tailColor;
        gotHit = false;
    }
}
