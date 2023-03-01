using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControll : MonoBehaviour
{
    Rigidbody2D rb;
    float horizontal;
    float vertical;
    Vector2 movedir;
    [Header("Speed")]
    [SerializeField] float speed;
    [SerializeField] float dSpeed;

    [Header("Dash")]
    [SerializeField] bool _isDash = true;
    [SerializeField] bool _canDash = true;
    [SerializeField] float dashCD;
    [SerializeField] float dashTime;
    [SerializeField] int dashCount;
    [SerializeField] int dashMax = 2;

    [Header("Hp")]
    public float currentHP;
    public float maxHP;
    [SerializeField] float regenCount;
    [SerializeField] float regenTime;
    [SerializeField] int regenHp;
    [SerializeField] float regenCoolDown;
    public bool haveAtk = false;
    public bool playerDie = false;

    [Header("mouselook")]
    public Camera cam;
    Vector2 mousePos;//mousePosition

    public Animator anim;

    void Start()
    {
        currentHP = maxHP;
        regenCount = regenTime;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        countdash();
        hpRegen();
        die();
        dash();
        mouseLook();
    }

    private void FixedUpdate()
    {
        walk();
    }

    void walk()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        
        movedir = new Vector2(horizontal,vertical);
        if (!_isDash)
        {
            rb.velocity = new Vector2(horizontal * speed, vertical * speed);
            if(horizontal > 0 || horizontal < 0 || vertical > 0 || vertical < 0)
            {
                anim.SetBool("Move", true);
            }
            else if(horizontal == 0 || vertical == 0)
            {
                anim.SetBool("Move", false);
            }

        }

    }

    void dash()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && _canDash == true)
        {
            if (_canDash)
            {
                StartCoroutine(dashsy(movedir));
            }
        }
    }

    IEnumerator dashsy(Vector2 dir)
    {
        _isDash = true;
        dashCount++;
        float elasTime = 0;
        while (elasTime < dashTime)
        {
            rb.velocity = dir * dSpeed;
            elasTime += Time.deltaTime;
            yield return null;
        }
        _isDash = false;
    }

    void countdash()
    {
        if(dashCount == dashMax)
        {
            _canDash = false;
            StartCoroutine(delayDash());

        }
        else if(dashCount == 0)
        {
            _canDash = true;
        }   
    }

    IEnumerator delayDash()
    {
        yield return new WaitForSeconds(dashCD);
        dashCount = 0;
    }

    void die()
    {
        if (currentHP == 0)
        {
            Debug.Log("Im Dead");
            playerDie = true;
            StartCoroutine(dieDelay());
        }
    }

    IEnumerator dieDelay()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void hpRegen()
    {
        if (currentHP < maxHP && haveAtk == false)
        {
            regenCount -= Time.deltaTime;
            if (regenCount <= 0)
            {
                StartCoroutine(setTime());
            }
        }
    }

    IEnumerator setTime()
    {
        currentHP += Time.deltaTime * regenHp;
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);
        yield return new WaitForSeconds(regenCoolDown);
        regenCount = regenTime;
    }

    void mouseLook()
    {
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y,lookDir.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
    }

}
