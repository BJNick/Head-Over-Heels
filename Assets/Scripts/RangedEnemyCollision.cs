using UnityEngine;

public class RangedEnemyCollision : MonoBehaviour
{
    public float destroyDelay = 1f;
    [SerializeField] private GameObject gameManager;
    private bool collisionOn = true;

    void OnTriggerEnter2D(Collider2D trigger){
        if(trigger.gameObject.layer == LayerMask.NameToLayer("Heel")){
            collisionOn = false;
            Destroy(transform.gameObject, destroyDelay);
        }
        else if(trigger.gameObject.layer == LayerMask.NameToLayer("Player") && collisionOn){
            GameManager.instance.GameOver();
        }
    }
}
