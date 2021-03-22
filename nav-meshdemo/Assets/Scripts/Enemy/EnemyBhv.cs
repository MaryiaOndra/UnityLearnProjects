using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyBhv : MonoBehaviour
{
    [SerializeField] 
    GameObject deathParticle;
    [SerializeField]
    GameObject attackParticle;

    PlayerBhv player;

    float delayForAttack = 1.5f;
    float delayForDeath = 0.5f;
    int attackStrenght;
    float timePassed;

    float maxHealth = 100;
    float currentHealth;

    Animator enemyAnim;

    public event Action<float> OnEnemyHealthChanged = delegate { };
    public event Action<float> OnEnemyAttackStarted = delegate { };

    public float AttackStrenght => attackStrenght;


    private void Awake()
    {
        enemyAnim = GetComponent<Animator>();
        player = FindObjectOfType<PlayerBhv>();
        OnEnemyHealthChanged += CheckForDeath;
        currentHealth = maxHealth;
        attackStrenght = Random.Range(-3, -16);
    }

    public void ChangeHealth(float amount) 
    {
        currentHealth += amount;
        float currentHealthImg = currentHealth / maxHealth;
        OnEnemyHealthChanged(currentHealthImg);
    }

    public void Attack() 
    {
        player.AnswerAttack(this); 

        timePassed += Time.deltaTime;

        if (timePassed >= delayForAttack)
        {
            enemyAnim.SetBool("isAttack", true);
            attackParticle.SetActive(true);

            OnEnemyAttackStarted(delayForAttack);
            player.ChangeHealth(attackStrenght);
            timePassed = 0;
        }
    }

    public void BeIdle()
    {
        enemyAnim.SetBool("isAttack", false);
        attackParticle.SetActive(false);
        player.BeIdle();
    }

    void CheckForDeath(float health) 
    {
        if (health <= 0)
        {
            Instantiate(deathParticle, transform.position, Quaternion.identity);
            Destroy(gameObject, delayForDeath);
            player.BeIdle();
        }    
    }
}
