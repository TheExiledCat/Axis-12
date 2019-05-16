using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public GameObject Bullet;
    public GameObject BulletSpawn;
    public float BulletSpeed;
    private int ammo;
    private bool Click = true;
    PlayerController PlayerControllerScript;
    



    void Start()
    {
        GameObject PlayerControl = GameObject.Find("Player");
        PlayerControllerScript = PlayerControl.GetComponent<PlayerController>();
        ammo = PlayerControllerScript.iMaxAmmo;

    }


    private void Spawnblock() {
 
        
        Debug.Log("starting the bullet instanciate function");
        if (ammo == 0)
        {
            Debug.Log("ending the function");
            return;
        }
        Debug.Log("shoot"); 
        GameObject  BulletInstance;
        
        BulletInstance = Instantiate(Bullet, BulletSpawn.transform.position, BulletSpawn.transform.rotation) as GameObject;


        Rigidbody2D BulletPlace;
        BulletPlace = BulletInstance.GetComponent<Rigidbody2D>();
        ammo -= 1;
        Debug.Log(ammo);
        if(GetComponent<PlayerController>().bIsFacingRight)
        BulletPlace.AddForce(transform.right * BulletSpeed);
        else
        {
            BulletPlace.AddForce(-transform.right * BulletSpeed);
        }

    }

    void Update()
    {
        if (Click == true);
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("u clicked");
                Debug.Log("pressed space bullet will now spawn");
                Spawnblock();
            }
        }

    }
}
