using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class UIPlayer : MonoBehaviour
{

    public TMP_Text ammoText;
    public TMP_Text scriptText;
    public TMP_Text countDownText;

    [SerializeField] float timeCount;

    [SerializeField] Gun gun;
    [SerializeField] Spawnner spawnn;
    [SerializeField] Gate gate;

    private void Awake()
    {
        scriptText.text = "";
    }

    void Start()
    {
        gun = GameObject.FindFirstObjectByType<Gun>();
        timeCount = spawnn.setTime;
        StartCoroutine(sTalk());
    }

    // Update is called once per frame
    void Update()
    {
        ammoCap();
        timeCountMet();
    }

    void ammoCap()
    {
        if (gun.reloadAmmo)
        {
            StartCoroutine(re());
        }
        else
        {
            ammoText.text = "Ammo : " + gun.ammoCurrent + "/" + gun.ammocap;
        }
    }

    IEnumerator re()
    {
        ammoText.text = "Reloading...";
        yield return null;
    }

    
    IEnumerator sTalk()
    {
        scriptText.text = "Mission is Failed We Need To Retreat Right Now!!";
        yield return new WaitForSeconds(5);
        scriptText.text = "";
    }

    void timeCountMet()
    {
        if (gate.playerHasCome == true && spawnn.itEnd == false)
        {
            timeCount -= Time.deltaTime;
            int time = Convert.ToInt32(timeCount);
            countDownText.text = time.ToString();
        }
        else if(spawnn.itEnd == true)
        {
            countDownText.text = "";
        }
    }

    public void inGate()
    {
        if(gate.playerHasCome == true)
        {
            StartCoroutine(textInGate());
        }
    }

    IEnumerator textInGate()
    {
        scriptText.color = Color.red;
        scriptText.text = "You Have To Survive For " + spawnn.setTime + " Minutes Before Helicopter Come";
        yield return new WaitForSeconds(10);
        scriptText.text = "";
    }
}
