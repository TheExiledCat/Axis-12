using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floating : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine("Up");
    }
    IEnumerator Up()
    {
        for(int i = 0; i < 15; i++)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.05f);
            yield return new WaitForEndOfFrame();
        }
        StartCoroutine("Down");
    }
    IEnumerator Down()
    {
        for (int i = 0; i < 15; i++)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.05f);
            yield return new WaitForEndOfFrame();
        }
        StartCoroutine("Up");
    }
}
