using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Enemy enemy;
    static public Bullet instance;
    [SerializeField] float liftTime;
    public float times;

    private void Start()
    {
        //enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>();
        instance = this;

    }

    private void Update()
    {
        desrange();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            enemy = collision.gameObject.GetComponent<Enemy>();
            Debug.Log("Enemy Take Damage");
            enemy.currentHp -= 10;
        }
        else desrange();
        Destroy(gameObject);
    }

    public void desrange()
    {
        times += Time.deltaTime;
        if(times >= liftTime)
        {
            Destroy(gameObject);
        }
    }
}
