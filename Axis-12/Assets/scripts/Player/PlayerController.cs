using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    public float fMoveSpeed;
    public Transform check;
    public float fJumpHeight;
    public LayerMask ground;
    public int iMaxAmmo = 10;
    float fMoveIn;
    bool bIsFacingRight;
    bool bIsGrounded;
    
    int iCurrentAmmo;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        bIsGrounded = Physics2D.OverlapCircle(check.position, 0.1f, ground);
        fMoveIn = Input.GetAxis("Horizontal");
        rb.velocity = new Vector3(fMoveIn*fMoveSpeed, rb.velocity.y, 0);
        if (Input.GetKeyDown(KeyCode.Space)&&bIsGrounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, fJumpHeight, 0);
        }
    }
    private void FixedUpdate()
    {
        
    }
}
