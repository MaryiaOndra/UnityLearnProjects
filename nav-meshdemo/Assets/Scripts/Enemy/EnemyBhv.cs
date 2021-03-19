using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBhv : MonoBehaviour
{
    [SerializeField] GameObject deathParticle;

    PlayerBhv player;

    float delayForAttack = 1.5f;
    float delayForDeath = 0.5f;
    float attackStrenght = 15f;
    float timePassed;

    float maxHealth = 100;
    float currentHealth;    

    public event Action<float> OnEnemyHealthChanged = delegate { };
    public event Action<float> OnEnemyAttackStarted = delegate { };

    public float AttackStrenght => attackStrenght;


    private void Awake()
    {
        player = FindObjectOfType<PlayerBhv>();
        currentHealth = maxHealth;
        OnEnemyHealthChanged += CheckForDeath;
    }

    public void TakeDamage(float amount) 
    {
        currentHealth -= amount;
        float currentHealthImg = currentHealth / maxHealth;
        OnEnemyHealthChanged(currentHealthImg);
    }

    public void Attack() 
    {
        player.AnswerAttack(this);

        timePassed += Time.deltaTime;

        if (timePassed >= delayForAttack)
        {
            OnEnemyAttackStarted(delayForAttack);
            player.TakeDamage(attackStrenght);
            timePassed = 0;
        }    
    }

    void CheckForDeath(float health) 
    {
        if (health == 0)
        {
            Instantiate(deathParticle, transform.position, Quaternion.identity);
            Destroy(gameObject, delayForDeath);
        }    
    }
}
