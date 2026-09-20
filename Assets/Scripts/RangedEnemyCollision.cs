using UnityEngine;

public class RangedEnemyCollision : MonoBehaviour
{
    public float destroyDelay = 1f;
    private bool collisionOn = true;

    void OnCollisionEnter2D(Collision2D trigger){
        if(trigger.collider.gameObject.layer == LayerMask.NameToLayer("Heel")){
            collisionOn = false;
            //Destroy(transform.gameObject, destroyDelay);
            Invoke("DisableCollider", destroyDelay);
        }
        else if(trigger.collider.gameObject.layer == LayerMask.NameToLayer("Player") && collisionOn){
            GameManager.Instance.GameOver();
        }
    }
    
    void DisableCollider(){
        transform.GetComponent<Collider2D>().enabled = false;
    }
}
