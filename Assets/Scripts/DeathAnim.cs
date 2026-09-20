using UnityEngine;

public class DeathAnim : MonoBehaviour
{
    public static DeathAnim instance;
    
    private Animator animator;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        instance = this;        
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void PlayDeathAnimation() {
        animator.SetTrigger("Death");
    }
    
    public void AnimationDone() {
        GameManager.instance.Restart();
    }
}
