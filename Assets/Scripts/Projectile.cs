using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float lifeSpan = 5f;

    void Start()
    {
        Destroy(gameObject, lifeSpan);
    }

    void OnTriggerEnter2D(Collider2D trigger){
        if(trigger.CompareTag("Player")){
            print("The player has died!");
        }
        Destroy(gameObject);
    }
}
