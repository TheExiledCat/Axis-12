using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    private GameObject DoorSpawn;
    public GameObject Door;

    private void Awake()
    {
        DoorSpawn = GameObject.Find("Cono");
        GameObject Deur;
        Deur = Instantiate(Door, DoorSpawn.transform.position, DoorSpawn.transform.rotation);
    }
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject == Door)
        {
            Destroy(collision.gameObject);
        }
    }

    void Update()
    {
        
    }
}
