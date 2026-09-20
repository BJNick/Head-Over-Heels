using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D trigger) {
        if(trigger.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            GameManager.Instance.SaveCheckpointCoords();
        }
    }
}
