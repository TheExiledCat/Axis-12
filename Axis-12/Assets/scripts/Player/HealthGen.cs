using System.Collections;
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
    public GameObject win;
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
            StartCoroutine("DIE");
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
        if (collision.gameObject.CompareTag("Health"))
        {
            iHP++;
            source.PlayOneShot(heal, 0.2f);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("EBullet"))
        {
            Destroy(collision.gameObject);
            LoseHP(1, collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Finish"))
        {
            ui.SetActive(false);
            win.SetActive(true);
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            source.enabled = false;
        }
        if (collision.gameObject.CompareTag("Boss"))
        {

            LoseHP(1, collision.gameObject);
        }


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Flyer"))
        {
            LoseHP(collision.gameObject.GetComponent<Enemy>().iDamage, collision.gameObject);
            Destroy(collision.gameObject);
        }

    }
    IEnumerator DIE()
    {
        GetComponent<Animator>().SetTrigger("Death");
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        yield return new WaitForSeconds(5f);
        deathscreen.SetActive(true);
        ui.SetActive(false);

        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void LoseHP(int damage, GameObject g)
    {
       //iHP -= damage;
        //if (g.transform.position.x > transform.position.x)
        //{
        //    transform.position = new Vector3(transform.position.x - 1, transform.position.y);
        //}
        //if (g.transform.position.x < transform.position.x)
        //{
        //    transform.position = new Vector3(transform.position.x + 1, transform.position.y);
        //}
        GetComponent<Animator>().SetTrigger("Damage");
    }

}
