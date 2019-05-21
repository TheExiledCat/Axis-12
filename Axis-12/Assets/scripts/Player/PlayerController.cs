using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    SpriteRenderer sr;
    Rigidbody2D rb;
    public float fMoveSpeed;
    public Transform check;
    public Transform check1;
    public float fJumpHeight;
    public LayerMask ground;
    public int iMaxAmmo = 10;
    BoxCollider2D bc2d;
    float fMoveIn;
    public bool bIsFacingRight = true;
    bool bIsGrounded;
    bool bIsGrounded1;
    public bool bIsAimingUp;
    public bool bIsWalking;
    public bool bIsCrouching;
    Animator anim;
    int iCurrentAmmo;
    public GameObject Vira;
    // Start is called before the first frame update
    void Start()
    {
        bc2d = GetComponent<BoxCollider2D>();
        PickUp.OnGet += OnKey;
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {




        //state machines
        bIsGrounded = Physics2D.OverlapCircle(check.position, 0.1f, ground);
        bIsGrounded1 = Physics2D.OverlapCircle(check1.position, 0.1f, ground);
        fMoveIn = Input.GetAxis("Horizontal");

        if (!bIsCrouching)
            rb.velocity = new Vector3(fMoveIn * fMoveSpeed, rb.velocity.y, 0);

        if (Input.GetKeyDown(KeyCode.Space) && (bIsGrounded||bIsGrounded1)&&!bIsCrouching)
        {
            rb.velocity = new Vector3(rb.velocity.x, fJumpHeight, 0);
        }
        if (fMoveIn > 0 && (bIsGrounded || bIsGrounded1))
        {
            bIsFacingRight = true;

        }
        if (fMoveIn < 0 && (bIsGrounded || bIsGrounded1))
        {
            bIsFacingRight = false;
        }
        if (Input.GetKey(KeyCode.W))
        {
            if(!bIsCrouching)
            bIsAimingUp = true;
        }
        else
        {
            bIsAimingUp = false;
        }
        if (fMoveIn != 0)
        {
            bIsWalking = true;
        }
        else
        {
            bIsWalking = false;
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (bIsAimingUp)
                bIsAimingUp = false;
            bIsCrouching = true;
            rb.velocity = new Vector3(0, rb.velocity.y);
            //bc2d.size = new Vector2(bc2d.size.x, 1.954623f);
            //bc2d.offset = new Vector2(bc2d.offset.x, -0.4676886f);
        }
        else
        {
            bIsCrouching = false;
            bc2d.offset = new Vector2(bc2d.offset.x, -0.05f);
            bc2d.size = new Vector2(bc2d.size.x, 3.5f);
        }
        if (bIsCrouching)
        {
            transform.GetChild(1).position = new Vector3(transform.GetChild(1).position.x, transform.position.y - 0.12f);
        }
        else
        {
            transform.GetChild(1).position = new Vector3(transform.GetChild(1).position.x, transform.position.y + 0.58f);
        }
        if (bIsFacingRight)
        {
            Vira.transform.position = new Vector3(transform.position.x-1, transform.position.y+1);
            
            if(!bIsAimingUp)
                transform.GetChild(1).position = new Vector3(transform.position.x + 1.35f, transform.GetChild(1).position.y);
            else
                transform.GetChild(1).position = new Vector3(transform.position.x + 0.9f, transform.position.y+1.6f);
        }
        else
        {
            Vira.transform.position = new Vector3(transform.position.x+1, transform.position.y+1);
            
            if (!bIsAimingUp)
                transform.GetChild(1).position = new Vector3(transform.position.x - 1.35f, transform.GetChild(1).position.y);
            else
                transform.GetChild(1).position = new Vector3(transform.position.x - 0.9f, transform.position.y + 1.6f);
        }
        
        

        Vira.GetComponent<Animator>().SetBool("Walking", bIsWalking);
        anim.SetBool("LookingUp", bIsAimingUp);
        anim.SetBool("Walking", bIsWalking);
        anim.SetBool("Crouching", bIsCrouching);
        sr.flipX = !bIsFacingRight;
        Vira.GetComponent<SpriteRenderer>().flipX = !bIsFacingRight;

    }
    void OnKey()
    {
        GetComponent<PickUp>().items[1].amount++;
    }
    

}
