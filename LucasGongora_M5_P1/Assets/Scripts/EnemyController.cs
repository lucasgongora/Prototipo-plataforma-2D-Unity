using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    [SerializeField] private GameObject enemyImpact;
    private Transform enemyTransform;

    private PlayerController playerDeath;

    private void Start()
    {
        playerDeath = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    void Awake()
    {
        enemyTransform = GetComponent<Transform>();
    }   
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Arrow"))
        {
            Instantiate(enemyImpact, enemyTransform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        if (other.CompareTag("Player"))
        {
            playerDeath.Death();
        }
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
