﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class HealthGen : MonoBehaviour
{
    public GameObject deathscreen;
    public int iHP;
    public int iHearts;
    public Image[] hearts;
    public GameObject ui;
    AudioSource source;
    public AudioClip heal;
    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (iHP <= 0)
        {
            deathscreen.SetActive(true);
            ui.SetActive(false);
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
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
            source.PlayOneShot(heal, 0.2f);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("EBullet"))
        {
            Destroy(collision.gameObject);
            iHP--;
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Flyer"))
        {
            LoseHP(collision.gameObject.GetComponent<Enemy>().iDamage);
            Destroy(collision.gameObject);
        }
        
    }
    public void LoseHP(int damage)
    {
        iHP -= damage;
    }
}
