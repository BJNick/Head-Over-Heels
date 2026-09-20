using System;
using UnityEngine;

public class ShileldLegsColllision : MonoBehaviour
{
    public float torqueAmount = 10f;
    public Vector3 forceAmount;

    void OnTriggerEnter2D(Collider2D collider){
        if (collider.name == "HeelCollider") {
            Debug.Log("HeelCollider hit");
            //Destroy(transform.parent.gameObject);
            transform.parent.GetComponent<Collider2D>().enabled = false;
            transform.parent.GetComponent<Rigidbody2D>().freezeRotation = false;
            transform.parent.GetComponent<Rigidbody2D>().AddTorque(torqueAmount);
            transform.parent.GetComponent<Rigidbody2D>().AddForce(forceAmount, ForceMode2D.Impulse);
            transform.parent.GetComponentInChildren<ShieldCollision>().GetComponent<Collider2D>().enabled = false;
        }
    }

}
