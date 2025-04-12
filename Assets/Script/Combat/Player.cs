using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;
    [HideInInspector] public PlayerAttackScript playerAttack;
    [HideInInspector] public AnimationScript animationScript;
    [HideInInspector] public PlayerController controller;
    [HideInInspector] public PlayerStats playerStats;

    private void Awake()
    {
        instance = this;
        playerAttack = GetComponent<PlayerAttackScript>();
        animationScript = GetComponent<AnimationScript>();
        controller = GetComponent<PlayerController>();
        playerStats = GetComponent<PlayerStats>();
    }
}
