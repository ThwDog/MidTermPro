using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnner : MonoBehaviour
{
    public GameObject[] enemy;
    [SerializeField] float spawnTime;
    [SerializeField] int spawnCount;
    public bool canSpawn = false;
    public int enemyDeadCount;
    public Transform enemySpawn;

    [Header("Time")]
    public float time;
    public float setTime;
    public bool itEnd = false;

    [SerializeField] Gate gate;

    [Header("Set X Y")]
    [SerializeField] float xMin;
    [SerializeField] float xMax;
    [SerializeField] float yMin;
    [SerializeField] float yMax;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if(spawnCount >= enemyNumber)
        {
            canSpawn = false;
        }
        else
        {
            canSpawn = true;
        }*/

        if (gate.playerHasCome == true && itEnd == false)
        {
            time += Time.deltaTime;
        }
        
    }

    public void spawnner()
    {
        if (canSpawn)
        {
            StartCoroutine(spawn(spawnTime));
        }
    }

    IEnumerator spawn(float spawntime)
    {
        GameObject instOb = enemy[Random.Range(0,enemy.Length)];
        Debug.Log(enemy);
        yield return new WaitForSeconds(spawntime);
        Instantiate(instOb, new Vector3(Random.Range(enemySpawn.transform.position.x + xMin, enemySpawn.transform.position.x + xMax),
        Random.Range(enemySpawn.transform.position.y + yMin, enemySpawn.transform.position.y + yMax), 0), Quaternion.identity);
        spawnCount++;
        if (time < setTime)
        {
            StartCoroutine(spawn(spawntime));
        }
        else
        {
            Debug.Log("Stop Spawn");
            StopCoroutine(spawn(spawntime));
            itEnd = true;
        }
    }
}
