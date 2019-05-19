﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthGen : MonoBehaviour
{
    public int iHP;
    public int iHearts;
    public Image[] hearts;
   
    private void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (iHP > iHearts)
        {
            iHP = iHearts;
        }
        for (int i = 0; i < hearts.Length; i++)
        {
           
            if (i < iHP)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Health")){
            iHP++;
            Destroy(collision.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            LoseHP(collision.gameObject.GetComponent<Enemy>().iDamage);
        }
    }
    public void LoseHP(int damage)
    {
        iHP -= damage;
    }
}