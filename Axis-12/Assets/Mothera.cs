using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mothera : Enemy
{
    public int maxHp=50;
    public GameObject finish;
    public bool inBattle = true;
    int phase = 0;
    Vector3 restPos;
    GameObject player;
    int attackIndex=0;
    Vector3 startPos;
    int wait=80;
    bool grounded = false;
  
    // Start is called before the first frame update
    void Start()
    {
        restPos = GameObject.FindGameObjectWithTag("rest").transform.position;
        bIsFacingRight = true;
        sr = GetComponent<SpriteRenderer>();
        startPos = transform.position;
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(Fly());
    }
    private void Update()
    {
        if (hp == 0)
        {
            hp--;
            Instantiate(finish, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        sr.flipX = bIsFacingRight;
    }
    IEnumerator Fly()
    {
        rb.velocity = new Vector3(fMoveSpeed, 0);

        yield return new WaitForSeconds(3f);
        bIsFacingRight = false;
        rb.velocity = new Vector3(-fMoveSpeed, 0);
       

        yield return new WaitForSeconds(6f);
        bIsFacingRight = true;
        rb.velocity = new Vector3(fMoveSpeed, 0);
        yield return new WaitForSeconds(3f);
        rb.velocity = Vector3.zero;
        yield return new WaitForSeconds(2f);
        StartCoroutine(Attack());
        attackIndex++;

    }
    IEnumerator Attack()
    {
        Vector2 lockPos = player.transform.position;
        if (player.transform.position.x > transform.position.x)
        {
            bIsFacingRight = true;
        }
        else
        {
            bIsFacingRight = false;
        }
        anim.SetTrigger("Dive");
        for (int i=0; i < wait; i++)
        {
            transform.position = Vector3.MoveTowards(transform.position,lockPos, fMoveSpeed*Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        anim.SetTrigger("Flying");
       
        for (int i = 0; i < wait ; i++)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos, fMoveSpeed  * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSeconds(0.5f);
        if (attackIndex < 2)
        {
            StartCoroutine(Fly());
            anim.SetTrigger("Flying");
        }
        else
        {
            attackIndex = 0;
            StartCoroutine(Rest());
        }
    }
   IEnumerator Rest()
    {
        
        for (int i = 0; i < wait; i++)
        {
            transform.position = Vector3.MoveTowards(transform.position, restPos, fMoveSpeed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        grounded = true;
        anim.SetTrigger("Rest");
        yield return new WaitForSeconds(4f);
        grounded = false;
        for (int i = 0; i < wait ; i++)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos, fMoveSpeed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        StartCoroutine(Fly());
        anim.SetTrigger("Flying");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("HIT");
            if (grounded)
            {
                hp -= 2;
            }
            else
            {
                hp--;
            }
            Destroy(collision.gameObject);
        }
    }
}
