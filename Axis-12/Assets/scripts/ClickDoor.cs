using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickDoor : MonoBehaviour
{
    public bool locked;
    AudioSource source;
    public GameObject Door;
    public GameObject Door1;
    public AudioClip open;
    // Start is called before the first frame update
    private void Start()
    {
        source = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>();
        //Door = transform.parent.gameObject;
    }

    private IEnumerator OnMouseDown()
    {
        Debug.Log("cube clicked");
        Debug.Log(Door.transform.position.z);
        yield return StartCoroutine("UnlockDoor");




    }

    private IEnumerator UnlockDoor()
    {

        //var DoorStartY = Door.transform.position.y;
        //var DoorEndY = -4.62f;

        //var x = Door.transform.position.x;
        //var y = 1;
        //var z = Door.transform.position.z;
        //for (int i = 0; i < 6; i++)
        //{
        //    if (Door.transform.position.y > DoorEndY)
        //    {
        //        Debug.Log("your dog will now go down");
        //        Door.transform.position = new Vector3(x, (y -= 1), z);

        //    }
        //    yield return new WaitForEndOfFrame();


        //}
        source.PlayOneShot(open, 0.2f);
        Door.SetActive(false);
        Door1.SetActive(false);
        Debug.Log("Door opend");
        yield return new WaitForSeconds(5);
        Debug.Log("and now the for loop");
        //Debug.Log(DoorStartY);
        //for (int i = 0; i < 7; i++)
        //{
        //    if (Door.transform.position.y < (DoorStartY - 0.5f))
        //    {
        //        Debug.Log("your dog will now go up");
        //        Door.transform.position = new Vector3(x, (y += 1), z);
        //    }

        //    yield return new WaitForEndOfFrame();
        //}
        if (!locked)
        {
            Door.SetActive(true);
            Door1.SetActive(true);
        }
        
        Debug.Log("Door closed");


    }


    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            if(!locked)
            StartCoroutine("UnlockDoor");
            else if (locked)
            {
                if (GameObject.FindGameObjectWithTag("Player").GetComponent<PickUp>().items[1].amount > 0)
                {
                    StartCoroutine("UnlockDoor");
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PickUp>().items[1].amount--;

                }
            }
        }
    }
}
