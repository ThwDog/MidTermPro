using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float speed;
    public Transform gunPos;
    public GameObject bulletPre;
    public int ammocap;
    public int ammoCurrent;
    [SerializeField] bool ammoOut = false;
    public bool reloadAmmo = false;
    public Animator anim;


    private void Start()
    {
        ammoCurrent = ammocap;

    }
    // Update is called once per frame
    void Update()
    {
        reload();
        if (!ammoOut)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                StartCoroutine(shootAnimation());
                
                if(ammoCurrent == 0)
                {
                    ammoOut = true;
                }
            }
        }      
    }

    
    void shoot()
    {
        GameObject bullet = Instantiate(bulletPre,gunPos.position, gunPos.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();   
        rb.AddForce(gunPos.right * speed,ForceMode2D.Impulse );
        ammoCurrent--;
    }

    IEnumerator shootAnimation()
    {
        anim.SetBool("Fire", true);
        shoot();
        yield return new WaitForSeconds(0.3f);
        anim.SetBool("Fire", false);
    }

    void reload()
    {
        if (Input.GetKeyDown(KeyCode.R))
            {
                Debug.Log("Reload");
                StartCoroutine(re());
            }
        
    }

    IEnumerator re()
    {
        reloadAmmo = true;
        yield return new WaitForSeconds(3);
        ammoCurrent = ammocap;
        ammoOut = false;
        reloadAmmo = false;
    }
}
