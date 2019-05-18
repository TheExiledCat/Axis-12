using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SoundSwap : MonoBehaviour
{
    public Sprite on;
    public Sprite off;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Image>().sprite = on;
    }

    public void Swap()
    {
        if(GetComponent<Image>().sprite==on)
        GetComponent<Image>().sprite = off;
        else if(GetComponent<Image>().sprite==off)
            GetComponent<Image>().sprite=on;
    }
}
