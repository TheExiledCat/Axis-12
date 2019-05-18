using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatUp : MonoBehaviour
{


    private void Start()
    {
        StartCoroutine("Float");
    }
    IEnumerator Float()
    {
        for(int i = 0; i < 120; i++)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.0083f);
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSeconds(0f); 
    }
}
