using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChest : MonoBehaviour
{

    public GameObject Chest;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ChestTrigger")
        {
            Debug.Log("OwO uve touched the blockywocky <3");
            yield return StartCoroutine("OpeningChest");
            
        }
    }

 

    private IEnumerator SpawningKey()
    {
        //Key spawn animation
        yield return new WaitForSeconds(3);
    }

    private IEnumerator OpeningChest()
    {
        Debug.Log("opening the chest to getchu the key");
        //play chest opening animation
        yield return StartCoroutine("SpawningKey");
        yield return new WaitForSeconds(3);
        Chest.active = false;
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
