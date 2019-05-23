using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OccuScript : Enemy
{
     
    public GameObject bullet;
    public Transform check;
    // Start is called before the first frame update
    void Start()
    {
        bIsFacingRight = false;
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        StartCoroutine("Emerge");
    }
    private void Update()
    {
        Vector2 dist = transform.position - GameObject.FindGameObjectWithTag("Player").transform.position;
        if (dist.x < 0)
        {
            bIsFacingRight = true;
        }
        else
        {
            bIsFacingRight = false;
        }
        sr.flipX = bIsFacingRight;
    }
    void Shot()
    {
        var ball = Instantiate(bullet, check.position, check.rotation);
        if (bIsFacingRight)
        {
            ball.GetComponent<Rigidbody2D>().AddForce(transform.right * 200);
        }
        else
        {
            ball.GetComponent<Rigidbody2D>().AddForce(-transform.right * 200);
        }
    }
    IEnumerator Emerge()
    {
        anim.SetTrigger("Emerge");
        for(int i = 0; i < 16; i++)
        {
            yield return new WaitForEndOfFrame();
        }
        yield return StartCoroutine("Idle");
    }
    IEnumerator Idle()
    {
        anim.SetTrigger("Idle");
        for (int i = 0; i < 20; i++)
        {
            yield return new WaitForEndOfFrame();
        }
        StartCoroutine("Shoot");
    }
    IEnumerator Shoot()
    {
        anim.SetTrigger("Shoot");
        Shot();
        for (int i = 0; i < 20; i++)
        {
            yield return new WaitForEndOfFrame();
        }
        anim.SetTrigger("Idle");
        for (int i = 0; i < 16; i++)
        {
            yield return new WaitForEndOfFrame();
        }
        yield return StartCoroutine("Retreat");
    }
    IEnumerator Retreat()
    {
        anim.SetTrigger("Retreat");
        for (int i = 0; i < 16; i++)
        {
            yield return new WaitForEndOfFrame();
        }
        Destroy(gameObject);
    }
    //IEnumerator Damage()
    //{

    //}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            hp--;
            StartCoroutine("Damage");
        }
    }
}
