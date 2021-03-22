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
    int attackStrenght = -15;
    [SerializeField]
    GameObject attackParticle;

    float maxHealth = 100;
    float currentHealth;
    float delayForDeath = 0.5f;
    float attackDelay = 1f;
    float elapsedTime = 0f;

    Animator playerAnimator;
    BottleController bottle;
    GameObject activeBottle;

    public event Action<float> OnHealthChanged = delegate { };
    public bool IsAttacked { get; set; }

    private void Awake()
    {
        playerAnimator = GetComponent<Animator>();
        bottle = FindObjectOfType<BottleController>();

        currentHealth = maxHealth;
    }

    public void ChangeHealth(float amount)
    {
        currentHealth += amount;
        float currentHealthImg = currentHealth / maxHealth;
        OnHealthChanged(currentHealthImg);
        CheckForDeath(currentHealthImg);
    }

    public void AnswerAttack(EnemyBhv enemy) 
    {
        RotateTowardsTarget(enemy);


        elapsedTime += Time.deltaTime;

        if (elapsedTime >= attackDelay)
        {
            playerAnimator.SetBool("isAttack", true);
            attackParticle.SetActive(true);
            enemy.ChangeHealth(attackStrenght);         
            elapsedTime = 0;
        }     
    }

    public void BeIdle() 
    {
        playerAnimator.SetBool("isAttack", false);
        attackParticle.SetActive(false);
    }

    void CheckForDeath(float health)
    {
        if (health <= 0)
        {
            Instantiate(deathParticle, transform.position, Quaternion.identity);
            Destroy(gameObject, delayForDeath);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else if (health <= 0.5f)
        {
            activeBottle = bottle.Appear();
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

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);

        if (other.gameObject == activeBottle)
        {
            ChangeHealth(30f);
            bottle.DestroyBottle();
        }
    }
}
 