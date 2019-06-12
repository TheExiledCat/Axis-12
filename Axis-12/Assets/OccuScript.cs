using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OccuScript : Enemy
{
    AudioSource source;
    public AudioClip rise;
    public AudioClip shoot;
    public AudioClip fall;
    int weaknum = 1;
    public GameObject bullet;
    public Transform check;
    // Start is called before the first frame update
    void Start()
    {
        source = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>();
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
        if (hp <= 0)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Shooting>().iAmmo++;
            Destroy(gameObject);

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
        
        GetComponent<BoxCollider2D>().enabled = false;
        anim.SetTrigger("Emerge");
        if (Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, transform.position) <= 7)
        {
            source.PlayOneShot(rise);
        }
        for (int i = 0; i < 40; i++)
        {
            yield return new WaitForEndOfFrame();
        }
        yield return StartCoroutine("Idle");
    }
    IEnumerator Idle()
    {
        GetComponent<BoxCollider2D>().enabled = true;
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
        if (Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, transform.position) <= 7)
        {
            source.PlayOneShot(shoot);
           var am= Instantiate(bullet, check.position, Quaternion.identity);
            am.GetComponent<Rigidbody2D>().velocity = new Vector2(-4, 0);
        }
        
        for (int i = 0; i < 20; i++)
        {
            yield return new WaitForEndOfFrame();
        }
        anim.SetTrigger("Idle");
        for (int i = 0; i < 40; i++)
        {
            yield return new WaitForEndOfFrame();
        }
        yield return StartCoroutine("Retreat");
    }
    IEnumerator Retreat()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        if (Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, transform.position) <= 7)
        {
            source.PlayOneShot(fall);
        }
        anim.SetTrigger("Retreat");
        for (int i = 0; i < 40; i++)
        {
            yield return new WaitForEndOfFrame();
        }
        //Destroy(gameObject);
        yield return new WaitForSeconds(4);
        StartCoroutine("Emerge");
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
            //StartCoroutine("Damage");
        }
    }
}
