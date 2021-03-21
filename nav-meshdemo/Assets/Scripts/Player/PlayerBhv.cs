using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBhv : MonoBehaviour
{
    [SerializeField]
    GameObject deathParticle;
    [SerializeField] 
    GameObject attackParticle;
    [SerializeField]
    float attackStrenght = 15f;

    float maxHealth = 100;
    float currentHealth;
    float delayForDeath = 0.5f;
    float attackDelay = 1f;
    float elapsedTime = 0f;

    public event Action<float> OnHealthChanged = delegate { };

    private void Awake()
    {
        currentHealth = maxHealth;
        OnHealthChanged += CheckForDeath;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        float currentHealthImg = currentHealth / maxHealth;
        OnHealthChanged(currentHealthImg);
    }

    public void AnswerAttack(EnemyBhv enemy) 
    {
        RotateTowardsTarget(enemy);
        Vector3 _particlePos = transform.position + new Vector3(2, 2 , 1 );

        elapsedTime += Time.deltaTime;

        if (elapsedTime >= attackDelay)
        {
            enemy.TakeDamage(attackStrenght);
            Instantiate(attackParticle, _particlePos, transform.rotation);            
            elapsedTime = 0;
        }             
    }

    void CheckForDeath(float health)
    {
        if (health <= 0)
        {
            Instantiate(deathParticle, transform.position, Quaternion.identity);
            Destroy(gameObject, delayForDeath);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void RotateTowardsTarget(EnemyBhv enemy)
    {
        float _speed = 6.28f;
        float _singleStep = _speed * Time.deltaTime;
        Vector3 _targetDirection = enemy.transform.position - transform.position;
        Vector3 _newDirection = Vector3.RotateTowards(transform.forward, _targetDirection, _singleStep, float.PositiveInfinity);
        Debug.DrawRay(transform.position, _newDirection, Color.green);
        transform.rotation = Quaternion.LookRotation(_newDirection);
    }
}
 