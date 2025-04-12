using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private EnemyData data;
    [SerializeField] private Shop shop;
    public float health;
    [HideInInspector] public int coin;

   
    PlayerStats stats;

    private void Start()
    {
        stats = Player.instance.playerStats;
        SetValues();
    }

    void Update()
    {
        Death();
    }

    private void SetValues()
    {
        health = data.hp;
        coin = data.coin;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Sword"))
        {
            health = health - stats.damage;
        }
    }

    private void Death()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
            stats.coins = stats.coins + data.coin;
        }
    }
}
