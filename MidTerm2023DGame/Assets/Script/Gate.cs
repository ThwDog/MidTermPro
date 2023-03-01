using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public Spawnner spawn;
    public UIPlayer ui;
    public bool playerHasCome = false;
    [SerializeField] Collider2D gate;

    private void Awake()
    {
        gate = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("Player has come");
            spawn.canSpawn = true;
            playerHasCome = true;
            ui.inGate();
            spawn.spawnner();
            StartCoroutine(gateClose());
        }
    }

    IEnumerator gateClose()
    {
        yield return new WaitForSeconds(3);
        gate.isTrigger = false;
    }
}
