using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private EnemyData data;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform spawnPoint;
    [HideInInspector] public float health;
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

    public void Death()
    {
        if (health <= 0)
        {
            StartCoroutine(Respawn());
            stats.coins = stats.coins + data.coin;
        }
    }
    public IEnumerator Respawn()
    {
        gameObject.SetActive(false);
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(true);
    }

}
