using Unity.VisualScripting;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rb;
    [SerializeField] private float MAX_SPEED;

    void Start()
    {
        animator = this.GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody>();
    }


    void Update()
    {
        float speed = rb.linearVelocity.magnitude;
        Debug.Log(speed);
        animator.SetFloat("speed", rb.linearVelocity.magnitude / MAX_SPEED);
    }

}
