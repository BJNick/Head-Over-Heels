using System;
using UnityEngine;

public class BarrelScript : MonoBehaviour
{
    public ParticleSystem barrelExplosion;
    public SpriteRenderer barrelSprite;
    public Collider2D collider;

    private bool dead = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (!dead && other.gameObject.layer == LayerMask.NameToLayer("Heel")) {
            dead = true;
            barrelSprite.enabled = false;
            collider.enabled = false;
            barrelExplosion.Play();
            Invoke("DestroyBarrel", 0.5f);
        }
    }
}
