using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickDoor : MonoBehaviour
{

    public GameObject Door;

    // Start is called before the first frame update
    private void Start()
    {
   
    }

    private IEnumerator OnMouseDown()
    {
        Debug.Log("cube clicked");
        Debug.Log(Door.transform.position.z);
        yield return StartCoroutine("UnlockDoor");
 



    }

    private IEnumerator UnlockDoor(){

        var DoorStartY = Door.transform.position.y;
        var DoorEndY = -4.62;

        var x = Door.transform.position.x;
        var y = 1;
        var z = Door.transform.position.z;
        for (int i = 0; i < 6; i++)
        {
            if (Door.transform.position.y > DoorEndY)
            {
                Debug.Log("your dog will now go down");
                Door.transform.position = new Vector3(x, (y -= 1), z);

            }
            yield return new WaitForEndOfFrame();
          

        }
        Debug.Log("Door opend");
        yield return new WaitForSeconds(5);
        Debug.Log("and now the for loop");
        Debug.Log(DoorStartY);
        for (int i = 0; i < 6; i++)
        {
            if (Door.transform.position.y < (DoorStartY - 1))
            {
                Debug.Log("your dog will now go up");
                Door.transform.position = new Vector3(x, (y += 1), z);
            }

            yield return new WaitForEndOfFrame();
        }

        
        Debug.Log("Door closed");
      

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
