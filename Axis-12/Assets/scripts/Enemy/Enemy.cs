using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [HideInInspector]
    public Rigidbody2D rb;
    [HideInInspector]
    public bool bIsFacingRight;
    [HideInInspector]
    public SpriteRenderer sr;
    
    public float fMoveSpeed;
    
    public int iDamage;
    public int hp;
    
   
    
}
