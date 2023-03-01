using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    public Transform objectFollow;
    RectTransform rectTransform;

    [Header("HP")]
    public Image hp;
    public Image hpEffect;
    PlayerControll player;

    [SerializeField] float hpCostSpeed;


    // Start is called before the first frame update
    void Start()
    {
       
        rectTransform = GetComponent<RectTransform>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControll>();
    }

    // Update is called once per frame
    void Update()
    {
        if(objectFollow != null)
        {
            rectTransform.anchoredPosition = objectFollow.localPosition;
        }
        hpBar();
    }

    void hpBar()
    {
        hp.fillAmount = player.currentHP / player.maxHP;
        if (hpEffect.fillAmount > hp.fillAmount)
        {
            hpEffect.fillAmount -= hpCostSpeed;
        }
        else
        {
            hpEffect.fillAmount = hp.fillAmount;
        }
    }
}
