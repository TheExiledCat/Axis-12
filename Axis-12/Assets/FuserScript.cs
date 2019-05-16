using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuserScript : Enemy
{
   
    bool bIsMoving = true;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        bIsFacingRight = false;
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine("Turn");
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
        if (Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) <= 3)
        {
            Boom();
            Debug.Log("boom");
        }
        sr.flipX = bIsFacingRight;
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
    void Boom()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<HealthGen>().LoseHP(3);
        Destroy(gameObject);
    }
}
