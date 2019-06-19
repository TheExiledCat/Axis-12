using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PickUp : MonoBehaviour
{
    public delegate void PickUpKey();
    public static event PickUpKey OnGet;
    public AudioClip gem;
    public Item[] items; //hardcoding an array :( sorry
    
    public int itemAm;
    public int slots;
    public Image[] slotAr;
    public GameObject ui;
    public Sprite slotOn;
    public Sprite slotOff;
    private void Start()
    {
               
    }
    


    // Update is called once per frame
    void Update()
    {
        itemAm = items[1].amount;
        if (itemAm <= 0)
        {
            itemAm = 0;
        }
        if (itemAm > slots)
        {
            itemAm = slots;
        }
        for (int i = 0; i < slotAr.Length; i++)
        {

            if (i < itemAm)
            {
                slotAr[i].gameObject.GetComponent<Image>().sprite = slotOn;
            }
            else
            {
                slotAr[i].gameObject.GetComponent<Image>().sprite = slotOff;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "IGem":
                {
                    Destroy(collision.gameObject);
                    items[0].amount++;
                    GetComponent<AudioSource>().PlayOneShot(gem, 0.2f);
                    
                    GetComponent<Shooting>().iAmmo++;
                    break;
                }
            case "GGem":
                {
                    Destroy(collision.gameObject);
                    items[0].amount++;
                    GetComponent<AudioSource>().PlayOneShot(gem, 0.2f);

                    GetComponent<Shooting>().gAmmo++;
                    break;
                }
            case "FGem":
                {
                    Destroy(collision.gameObject);
                    items[0].amount++;
                    GetComponent<AudioSource>().PlayOneShot(gem, 0.2f);

                    GetComponent<Shooting>().fAmmo++;
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

                    GetComponent<Shooting>().fAmmo++;
                    break;
                }
            
        }
    }
    
}
