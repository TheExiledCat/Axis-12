using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyerScript : Enemy
{
    bool active = true;
    GameObject player;
    Vector3 startpos;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        startpos = transform.position;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 dist = transform.position - player.transform.position;
        Debug.Log(dist);
        if (active)
        {
            if (dist.x >= -3&&dist.x<=3)
            {
                rb.velocity = new Vector2(0, -fMoveSpeed);
                active = false;
            }
        }
        if (dist.x <0)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Ground"))
        {
            StartCoroutine("Die");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            hp--;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
    IEnumerator Die()
    {
        yield return new WaitForSeconds(2f);
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(3f);
        GetComponent<BoxCollider2D>().enabled = true;
        GetComponent<SpriteRenderer>().enabled = true;
        active = true;
        transform.position = startpos;
        
    }
}
