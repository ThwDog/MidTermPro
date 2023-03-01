using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CutScene : MonoBehaviour
{
    [SerializeField] GameObject bg;
    [SerializeField] Image bgcolor;
    [SerializeField] TMP_Text text;
    [SerializeField] PlayerControll player;
    [SerializeField] Spawnner spawn;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControll>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.playerDie == true)
        {
            bg.SetActive(true);
            bgcolor.color = Color.black;
            text.color = Color.red;
            text.text = "Game Over";
        }
        else if(player.playerDie == false && spawn.itEnd == true)
        {
            bg.SetActive(true);
            bgcolor.color = Color.white;
            text.color = Color.black;
            text.text = "You Save For Now";
        } 
    }

   
}
