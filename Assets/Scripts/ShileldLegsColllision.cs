using UnityEngine;

public class ShileldLegsColllision : MonoBehaviour
{
    public float torqueAmount = 10f;
    public Vector3 forceAmount;

    void OnCollisionEnter2D(Collision2D collision){
        if (collision.collider.name == "HeelCollider") {
            //Destroy(transform.parent.gameObject);
            transform.parent.GetComponent<Collider2D>().enabled = false;
            collision.otherCollider.enabled = false;
            transform.parent.GetComponent<Rigidbody2D>().freezeRotation = false;
            transform.parent.GetComponent<Rigidbody2D>().AddTorque(torqueAmount);
            transform.parent.GetComponent<Rigidbody2D>().AddForce(forceAmount, ForceMode2D.Impulse);
        }
    }

}
