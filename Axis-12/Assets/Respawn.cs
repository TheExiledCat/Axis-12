using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public void respawn()
    {
        Invoke("Delay",5);
      
        
    }
    void Delay()
    {
        gameObject.SetActive(true);
    }
}
