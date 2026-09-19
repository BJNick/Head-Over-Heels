using UnityEngine;

public class ShileldLegsColllision : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D trigger){
        print("Enemy Killed!");
    }

}
