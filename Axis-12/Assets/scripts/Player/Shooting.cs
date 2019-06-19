using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Shooting : MonoBehaviour
{
    public Sprite bar0;
    public Sprite bar1;
    public Sprite bar2;
    public Sprite type0;
    public Sprite type1;
    public Sprite type2;

    AudioSource source;
    public GameObject Bullet0;
    public GameObject Bullet1;
    public GameObject Bullet2;
    public GameObject BulletSpawn;
    public float BulletSpeed;
    [HideInInspector]
    public int fAmmo;
    public int iAmmo;
    public int gAmmo;
    private bool Click = true;
    PlayerController PlayerControllerScript;
    public Image ammobar;
    public Image typeBar;
    public AudioClip shot;
    public int weapon = 0;
    int currentammo;
    void Start()
    {
        source = GetComponent<AudioSource>();
        PlayerControllerScript = GetComponent<PlayerController>();
        fAmmo = PlayerControllerScript.iMaxAmmo/2;
        iAmmo = PlayerControllerScript.iMaxAmmo ;
        gAmmo = PlayerControllerScript.iMaxAmmo / 2;
    }


    private void Spawnblock()
    {


        Debug.Log("starting the bullet instanciate function");

        Debug.Log("shoot");
        GameObject BulletInstance;
        switch (weapon)
        {
            case 0: BulletInstance = Instantiate(Bullet0, BulletSpawn.transform.position, BulletSpawn.transform.rotation) as GameObject; iAmmo--; break;
            case 1: BulletInstance = Instantiate(Bullet1, BulletSpawn.transform.position, BulletSpawn.transform.rotation) as GameObject;fAmmo--; break;
            case 2: BulletInstance = Instantiate(Bullet2, BulletSpawn.transform.position, BulletSpawn.transform.rotation) as GameObject;gAmmo--; break;
            default: BulletInstance = Instantiate(Bullet0, BulletSpawn.transform.position, BulletSpawn.transform.rotation) as GameObject; iAmmo--; break;
        }
   

        Rigidbody2D BulletPlace;
        BulletPlace = BulletInstance.GetComponent<Rigidbody2D>();
      
        if (GetComponent<PlayerController>().bIsFacingRight)
        {


            if (!PlayerControllerScript.bIsAimingUp)
                BulletPlace.AddForce(BulletSpawn.transform.right * BulletSpeed);
            else if (PlayerControllerScript.bIsAimingUp)
                BulletPlace.AddForce(new Vector2(BulletSpeed, BulletSpeed));


        }
        else
        {

            if (!PlayerControllerScript.bIsAimingUp&&BulletPlace!=null)
                BulletPlace.AddForce(-BulletSpawn.transform.right * BulletSpeed);
            else if (PlayerControllerScript.bIsAimingUp&&BulletPlace!=null)
                BulletPlace.AddForce(new Vector2(-BulletSpeed, BulletSpeed));
        }
        Destroy(BulletInstance, 2f);

    }
    IEnumerator WaitForShot(float wait)
    {
        yield return new WaitForSeconds(wait);
        Click = true;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (weapon > 0)
            {
                weapon--;
            }
            else
            {
                weapon = 2;
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (weapon <2)
            {
                weapon++;
            }
            else
            {
                weapon = 0;
            }
        }
        switch (weapon) {
            case 0: currentammo = iAmmo; ammobar.sprite = bar0;typeBar.sprite = type0; break;
            case 1: currentammo = fAmmo; ammobar.sprite = bar1; typeBar.sprite = type1; break;
            case 2: currentammo = gAmmo; ammobar.sprite = bar2; typeBar.sprite = type2; break;
        }
        if (Click == true)
        {
            if ( currentammo> 0)
            {
 if (Input.GetKeyDown(KeyCode.L))
            {
                    GetComponent<Animator>().SetTrigger("Shot");
                Debug.Log("u clicked");
                source.PlayOneShot(shot,0.2f);
                Debug.Log("pressed space bullet will now spawn");
                Spawnblock();
                Click = false;
                StartCoroutine(WaitForShot(0.2f));
            }
            }
           
        }
        if (iAmmo > GetComponent<PlayerController>().iMaxAmmo)
        {
            iAmmo = GetComponent<PlayerController>().iMaxAmmo;
        }
        else if (fAmmo > GetComponent<PlayerController>().iMaxAmmo)
        {
            fAmmo = GetComponent<PlayerController>().iMaxAmmo;
        }
        else if (gAmmo > GetComponent<PlayerController>().iMaxAmmo)
        {
            gAmmo = GetComponent<PlayerController>().iMaxAmmo;
        }
        switch (weapon)
        {
            case 0: ammobar.fillAmount = (float)currentammo / GetComponent<PlayerController>().iMaxAmmo;break;
            default: ammobar.fillAmount = (float)currentammo / GetComponent<PlayerController>().iMaxAmmo*2; break;
        }
        
    }
}
