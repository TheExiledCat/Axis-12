using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    
    public float yMin;
    public float yMax;
    public float xMin;
    public float xMax;
    public float yMin1;
     public float yMax1;
     public float xMin1;
     public float xMax1;
    public bool bInNewRoom = false;
     GameObject check;
    public GameObject hitbox;
    public bool locked;
    private void Start()
    {
        check = GameObject.FindGameObjectWithTag("PlayerCheck");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject==check)
        {
            Debug.Log(bInNewRoom);
            if (!locked)
            {
                hitbox.GetComponent<ClickDoor>().Door.SetActive(true);
                hitbox.GetComponent<ClickDoor>().Door1.SetActive(true);
            }
            
            if (bInNewRoom)
            {
                GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(transform.position.x - 2, collision.gameObject.transform.position.y);
                bInNewRoom = false;
                Debug.Log(bInNewRoom);
                Camera.main.GetComponent<cameraFollow>().xMax = xMax1;
                Camera.main.GetComponent<cameraFollow>().yMax = yMax1;
                Camera.main.GetComponent<cameraFollow>().xMin = xMin1;
                Camera.main.GetComponent<cameraFollow>().yMin = yMin1;
            }
            else if (!bInNewRoom)
            {
                bInNewRoom = true;
                GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(transform.position.x + 2, collision.gameObject.transform.position.y);
                xMin1 = Camera.main.GetComponent<cameraFollow>().xMin;
                yMin1 = Camera.main.GetComponent<cameraFollow>().yMin;
                xMax1 = Camera.main.GetComponent<cameraFollow>().xMax;
                yMax1 = Camera.main.GetComponent<cameraFollow>().yMax;
                
                Debug.Log(bInNewRoom);
                Camera.main.GetComponent<cameraFollow>().xMax = xMax;
            Camera.main.GetComponent<cameraFollow>().yMax = yMax;
            Camera.main.GetComponent<cameraFollow>().xMin = xMin;
            Camera.main.GetComponent<cameraFollow>().yMin = yMin;
            }
            
        }
    }
}
