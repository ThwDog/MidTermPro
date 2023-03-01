using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpEnemy : MonoBehaviour
{
    public Transform objectFollow;
    RectTransform rectTransform;

    public Enemy enemy;

    [Header("HP")]
    public Image hp;
    public Image hpEffect;
    

    [SerializeField] float hpCostSpeed = 0.0005f;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (objectFollow != null)
        {
            rectTransform.anchoredPosition = objectFollow.localPosition;
        }
        hpBar();
    }

    void hpBar()
    {
        hp.fillAmount = enemy.currentHp / enemy.maxHp;
        if (hpEffect.fillAmount > hp.fillAmount)
        {
            hpEffect.fillAmount -= hpCostSpeed;
        }
        else
        {
            hpEffect.fillAmount = hp.fillAmount;
        } 

        if(enemy.currentHp == 0 ) Destroy(gameObject);
    }
}
