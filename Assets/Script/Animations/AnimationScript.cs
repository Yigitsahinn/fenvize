using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rb;
    [SerializeField]private float MAX_SPEED;
    void Start()
    {
        animator = this.GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody>();
    }

   
    void Update()
    {
        animator.SetFloat("Speed", (rb.linearVelocity.magnitude * rb.angularVelocity.magnitude) / MAX_SPEED);
    }
    
}
