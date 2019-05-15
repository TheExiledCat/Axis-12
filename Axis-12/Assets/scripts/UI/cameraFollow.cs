using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour {
    public float yMin;
    public float yMax;
    public float xMin;
    public float xMax;
    public Transform Target;
    public float Speed = 0.125f;
    
    
    void LateUpdate()
    {
       transform.position = new Vector3(Target.position.x,transform.position.y,transform.position.z);
        float x = Mathf.Clamp(Target.transform.position.x, xMin, xMax);
        float y = Mathf.Clamp(Target.transform.position.y, yMin, yMax);
        transform.position = new Vector3(x, y, transform.position.z);
    }
}
