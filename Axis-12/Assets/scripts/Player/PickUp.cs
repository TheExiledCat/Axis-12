using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Item[] items; //hardcoding an array :( sorry
    int iMaxHP=10;
    public int iHP;
    private void Start()
    {
               
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Gem":
                {
                    items[0].amount++;
                    Destroy(collision.gameObject);
                    break;
                }
            case "Key":
                {
                    items[1].amount++;
                    Destroy(collision.gameObject);
                    break;
                }
            case "Health":
                {
                    if (iHP < iMaxHP)
                    {
                        Destroy(collision.gameObject);
                        iHP++;
                    }
                    break;
                }
        }
    }
}
