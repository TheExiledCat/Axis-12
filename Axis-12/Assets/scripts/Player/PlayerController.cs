using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    SpriteRenderer sr;
    Rigidbody2D rb;
    public float fMoveSpeed;
    public Transform check;
    public float fJumpHeight;
    public LayerMask ground;
    public int iMaxAmmo = 10;
    BoxCollider2D bc2d;
    float fMoveIn;
    bool bIsFacingRight=true;
    bool bIsGrounded;
    bool bIsAimingUp;
    bool bIsWalking;
    bool bIsCrouching;
    Animator anim;
    int iCurrentAmmo;
   
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
        
        fMoveIn = Input.GetAxis("Horizontal");
        rb.velocity = new Vector3(fMoveIn*fMoveSpeed, rb.velocity.y, 0);
        if (Input.GetKeyDown(KeyCode.Space)&&bIsGrounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, fJumpHeight, 0);
        }
        if (fMoveIn > 0 && bIsGrounded)
        {
            bIsFacingRight = true;

        }
        if (fMoveIn < 0 && bIsGrounded)
        {
            bIsFacingRight = false;
        }
        if (Input.GetKey(KeyCode.W))
        {
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
            bIsCrouching = true;
            bc2d.size = new Vector2(bc2d.size.x, 1.954623f);
            bc2d.offset = new Vector2(bc2d.offset.x, -0.4676886f);
        }
        else
        {
            bIsCrouching = false;
            bc2d.offset = new Vector2(bc2d.offset.x, -0.1734972f);
            bc2d.size = new Vector2(bc2d.size.x, 2.543005f);
        }
       
        
        
        anim.SetBool("LookingUp", bIsAimingUp);
        anim.SetBool("Walking", bIsWalking);
        anim.SetBool("Crouching", bIsCrouching);
        sr.flipX = !bIsFacingRight;
        
    }
    void OnKey()
    {
        GetComponent<PickUp>().items[1].amount++;
    }
  
}
