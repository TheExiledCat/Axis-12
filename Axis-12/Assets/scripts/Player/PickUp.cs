using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public delegate void PickUpKey();
    public static event PickUpKey OnGet;
    public AudioClip gem;
    public Item[] items; //hardcoding an array :( sorry
    
    private void Start()
    {
               
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Gem":
                {
                    Destroy(collision.gameObject);
                    items[0].amount++;
                    GetComponent<AudioSource>().PlayOneShot(gem, 0.2f);
                    
                    GetComponent<Shooting>().ammo++;
                    break;
                }
            case "Key":
                {
                    items[1].amount++;
                    Destroy(collision.gameObject);
                    break;
                }
            case "RGem":
                {
                    collision.gameObject.SetActive(false);
                    collision.gameObject.GetComponent<Respawn>().respawn();
                    items[0].amount++;
                    GetComponent<AudioSource>().PlayOneShot(gem, 0.2f);

                    GetComponent<Shooting>().ammo++;
                    break;
                }
            
        }
    }
    
}
