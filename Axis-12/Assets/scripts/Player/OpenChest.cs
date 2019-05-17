using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChest : MonoBehaviour
{
    public GameObject key;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private IEnumerator OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("OwO uve touched the blockywocky <3");
            yield return StartCoroutine("OpeningChest");
            
        }
    }

 

    private IEnumerator SpawningKey()
    {
        //Key spawn animation
        GameObject keystance=Instantiate(key, transform.position+Vector3.up, transform.rotation);
        yield return new WaitForSeconds(3f);
        Destroy(keystance);
        GameObject.FindGameObjectWithTag("Player").GetComponent<PickUp>().items[1].amount++;
    }

    private IEnumerator OpeningChest()
    {
        Debug.Log("opening the chest to getchu the key");
        //play chest opening animation
        anim.SetTrigger("touch player");
        yield return new WaitForSeconds(2);
        yield return StartCoroutine("SpawningKey");
        
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
