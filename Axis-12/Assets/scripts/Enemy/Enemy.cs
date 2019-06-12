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
    [HideInInspector]
    public Animator anim;
    public float fMoveSpeed;
    public GameObject splash;
    public int iDamage;
    public int hp;



}
