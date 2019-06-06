using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuserScript : Enemy
{
    public bool boss = false;
    AudioSource source;
    public GameObject heart;
    bool bIsMoving = true;
    public AudioClip dmg, death,turn,boom;
    public GameObject fire;
    
    // Start is called before the first frame update
    void Start()
    {
        source = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>();

        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        bIsFacingRight = false;
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (bIsMoving && bIsFacingRight)
        {
            rb.velocity = transform.right * fMoveSpeed;
        } else if (bIsMoving && !bIsFacingRight)
        {
            rb.velocity = -transform.right * fMoveSpeed;
        }
        if (!bIsMoving)
        {
            rb.velocity = Vector2.zero;
        }
        if (Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) <= 2)
        {
            if (rb != null)
            {
                Boom();
            }
            source.PlayOneShot(boom, 0.2f);

            Debug.Log("boom");
        }
        sr.flipX = bIsFacingRight;
        if (hp == 0)
        {
            source.PlayOneShot(death, 0.2f);
            if (boss)
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<PickUp>().items[1].amount++;
               // GameObject.FindGameObjectWithTag("Player").GetComponent<PickUp>().items[0].amount+=4;
            }
               
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
        if (Random.Range(0, 4) == 0)
        {
            Instantiate(heart, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
    private IEnumerator Turn(float waitTime)
    {
        if(Vector3.Distance(transform.position,GameObject.FindGameObjectWithTag("Player").transform.position)<=10)
        source.PlayOneShot(turn, 0.2f);
        bIsMoving = false;
        yield return new WaitForSeconds(waitTime);
        Debug.Log("turning");
        bIsMoving = true;
        bIsFacingRight = !bIsFacingRight;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall")||collision.gameObject.CompareTag("Enemy"))
        {
            
            StartCoroutine(Turn(2f));
        }
        
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            source.PlayOneShot(dmg, 0.2f);
            hp--;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {

            StartCoroutine(Turn(2f));
        }
    }
    void Boom()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<HealthGen>().LoseHP(iDamage,gameObject);
        source.PlayOneShot(boom, 0.2f);
        Instantiate(fire, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
