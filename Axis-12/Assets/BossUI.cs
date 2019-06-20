using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BossUI : MonoBehaviour
{
    public Image img;
    int hp;
    
    private void Update()
    {
        var moth = GameObject.FindGameObjectWithTag("Boss");
        if (moth!=null)
        img.fillAmount = (float)moth.GetComponent<Mothera>().hp / moth.GetComponent<Mothera>().maxHp; 
    }
}
