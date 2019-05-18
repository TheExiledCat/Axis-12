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
    bool bInNewRoom = false;
    public GameObject check;
    private void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject==check)
        {
            
            if (bInNewRoom)
            {
                GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(transform.position.x - 2, collision.gameObject.transform.position.y);
                bInNewRoom = !bInNewRoom;
                Camera.main.GetComponent<cameraFollow>().xMax = xMax1;
                Camera.main.GetComponent<cameraFollow>().yMax = yMax1;
                Camera.main.GetComponent<cameraFollow>().xMin = xMin1;
                Camera.main.GetComponent<cameraFollow>().yMin = yMin1;
            }
            else if (!bInNewRoom)
            {
                GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(transform.position.x + 2, collision.gameObject.transform.position.y);
                xMin1 = Camera.main.GetComponent<cameraFollow>().xMin;
                yMin1 = Camera.main.GetComponent<cameraFollow>().yMin;
                xMax1 = Camera.main.GetComponent<cameraFollow>().xMax;
                yMax1 = Camera.main.GetComponent<cameraFollow>().yMax;
                bInNewRoom = !bInNewRoom;
            Camera.main.GetComponent<cameraFollow>().xMax = xMax;
            Camera.main.GetComponent<cameraFollow>().yMax = yMax;
            Camera.main.GetComponent<cameraFollow>().xMin = xMin;
            Camera.main.GetComponent<cameraFollow>().yMin = yMin;
            }
            
        }
    }
}
