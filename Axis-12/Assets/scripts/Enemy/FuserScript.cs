using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuserScript : Enemy
{
    
    bool bIsMoving = true;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        bIsFacingRight = false;
        rb = GetComponent<Rigidbody2D>();
        
    }
    
    // Update is called once per frame
    void Update()
    {
        if (bIsMoving&&bIsFacingRight)
        {
            rb.velocity = transform.right * fMoveSpeed;
        }else if (bIsMoving && !bIsFacingRight)
        {
            rb.velocity = -transform.right * fMoveSpeed;
        }
        if (Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) <= 2)
        {
            Boom();
            Debug.Log("boom");
        }
        sr.flipX = bIsFacingRight;
        if (hp == 0)
        {
            StartCoroutine("Die");
            hp--;
        }
        anim.SetBool("Moving", bIsMoving);
    }
    private IEnumerator Die()
    {
        anim.SetTrigger("Die");
        Destroy(rb);
        Destroy(GetComponent<BoxCollider2D>());
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }
    private IEnumerator Turn(float waitTime)
    {
        bIsMoving = false;
        yield return new WaitForSeconds(waitTime);
        Debug.Log("turning");
        bIsMoving = true;
        bIsFacingRight = !bIsFacingRight;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            
            StartCoroutine(Turn(2f));
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            hp--;
            Destroy(collision.gameObject);
        }
    }
    void Boom()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<HealthGen>().LoseHP(iDamage);
        Destroy(gameObject);
    }
}
