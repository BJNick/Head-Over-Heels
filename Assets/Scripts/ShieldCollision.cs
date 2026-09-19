using UnityEngine;

public class ShieldCollision : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D trigger){
        if(trigger.CompareTag("Player")){
            print("BONK");
        }
        else{
            print("BLOCKED");
        }
    }
}
