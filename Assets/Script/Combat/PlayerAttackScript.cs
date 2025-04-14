using System.Collections;
using UnityEngine;

public class PlayerAttackScript : MonoBehaviour
{
    [SerializeField] private GameObject swordCollider;
    public bool canAttack = true;
    [HideInInspector]public bool canMove = true;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (canAttack == true && Input.GetKey(KeyCode.Mouse0))
        {
            StartCoroutine(Attack());
            //StartCoroutine(AttackAnimation());
        }
    }

    IEnumerator Attack()
    {
        animator.SetBool("attacking", true);
        yield return new WaitForSeconds(0.2f);
        canAttack = false;
        canMove = false;
        swordCollider.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        swordCollider.SetActive(false);
        yield return new WaitForSeconds(0.25f);
        animator.SetBool("attacking", false);
        canAttack = true;
        canMove = true;
    }
    //IEnumerator AttackAnimation()
    //{
    //    animator.SetBool("attacking", true);
    //    yield return new WaitForSeconds(0.75f);
    //    animator.SetBool("attacking", false);
    //    canAttack = true;
    //    canMove = true;
    //}


}
