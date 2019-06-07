using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBattle : MonoBehaviour
{
    public GameObject tmp;
    public GameObject monster;
    public GameObject moth;
    public Transform spawn;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            monster.SetActive(true);
            StartBattle();
            Instantiate(moth, spawn.position, Quaternion.identity);
            tmp.SetActive(true);
            collision.gameObject.transform.position = new Vector3(collision.gameObject.transform.position.x + 3, collision.gameObject.transform.position.y);
        }
    }
    void StartBattle()
    {
        Camera.main.GetComponent<cameraFollow>().xMax = 19;
        Camera.main.GetComponent<cameraFollow>().xMax = 30;
        gameObject.SetActive(false);
    }
}
