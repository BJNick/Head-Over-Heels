using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float lifeSpan = 5f;
    [SerializeField] private GameObject gameManager;

    void Start()
    {
        Destroy(gameObject, lifeSpan);
    }

    void OnTriggerEnter2D(Collider2D trigger){
        if(trigger.CompareTag("Player")){
            GameManager.Instance.GameOver();
        }
        Destroy(gameObject);
    }
}
