using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected EnemyData enemyData;
    [SerializeField] protected Transform playerPosition;
    [SerializeField] SpriteRenderer sr;
    public PlayerControll player;
    public float maxHp;
    public float currentHp;
    public Animator anim;
    [SerializeField] Spawnner spawn;


    void Start()
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        maxHp = enemyData.maxHp;
        currentHp = maxHp;
        //sr = GetComponent<SpriteRenderer>();    
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControll>();
        spawn = GameObject.Find("Spawnner").GetComponent<Spawnner>();
    }

    // Update is called once per frame
    void Update()
    {
        move();
        turnDir();

        if (currentHp == 0)
        {
            if (spawn.canSpawn == true)
            {
                spawn.enemyDeadCount++;
                Destroy(gameObject);
            }
            Destroy(gameObject);
            
        }
    }
    
    protected virtual void move()
    {
        if (Vector2.Distance(transform.position, playerPosition.position) < enemyData.distance)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerPosition.position, enemyData.speed * Time.deltaTime);
            anim.SetBool("Walk", true);
        }
        else anim.SetBool("Walk", false);
    }

    void turnDir()
    {
        if (transform.position.x > playerPosition.position.x)
        {
            sr.flipX = false;
        }
        else sr.flipX = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Debug.Log("Enemy Take Damage");
            currentHp -= 10;
        }
    }
}
