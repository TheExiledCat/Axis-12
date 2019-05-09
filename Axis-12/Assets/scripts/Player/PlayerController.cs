using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    public float fMoveSpeed;
    public float fJumpHeight;
    public int iMaxAmmo = 10;
    float fMoveIn;
    bool bIsFacingRight;
    int iCurrentAmmo;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        fMoveIn = Input.GetAxis("Horizontal");
        rb.velocity = new Vector3(fMoveIn, rb.velocity.y, 0);
    }
    private void FixedUpdate()
    {
        
    }
}
