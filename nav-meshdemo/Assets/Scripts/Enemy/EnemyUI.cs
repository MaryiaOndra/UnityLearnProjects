using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyUI : MonoBehaviour
{
    [SerializeField]
    Image healthLineImg;

    [SerializeField]
    Image attackTimeImg;   
    
    [SerializeField]
    TMP_Text attackStrenght;

    EnemyBhv enemyBhv;

    void Start()
    {
        enemyBhv = GetComponentInParent<EnemyBhv>();
        enemyBhv.OnEnemyHealthChanged += HandleHealthChanged;
        enemyBhv.OnEnemyAttackStarted += HandleAttackChanged;
        attackStrenght.text = Mathf.Abs(enemyBhv.AttackStrenght).ToString();
    }

    void HandleHealthChanged(float img) 
    {
        healthLineImg.fillAmount = img;
    }

    void HandleAttackChanged(float img) 
    {
        StartCoroutine(ChangeAttackDelayToImg(img));
    }

    private IEnumerator ChangeAttackDelayToImg(float attackDelay) 
    {
        float max = 1f;
        float min = 0f;
        float elapsed = 0f;

        while (elapsed < attackDelay)
        {
            elapsed += Time.deltaTime;
            attackTimeImg.fillAmount = Mathf.Lerp(min, max, elapsed / attackDelay);
            yield return null;
        }

        attackTimeImg.fillAmount = min;
    }

    private void LateUpdate()
    {
        transform.LookAt(Camera.main.transform);
        transform.Rotate(0, 180, 0);
    }
}
