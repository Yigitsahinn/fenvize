using System.Collections;
using UnityEngine;

public class PlayerAttackScript : MonoBehaviour
{
    [SerializeField] private GameObject swordCollider;
    private bool canAttack = true;
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
        }
    }

    IEnumerator Attack()
    {
        canAttack = false;
        canMove = false;
        swordCollider.SetActive(true);
        animator.SetBool("attacking", true);
        yield return new WaitForSeconds(1f);
        canAttack = true;
        canMove = true;
        animator.SetBool("attacking", false);
        swordCollider.SetActive(false);

    }

}
