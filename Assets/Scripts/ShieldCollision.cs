using UnityEngine;

public class ShieldCollision : MonoBehaviour
{

    [SerializeField] private GameObject gameManager;

    void OnTriggerEnter2D(Collider2D trigger){
        if(trigger.CompareTag("Player")){
            GameManager.instance.GameOver();
        }
        else{
            print("BLOCKED");
        }
    }
}
