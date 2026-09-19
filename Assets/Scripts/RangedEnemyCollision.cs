using UnityEngine;

public class RangedEnemyCollision : MonoBehaviour
{
    public float destroyDelay = 1f;

    void OnTriggerEnter2D(Collider2D trigger){
        if(trigger.gameObject.layer == LayerMask.NameToLayer("Heel")){
            Destroy(transform.gameObject, destroyDelay);
        }
    }
}
